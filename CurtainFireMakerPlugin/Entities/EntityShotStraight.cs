﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VecMath;

namespace CurtainFireMakerPlugin.Entities
{
    public class EntityShotStraight : EntityShotBase
    {
        public override bool IsReusable => LivingLimit != 0 && World.FrameCount > SpawnFrameNo + LivingLimit;

        public override bool IsNeededUpdate => false;

        public Vector3 InitialPos { get; private set; }

        public override Vector3 Pos { get => InitialPos + Velocity * (World.FrameCount - SpawnFrameNo); set => throw new NotSupportedException(); }

        public Vector3 Velocity { get; set; }
        public Vector3 Upward { get; set; } = Vector3.UnitY;

        public Func<EntityShotStraight, Quaternion> GetRecordedRot { get; set; } = e => Matrix3.LookAt(e.Velocity, e.Upward);

        public EntityShotStraight(World world, string typeName, int color, EntityShot parentEntity = null)
           : this(world, typeName, color, Matrix4.Identity, parentEntity) { }

        public EntityShotStraight(World world, string typeName, int color, float scale, EntityShot parentEntity = null)
        : this(world, typeName, color, new Matrix3(scale), parentEntity) { }

        public EntityShotStraight(World world, string typeName, int color, Vector3 scale, EntityShot parentEntity = null)
        : this(world, typeName, color, new Matrix3(scale), parentEntity) { }

        public EntityShotStraight(World world, string typeName, int color, Matrix3 scale, EntityShot parentEntity = null)
        : this(world, typeName, color, (Matrix4)scale, parentEntity) { }

        public EntityShotStraight(World world, string typeName, int color, Matrix4 scale, EntityShot parentEntity = null)
        : this(world, new ShotProperty(world.ShotTypeProvider.GetShotType(typeName), color, scale), parentEntity) { }

        public EntityShotStraight(World world, ShotProperty property, EntityShot parentEntity = null) : base(world, property, parentEntity)
        {
        }

        public override bool Spawn()
        {
            InitialPos = Pos;
            Rot = GetRecordedRot(this);

            if (World.FrameCount > 0)
            {
                AddBoneKeyFrame(RootBone, new Vector3(0, -5000000, 0), Quaternion.Identity, CubicBezierCurve.Line, -1, -1);
            }
            AddBoneKeyFrame(RootBone, new Vector3(0, -5000000, 0), Quaternion.Identity, CubicBezierCurve.Line, -World.FrameCount, -1);
            AddBoneKeyFrame(RootBone, InitialPos, Rot, CubicBezierCurve.Line, 0, 0);

            AddBoneKeyFrame(RootBone, InitialPos + Velocity * LivingLimit, Rot, CubicBezierCurve.Line, LivingLimit, 0);
            AddBoneKeyFrame(RootBone, new Vector3(0, -5000000, 0), Quaternion.Identity, CubicBezierCurve.Line, LivingLimit + 1, -1);

            return base.Spawn();
        }
    }
}
