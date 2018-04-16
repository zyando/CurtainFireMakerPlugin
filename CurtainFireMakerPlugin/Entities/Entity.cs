﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using VecMath;
using IronPython.Runtime;
using IronPython.Runtime.Operations;

namespace CurtainFireMakerPlugin.Entities
{
    public class Entity : DynamicObject
    {
        public virtual Matrix4 WorldMat { get; protected set; }
        public Vector3 WorldPos => WorldMat.Translation;
        public Matrix3 WorldRot => WorldMat;

        public virtual Matrix4 LocalMat { get; protected set; }
        public virtual Vector3 Pos { get; set; }
        public virtual Quaternion Rot { get; set; } = Quaternion.Identity;

        public virtual Entity ParentEntity { get; protected set; }

        public int FrameCount { get; protected set; }
        public int LivingLimit { get; set; }
        public int SpawnFrameNo { get; private set; }
        public int DeathFrameNo { get; private set; }

        public virtual Func<Entity, bool> ShouldRemove { get; set; } = e => e.LivingLimit != 0 && e.FrameCount >= e.LivingLimit;

        public event EventHandler DeathEvent;

        public bool IsRemoved { get; private set; }

        public int FramePriority => ParentEntity != null ? ParentEntity.FramePriority + 1 : 0;

        private ScheduledTaskManager TaskScheduler { get; } = new ScheduledTaskManager();

        private Dictionary<string, object> AttributeDict { get; } = new Dictionary<string, object>();

        public World World { get; }

        public int EntityId { get; }
        private static int nextEntityId;

        public Entity(World world, Entity parentEntity = null)
        {
            World = world;
            EntityId = nextEntityId++;

            ParentEntity = parentEntity;
        }

        public virtual void Frame()
        {
            TaskScheduler.Frame();

            FrameCount++;
            if (ShouldRemove(this))
            {
                Remove();
            }

            LocalMat = new Matrix4(Rot, Pos);
            WorldMat = ParentEntity != null ? LocalMat * ParentEntity.WorldMat : LocalMat;
        }

        public void __call__()
        {
            Spawn();
        }

        public virtual void Spawn()
        {
            LocalMat = new Matrix4(Rot, Pos);
            WorldMat = ParentEntity != null ? LocalMat * ParentEntity.WorldMat : LocalMat;

            SpawnFrameNo = World.AddEntity(this);
        }

        public virtual void Remove()
        {
            DeathFrameNo = World.RemoveEntity(this);
            IsRemoved = true;

            DeathEvent?.Invoke(this, EventArgs.Empty);
        }

        private void AddTask(ScheduledTask task)
        {
            TaskScheduler.AddTask(task);
        }

        private void AddTask(PythonFunction task, Func<int, int> interval, int executeTimes, int waitTime, bool withArg = false)
        {
            if (withArg)
            {
                AddTask(new ScheduledTask(t => PythonCalls.Call(task, t), interval, executeTimes, waitTime));
            }
            else
            {
                AddTask(new ScheduledTask(t => PythonCalls.Call(task), interval, executeTimes, waitTime));
            }
        }

        public void AddTask(PythonFunction task, PythonFunction interval, int executeTimes, int waitTime, bool withArg = false)
        {
            AddTask(task, i => (int)PythonCalls.Call(interval, i), executeTimes, waitTime, withArg);
        }

        public void AddTask(PythonFunction task, int interval, int executeTimes, int waitTime, bool withArg = false)
        {
            AddTask(task, i => interval, executeTimes, waitTime, withArg);
        }

        public override bool Equals(object obj) => obj is Entity e && EntityId == e.EntityId;

        public override int GetHashCode() => EntityId;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (!AttributeDict.ContainsKey(binder.Name))
            {
                throw new KeyNotFoundException("Not found key : " + binder.Name);
            }
            result = AttributeDict[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            AttributeDict[binder.Name] = value;
            return true;
        }
    }
}
