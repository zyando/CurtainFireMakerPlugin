﻿using CsMmdDataIO.Pmx.Data;
using CsMmdDataIO.Vmd.Data;
using CurtainFireMakerPlugin.Mathematics;
using System;
using VecMath;

namespace CurtainFireMakerPlugin.Entities
{
    public class EntityShot : Entity
    {
        public ShotProperty Property { get; }

        public ShotModelData ModelData { get; }
        public PmxBoneData RootBone => ModelData.Bones[0];
        public PmxMorphData MaterialMorph => ModelData.MaterialMorph;

        public static class RecordType
        {
            public static Func<EntityShot, bool> None { get; } = e => false;
            public static Func<EntityShot, bool> Velocity { get; } = e => e.IsUpdatedVelocity;
            public static Func<EntityShot, bool> LocalMat { get; } = e => e.IsUpdatedLocalMat;
        }

        public Func<EntityShot, bool> ShouldRecord { get; set; } = RecordType.Velocity;

        public bool IsUpdatedVelocity { get; private set; } = true;
        public bool IsUpdatedLocalMat { get; private set; } = true;

        public static float Epsilon { get; set; } = 0.00001F;

        public override Vector3 Velocity
        {
            get => base.Velocity;
            set => IsUpdatedVelocity |= !Vector3.EpsilonEquals(base.Velocity, (base.Velocity = value), Epsilon);
        }

        public override Vector3 Upward
        {
            get => base.Upward;
            set => IsUpdatedVelocity |= !Vector3.EpsilonEquals(base.Upward, (base.Upward = value), Epsilon);
        }

        public override Vector3 Pos
        {
            get => base.Pos;
            set => IsUpdatedLocalMat |= !Vector3.EpsilonEquals(base.Pos, (base.Pos = value), Epsilon);
        }

        public override Quaternion Rot
        {
            get => base.Rot;
            set => IsUpdatedLocalMat |= !Quaternion.EpsilonEquals(base.Rot, (base.Rot = value), Epsilon);
        }

        public Func<EntityShot, Vector3> GetRecordedPos { get; set; } = e => e.Pos;
        public Func<EntityShot, Quaternion> GetRecordedRot { get; set; } = e => e.Velocity != Vector3.Zero ? (Quaternion)Matrix3.LookAt(+e.Velocity, +e.Upward) * e.Rot : e.Rot;

        public override MotionInterpolation MotionInterpolation
        {
            get => base.MotionInterpolation;
            protected set
            {
                AddBoneKeyFrame();
                base.MotionInterpolation = value;
            }
        }

        public EntityShot(World world, string typeName, int color, EntityShot parentEntity = null)
        : this(world, new ShotProperty(typeName, color), parentEntity) { }

        public EntityShot(World world, ShotProperty property, EntityShot parentEntity = null) : base(world, parentEntity)
        {
            try
            {
                Property = property;

                ModelData = World.AddShot(this);
                ModelData.OwnerEntities.Add(this);

                RootBone.ParentId = ParentEntity is EntityShot entity ? entity.RootBone.BoneId : RootBone.ParentId;

                Property.Type.Init(this);
                Property.Type.InitModelData(ModelData);
            }
            catch (Exception e)
            {
                try { Console.WriteLine(Plugin.Instance.PythonExecutor.FormatException(e)); } catch { }
                Console.WriteLine(e);
            }
        }

        public override void OnSpawn()
        {
            base.OnSpawn();

            if (World.FrameCount <= 0)
            {
                AddMorphKeyFrame(MaterialMorph, -World.FrameCount, 0.0F);
            }
            else
            {
                AddMorphKeyFrame(MaterialMorph, -1, 1.0F);
                AddMorphKeyFrame(MaterialMorph, 0, 0.0F);
                AddMorphKeyFrame(MaterialMorph, -World.FrameCount, 1.0F);
            }

            AddBoneKeyFrame();
        }

        public override void OnDeath()
        {
            base.OnDeath();

            AddMorphKeyFrame(MaterialMorph, -1, 0.0F);
            AddMorphKeyFrame(MaterialMorph, 0, 1.0F);

            AddBoneKeyFrame();
        }

        internal override void Frame()
        {
            if (ShouldRecord(this) || World.FrameCount == 0)
            {
                AddBoneKeyFrame();
            }
            IsUpdatedVelocity = IsUpdatedLocalMat = false;

            base.Frame();
        }

        public void AddBoneKeyFrame()
        {
            var posCurve = CubicBezierCurve.Line;

            if (MotionInterpolation != null && MotionInterpolation.StartFrame < World.FrameCount)
            {
                posCurve = MotionInterpolation.Curve;
            }

            AddBoneKeyFrame(RootBone, GetRecordedPos(this), GetRecordedRot(this), posCurve);
        }

        public void AddBoneKeyFrame(PmxBoneData bone, Vector3 pos, Quaternion rot, CubicBezierCurve posCurve)
        {
            var posCurveBytes = VmdMotionFrameData.ConvertToBytes(posCurve.P1, posCurve.P2);

            World.KeyFrames.AddBoneKeyFrame(bone, new VmdMotionFrameData()
            {
                FrameTime = World.FrameCount,
                BoneName = bone.BoneName,
                Pos = pos,
                Rot = rot,
                InterpolatePointX = posCurveBytes,
                InterpolatePointY = posCurveBytes,
                InterpolatePointZ = posCurveBytes,
            });
        }

        public void AddMorphKeyFrame(PmxMorphData morph, int frameOffset, float weight)
        {
            if (Property.Type.HasMesh)
            {
                World.KeyFrames.AddMorphKeyFrame(morph, new VmdMorphFrameData()
                {
                    FrameTime = World.FrameCount + frameOffset,
                    MorphName = morph.MorphName,
                    Weigth = weight,
                });
            }
        }

        public PmxMorphData CreateVertexMorph(string morphName, Func<Vector3, Vector3> func)
        {
            if (!ModelData.MorphDict.ContainsKey(morphName))
            {
                var vertices = ModelData.Vertices;

                var morph = new PmxMorphData()
                {
                    MorphName = morphName,
                    SlotType = SlotType.RIP,
                    MorphType = MorphType.VERTEX,
                    MorphArray = new PmxMorphVertexData[vertices.Length]
                };

                for (int i = 0; i < morph.MorphArray.Length; i++)
                {
                    var vertex = vertices[i];
                    var vertexMorph = new PmxMorphVertexData()
                    {
                        Index = vertex.VertexId,
                        Position = func(vertex.Pos)
                    };
                    morph.MorphArray[i] = vertexMorph;
                }
                ModelData.AddMorph(morph);
            }
            return ModelData.MorphDict[morphName];
        }
    }
}
