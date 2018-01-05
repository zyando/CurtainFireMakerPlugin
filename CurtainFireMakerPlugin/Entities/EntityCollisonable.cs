﻿using System;
using System.Linq;
using VecMath;

namespace CurtainFireMakerPlugin.Entities
{
    public abstract class EntityCollisonable : EntityShootable
    {
        protected abstract bool IsCollisionable { get; set; }

        private float TimeToCollide { get; set; }

        private bool ShouldUpdateTimeToCollide { get; set; } = true;

        private static float Epsilon { get; set; } = 1E-4F;

        public EntityCollisonable(World world, Entity parentEntity = null) : base(world, parentEntity)
        {
            TimeToCollide = world.MaxFrame;
        }

        protected override void OnVelocityUpdated()
        {
            base.OnVelocityUpdated();

            ShouldUpdateTimeToCollide = true;
        }

        public override void Frame()
        {
            if (IsCollisionable && FrameCount >= Math.Floor(TimeToCollide))
            {
                OnCollided(TimeToCollide - (float)Math.Floor(TimeToCollide));
                IsCollisionable = false;
            }

            base.Frame();

            if (IsCollisionable && ShouldUpdateTimeToCollide)
            {
                UpdateMinTimeToCollideWithObject();
                ShouldUpdateTimeToCollide = false;
            }
        }

        public virtual void OnCollided(float time) { }

        private void UpdateMinTimeToCollideWithObject()
        {
            foreach (var tri in World.RigidObjectList.Where(c => IsIntersectWithAABB(c.AABB)).SelectMany(c => c.Meshes))
            {
                float time = CalculateTimeToIntersectWithPlane(tri.Pos1, tri.Normal);

                if (0 <= time && time + FrameCount < TimeToCollide && IsIntersectWithTriangle(tri))
                {
                    TimeToCollide = time + FrameCount;
                }
            }
        }

        protected virtual bool IsIntersectWithAABB(AABoundingBox box)
        {
            float max = float.MaxValue;
            float min = float.MinValue;

            for (int i = 0; i < 3; i++)
            {
                float v = Velocity[i] != 0 ? Velocity[i] : 1E-7F;
                float t1 = (box.Pos1[i] - Pos[i]) / v;
                float t2 = (box.Pos2[i] - Pos[i]) / v;

                float near = Math.Min(t1, t2);
                float far = Math.Max(t1, t2);

                min = Math.Max(min, near);
                max = Math.Min(max, far);

                if (min > max) return false;
            }
            return true;
        }

        protected virtual bool IsIntersectWithTriangle(MeshTriangle tri)
        {
            var cross1 = (tri.Pos2 - tri.Pos1) ^ (Pos - tri.Pos1);
            var cross2 = (tri.Pos3 - tri.Pos2) ^ (Pos - tri.Pos2);
            var cross3 = (tri.Pos1 - tri.Pos3) ^ (Pos - tri.Pos3);

            var dot1 = cross1 * Velocity;
            var dot2 = cross2 * Velocity;
            var dot3 = cross3 * Velocity;

            return !(dot1 > 0 ^ dot2 > 0) && !(dot2 > 0 ^ dot3 > 0);
        }

        protected virtual float CalculateTimeToIntersectWithPlane(Vector3 planePos, Vector3 normal)
        {
            float dot = normal * Velocity;

            if (Math.Abs(dot) <= Epsilon) return float.MaxValue;

            return normal * (planePos - Pos) / dot;
        }
    }
}
