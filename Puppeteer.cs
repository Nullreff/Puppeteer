using NeosModLoader;
using HarmonyLib;
using FrooxEngine;
using FrooxEngine.UIX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkinnedMeshRenderer = FrooxEngine.SkinnedMeshRenderer;
using BaseX;
using FrooxEngine.CommonAvatar;
using FrooxEngine.LogiX.WorldModel;
using System.Reflection;

namespace Puppeteer
{
    public class Puppeteer : NeosMod
    {
        public override string Name => "Puppeteer";
        public override string Author => "nullreff";
        public override string Version => "0.0.1";

        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.nullreff.puppeteer");
            harmony.PatchAll();
        }

        class ClonePatch
        {
            
        }
    }
}