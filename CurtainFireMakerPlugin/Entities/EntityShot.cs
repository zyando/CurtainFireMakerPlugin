﻿using System;
using System.Collections.Generic;
using System.Linq;
using CsMmdDataIO.Pmx;
using CsMmdDataIO.Vmd;
using VecMath;

namespace CurtainFireMakerPlugin.Entities
{
    public class EntityShot : EntityCollisonable
    {
        public ShotProperty Property { get; }

        public ShotModelData ModelData { get; }
        public PmxBoneData RootBone => ModelData.Bones[0];

        public Recording Recording { get; set; } = Recording.Velocity;
        public Colliding Colliding { get; set; } = Colliding.None;

        protected override bool IsCollisionable { get => Colliding != Colliding.None; set => Colliding = value ? Colliding : Colliding.None; }

        public EntityShot(World world, ShotType type, int color, EntityShot parentEntity = null)
        : this(world, new ShotProperty(type, color), parentEntity) { }

        public EntityShot(World world, ShotType type, int color, short group, EntityShot parentEntity = null)
        : this(world, new ShotProperty(type, color, group), parentEntity) { }

        public EntityShot(World world, ShotProperty property, EntityShot parentEntity = null) : base(world, parentEntity)
        {
            Property = property;

            ModelData = World.AddShot(this);
            ModelData.OwnerEntities.Add(this);

            RootBone.ParentId = ParentEntity is EntityShot entity ? entity.RootBone.BoneId : RootBone.ParentId;

            Property.Type.InitEntity(this);
            Property.Type.InitModelData(ModelData);
        }

        public override void OnSpawn()
        {
            base.OnSpawn();

            if (World.FrameCount > 0)
            {
                AddBoneKeyFrame(RootBone, new Vector3(0, -5000000, 0), Quaternion.Identity, CubicBezierCurve.Line, -1, -1);
                AddBoneKeyFrame(RootBone, new Vector3(0, -5000000, 0), Quaternion.Identity, CubicBezierCurve.Line, -World.FrameCount, -1);
            }
            AddRootBoneKeyFrame();
        }

        public override void OnDeath()
        {
            base.OnDeath();

            AddRootBoneKeyFrame(frameOffset: 0, priority: 0);
            AddBoneKeyFrame(RootBone, new Vector3(0, -5000000, 0), Quaternion.Identity, CubicBezierCurve.Line, 1, -1);
        }

        protected override void UpdateTasks()
        {
            base.UpdateTasks();

            if (World.FrameCount == 0 || Recording.ShouldRecord(this))
            {
                AddRootBoneKeyFrame();
            }
        }

        public override void OnCollided(MeshTriangle tri, float time)
        {
            Colliding.OnCollide(this, tri, time);
        }

        public virtual bool IsGroupable(EntityShot e)
        {
            return e.ParentEntity == ParentEntity && e.Property.IsGroupable(Property) && e.IsDeath;
        }

        public override void SetMotionInterpolationCurve(Vector2 pos1, Vector2 pos2, int length, bool isSyncingVelocity = true)
        {
            AddRootBoneKeyFrame(frameOffset: 0, priority: 0);
            base.SetMotionInterpolationCurve(pos1, pos2, length, isSyncingVelocity);
        }

        public override void RemoveMotionInterpolationCurve()
        {
            AddRootBoneKeyFrame(frameOffset: 0, priority: 1);
            base.RemoveMotionInterpolationCurve();
        }

        public void AddRootBoneKeyFrame(int frameOffset = 0, int priority = 0)
        {
            var curve = MotionInterpolation?.StartFrame < World.FrameCount ? MotionInterpolation.Curve : CubicBezierCurve.Line;
            AddBoneKeyFrame(RootBone, Recording.GetRecordedPos(this), Recording.GetRecordedRot(this), curve, frameOffset, priority);
        }

        public void AddBoneKeyFrame(PmxBoneData bone, Vector3 pos, Quaternion rot, CubicBezierCurve curve, int frameOffset = 0, int priority = 0)
        {
            var frame = new VmdMotionFrameData(bone.BoneName, World.FrameCount + frameOffset, pos, rot);
            frame.InterpolationPointX1 = frame.InterpolationPointY1 = frame.InterpolationPointZ1 = curve.P1;
            frame.InterpolationPointX2 = frame.InterpolationPointY2 = frame.InterpolationPointZ2 = curve.P2;
            World.KeyFrames.AddBoneKeyFrame(bone, frame, priority);
        }

        public void AddMorphKeyFrame(PmxMorphData morph, float weight, int frameOffset = 0, int priority = 0)
        {
            var frame = new VmdMorphFrameData(morph.MorphName, World.FrameCount + frameOffset, weight);
            World.KeyFrames.AddMorphKeyFrame(morph, frame, priority);
        }

        public PmxMorphData CreateVertexMorph(Func<Vector3, Vector3> func)
        {
            return ModelData.CreateVertexMorph("V" + EntityId, func);
        }
    }

    public class Recording
    {
        public Func<EntityShot, bool> ShouldRecord { get; private set; }
        public Func<EntityShot, Vector3> GetRecordedPos { get; private set; }
        public Func<EntityShot, Quaternion> GetRecordedRot { get; private set; }

        public static readonly Recording None = new Recording()
        {
            ShouldRecord = e => false,
            GetRecordedPos = e => e.Pos,
            GetRecordedRot = e => e.Rot,
        };
        public static readonly Recording Velocity = new Recording()
        {
            ShouldRecord = e => e.IsUpdatedVelocity,
            GetRecordedPos = e => e.Pos,
            GetRecordedRot = e => Matrix3.LookAt(e.LookAtVec, e.Upward),
        };
        public static readonly Recording LocalMat = new Recording()
        {
            ShouldRecord = e => e.IsUpdatedLocalMat,
            GetRecordedPos = e => e.Pos,
            GetRecordedRot = e => e.Rot,
        };
    }

    public class Colliding
    {
        public Action<EntityShot, MeshTriangle, float> OnCollide { get; private set; }

        public static readonly Colliding None = new Colliding() { OnCollide = (e, tri, time) => { } };
        public static readonly Colliding Vanish = new Colliding() { OnCollide = (e, tri, time) => e.OnDeath() };
        public static readonly Colliding Stick = new Colliding()
        {
            OnCollide = (e, tri, time) =>
            {
                e.Pos += e.Velocity * time;
                e.Velocity = Vector3.Zero;
            }
        };
        public static readonly Colliding Reflect = new Colliding()
        {
            OnCollide = (e, tri, time) =>
            {
                e.Pos += e.Velocity * time + tri.Normal * 2.0F;
                e.Velocity = tri.Normal * (e.Velocity * tri.Normal * -2) + e.Velocity;
            }
        };
    }
}