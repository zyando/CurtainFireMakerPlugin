﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using MMDataIO.Pmx;

namespace CurtainFireMakerPlugin.Entities
{
    public class ModelMaterialCollection
    {
        public World World { get; }

        public ModelMaterialCollection(World world)
        {
            World = world;
        }

        public void CreateMaterials(ShotProperty prop, string[] modelTextures, int propCount, out PmxMaterialData[] materials)
        {
            var textures = prop.Type.CreateTextures(World, prop);
            materials = prop.Type.CreateMaterials(World, prop);
            prop.Type.InitModelData(prop, materials);

            int GetTextureId(int id) => (0 <= id && id < textures.Length) ? Array.IndexOf(modelTextures, textures[id]) : -1;

            foreach (var (material, i) in materials.Select((item, idx) => (item, idx)))
            {
                material.MaterialName = prop.Type.Name + "_" + GetHexColorCode(prop.Color) + (materials.Length != 1 ? "_" + i : "");

                material.TextureId = GetTextureId(material.TextureId);
                material.SphereId = GetTextureId(material.SphereId);
                material.FaceCount *= propCount;
            }

            string GetHexColorCode(int i)
            {
                string hex = i.ToString("X");
                return "0x" + (hex.Length == 6 ? hex : new string('0', 6 - hex.Length) + hex);
            }
        }
    }
}
