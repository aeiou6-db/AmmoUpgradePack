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
using VanillaAssetUtil.AssetUtil;

namespace AmmoUpgradePack
{
    internal class SharedAssets : Module
    {
        internal static AmmoType ammo_dm120;
        internal static AmmoClipCodexScriptable codex_dm120;
        internal static AmmoType ammo_dm105;
        internal static AmmoType ammo_3bk18m;

        internal static AmmoType ammo_3bk5m;
        internal static AmmoClipCodexScriptable codex_dm105;
        internal static AmmoClipCodexScriptable codex_m833;
        internal static AmmoType ammo_m833;
        internal static AmmoType ammo_3bm32;
        internal static AmmoType ammo_3bm25;

        internal static AmmoType ammo_3bm20;
        internal static AmmoType ammo_konkurs;
        internal static AmmoClipCodexScriptable codex_konkurs;
        internal static AmmoType ammo_fagot;

        internal static AmmoType ammo_milan;

        internal static AmmoType ammo_itow;
        internal static AmmoClipCodexScriptable codex_3ubr6;
        internal static AmmoType ammo_3ubr6;

        internal static AmmoClipCodexScriptable codex_itow;
        internal static AmmoClipCodexScriptable codex_fagot;
        internal static AmmoClipCodexScriptable codex_malyutka;
        internal static AmmoType ammo_malyutka;
        internal static AmmoType ammo_pg15;
        internal static AmmoType ammo_kobra;
        internal static AmmoType ammo_3bm28;
        public override void LoadDynamicAssets()
        {
            AssetUtilApi.LoadVanillaVehicle("MARDERA1PLUS");
            AssetUtilApi.LoadVanillaVehicle("M1IP");
            AssetUtilApi.LoadVanillaVehicle("T62");
            AssetUtilApi.LoadVanillaVehicle("BMP2");
            AssetUtilApi.LoadVanillaVehicle("BMP1");
            AssetUtilApi.LoadVanillaVehicle("M2BRADLEY");
            AssetUtilApi.LoadVanillaVehicle("STATIC_9K111");
            AmmoClipCodexScriptable[] clip_codex_scriptables = Resources.FindObjectsOfTypeAll<AmmoClipCodexScriptable>();
            AmmoCodexScriptable[] codex_scriptables = Resources.FindObjectsOfTypeAll<AmmoCodexScriptable>();
            codex_3ubr6 = clip_codex_scriptables.Where(o => o.name == "clip_3UBR6_160rd_load").FirstOrDefault();
            codex_dm120 = clip_codex_scriptables.Where(o => o.name == "clip_DM23(120)").FirstOrDefault();
            codex_dm105 = clip_codex_scriptables.Where(o => o.name == "clip_DM23(105)").FirstOrDefault();
            codex_m833 = clip_codex_scriptables.Where(o => o.name == "clip_M833").FirstOrDefault();
            codex_konkurs = clip_codex_scriptables.Where(o => o.name == "clip_9M113").FirstOrDefault();
            codex_fagot = clip_codex_scriptables.Where(o => o.name == "clip_9M111").FirstOrDefault();
            codex_malyutka = clip_codex_scriptables.Where(o => o.name == "clip_9M14M").FirstOrDefault();
            codex_itow = clip_codex_scriptables.Where(o => o.name == "clip_I-TOW").FirstOrDefault();
            ammo_kobra = codex_scriptables.Where(o => o.name == "ammo_9M112M").FirstOrDefault().AmmoType;
            ammo_3bm32 = codex_scriptables.Where(o => o.name == "ammo_3BM32").FirstOrDefault().AmmoType;
            ammo_3bm28 = codex_scriptables.Where(o => o.name == "ammo_3BM28").FirstOrDefault().AmmoType;
            ammo_3bm25 = codex_scriptables.Where(o => o.name == "ammo_3BM25").FirstOrDefault().AmmoType;
            ammo_3bm20 = codex_scriptables.Where(o => o.name == "ammo_3BM20").FirstOrDefault().AmmoType;
            ammo_3bk18m = codex_scriptables.Where(o => o.name == "ammo_3BK18M").FirstOrDefault().AmmoType;
            ammo_3bk5m = codex_scriptables.Where(o => o.name == "ammo_3BK5M").FirstOrDefault().AmmoType;
            ammo_konkurs = codex_scriptables.Where(o => o.name == "ammo_9M113").FirstOrDefault().AmmoType;
            ammo_fagot = codex_scriptables.Where(o => o.name == "ammo_9M111").FirstOrDefault().AmmoType;
            ammo_malyutka = codex_scriptables.Where(o => o.name == "ammo_9M14M").FirstOrDefault().AmmoType;
            ammo_pg15 = codex_scriptables.Where(o => o.name == "ammo_PG15VS").FirstOrDefault().AmmoType;
            ammo_itow = codex_scriptables.Where(o => o.name == "ammo_I-TOW").FirstOrDefault().AmmoType;
            ammo_milan = codex_scriptables.Where(o => o.name == "ammo_MILAN").FirstOrDefault().AmmoType;

            ammo_3ubr6 = codex_3ubr6.ClipType.MinimalPattern[0].AmmoType;
            ammo_dm120 = codex_dm120.ClipType.MinimalPattern[0].AmmoType;
            ammo_dm105 = codex_dm105.ClipType.MinimalPattern[0].AmmoType;
            ammo_m833 = codex_m833.ClipType.MinimalPattern[0].AmmoType;
        }
        public override void LoadStaticAssets()
        {
            // does nothing for now
        }

    }
}