using GHPC.Vehicle;
using GHPC.Weaponry;
using ModUtil;
using NWH.VehiclePhysics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AmmoUpgradePack
{
    internal class SharedAssetz : Module
    {
        internal static AmmoType ammo_dm120;
        internal static AmmoClipCodexScriptable codex_dm120;
        internal static AmmoType ammo_dm105;
        internal static AmmoType ammo_3bk18m;
        internal static AmmoClipCodexScriptable codex_dm105;
        internal static AmmoClipCodexScriptable codex_m833;
        internal static AmmoType ammo_m833;
        internal static AmmoType ammo_3bm32;
        internal static AmmoType ammo_3bm28;

        public override void LoadStaticAssets()
        {
            AssetUtil.LoadVanillaVehicle("LEO2A3");
            AssetUtil.LoadVanillaVehicle("M1IP");
            AssetUtil.LoadVanillaVehicle("T62");
            AmmoClipCodexScriptable[] clip_codex_scriptables = Resources.FindObjectsOfTypeAll<AmmoClipCodexScriptable>();
            AmmoCodexScriptable[] codex_scriptables = Resources.FindObjectsOfTypeAll<AmmoCodexScriptable>();
            codex_dm120 = clip_codex_scriptables.Where(o => o.name == "clip_DM23(120)").FirstOrDefault();
            codex_dm105 = clip_codex_scriptables.Where(o => o.name == "clip_DM23(105)").FirstOrDefault();
            codex_m833 = clip_codex_scriptables.Where(o => o.name == "clip_M833").FirstOrDefault();
            ammo_3bm32 = codex_scriptables.Where(o => o.name == "ammo_3BM32").FirstOrDefault().AmmoType;
            ammo_3bm28 = codex_scriptables.Where(o => o.name == "ammo_3BM28").FirstOrDefault().AmmoType;
            ammo_3bk18m = codex_scriptables.Where(o => o.name == "ammo_3BK18M").FirstOrDefault().AmmoType;
            ammo_dm120 = codex_dm120.ClipType.MinimalPattern[0].AmmoType;
            ammo_dm105 = codex_dm105.ClipType.MinimalPattern[0].AmmoType;
            ammo_m833 = codex_m833.ClipType.MinimalPattern[0].AmmoType;
        }
        public override void LoadDynamicAssets()
        {
            // does nothing for now
        }
    }
}