using GHPC.Weaponry;
using GHPC.Weapons;
using ModUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AmmoUpgradePack
{
    public class Shells : ModUtil.Module
    {
        public static AmmoClipCodexScriptable clip_codex_dm33;
        public static AmmoType.AmmoClip clip_dm33;
        public static AmmoCodexScriptable ammo_codex_dm33;
        public static AmmoType ammo_dm33;
        public static GameObject ammo_dm33_vis = null;

        public static AmmoClipCodexScriptable clip_codex_dm53;
        public static AmmoType.AmmoClip clip_dm53;
        public static AmmoCodexScriptable ammo_codex_dm53;
        public static AmmoType ammo_dm53;
        public static GameObject ammo_dm53_vis = null;

        public static AmmoClipCodexScriptable clip_codex_m900;
        public static AmmoType.AmmoClip clip_m900;
        public static AmmoCodexScriptable ammo_codex_m900;
        public static AmmoType ammo_m900;
        public static GameObject ammo_m900_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bm36;
        public static AmmoType.AmmoClip clip_3bm36;
        public static AmmoCodexScriptable ammo_codex_3bm36;
        public static AmmoType ammo_3bm36;
        public static GameObject ammo_3bm36_vis = null;

        public static AmmoClipCodexScriptable clip_codex_dm105_33;
        public static AmmoType.AmmoClip clip_dm105_33;
        public static AmmoCodexScriptable ammo_codex_dm105_33;
        public static AmmoType ammo_dm105_33;
        public static GameObject ammo_dm105_33_vis = null;

        public static Dictionary<string, AmmoClipCodexScriptable> leoap;

        public override void UnloadDynamicAssets()
        {
            GameObject.DestroyImmediate(ammo_dm33_vis);
            GameObject.DestroyImmediate(ammo_dm53_vis);
            GameObject.DestroyImmediate(ammo_m900_vis);
            GameObject.DestroyImmediate(ammo_dm105_33_vis);
        }

        public override void LoadDynamicAssets()
        {
            // optimization defining // 
            string era_schema = Assembly.CreateQualifiedName("PactIncreasedLethality", "PactIncreasedLethality.EraSchema");
            string k5 = Assembly.CreateQualifiedName("PactIncreasedLethality", "PactIncreasedLethality.Kontakt5");
            string relikt = Assembly.CreateQualifiedName("PactIncreasedLethality", "PactIncreasedLethality.Relikt");
            Type era_schema_type = Type.GetType(era_schema);
            Type k5_type = Type.GetType(k5);
            Type relikt_type = Type.GetType(relikt);

            // actual shells // 

            //
            ammo_dm33 = new AmmoType();
            Util.ShallowCopy(ammo_dm33, SharedAssetz.ammo_dm120);
            ammo_dm33.Name = "DM33 APFSDS-T";
            ammo_dm33.RhaPenetration = 610;
            ammo_dm33.Caliber = 120;
            ammo_dm33.MuzzleVelocity = 1680;
            ammo_dm33.SpallMultiplier = 2f;
            ammo_dm33.MaxSpallRha = 30;
            ammo_dm33.MinSpallRha = 8;

            Util.Coalesce(ref ammo_codex_dm33);
            ammo_codex_dm33.AmmoType = ammo_dm33;
            ammo_codex_dm33.name = "ammo_dm33(120)";

            clip_dm33 = new AmmoType.AmmoClip();
            clip_dm33.Capacity = 1;
            clip_dm33.Name = "DM33 APFSDS-T";
            clip_dm33.MinimalPattern = new AmmoCodexScriptable[1];
            clip_dm33.MinimalPattern[0] = ammo_codex_dm33;

            Util.Coalesce(ref clip_codex_dm33);
            clip_codex_dm33.name = "clip_dm33(120)";
            clip_codex_dm33.ClipType = clip_dm33;

            ammo_dm33_vis = GameObject.Instantiate(SharedAssetz.ammo_dm120.VisualModel);
            ammo_dm33_vis.name = "dm33 visual";
            ammo_dm33.VisualModel = ammo_dm33_vis;
            ammo_dm33.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_dm33;
            ammo_dm33.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_dm33;

            ///////////////////////////////////////////////////////////////////////////////////////////////
            
            ammo_dm53 = new AmmoType();
            Util.ShallowCopy(ammo_dm53, SharedAssetz.ammo_dm120);
            ammo_dm53.Name = "DM53 APFSDS-T";
            ammo_dm53.RhaPenetration = 780;
            ammo_dm53.Caliber = 120;
            ammo_dm53.MuzzleVelocity = 1680;
            ammo_dm53.Mass = 8.35f; 
            ammo_dm53.MaxSpallRha = 30;
            ammo_dm53.MinSpallRha = 8;

            Util.Coalesce(ref ammo_codex_dm53);
            ammo_codex_dm53.AmmoType = ammo_dm53;
            ammo_codex_dm53.name = "ammo_dm53(120)";

            clip_dm53 = new AmmoType.AmmoClip();
            clip_dm53.Capacity = 1;
            clip_dm53.Name = "DM53 APFSDS-T";
            clip_dm53.MinimalPattern = new AmmoCodexScriptable[1];
            clip_dm53.MinimalPattern[0] = ammo_codex_dm53;

            Util.Coalesce(ref clip_codex_dm53);
            clip_codex_dm53.name = "clip_dm53(120)";
            clip_codex_dm53.ClipType = clip_dm53;

            ammo_dm53_vis = GameObject.Instantiate(SharedAssetz.ammo_dm120.VisualModel);
            ammo_dm53_vis.name = "dm53 visual";
            ammo_dm53.VisualModel = ammo_dm53_vis;
            ammo_dm53.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_dm53;
            ammo_dm53.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_dm53;
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ammo_m900 = new AmmoType();
            Util.ShallowCopy(ammo_m900, SharedAssetz.ammo_m833);
            ammo_m900.Name = "M900 APFSDS-T";
            ammo_m900.RhaPenetration = 650;
            ammo_m900.Caliber = 105;
            ammo_m900.MuzzleVelocity = 1505;
            ammo_m900.Mass = 6.86f;
            ammo_m900.SpallMultiplier = 1f;

            Util.Coalesce(ref ammo_codex_m900);
            ammo_codex_m900.AmmoType = ammo_m900;
            ammo_codex_m900.name = "ammo_m900";

            clip_m900 = new AmmoType.AmmoClip();
            clip_m900.Capacity = 1;
            clip_m900.Name = "M900 APFSDS-T";
            clip_m900.MinimalPattern = new AmmoCodexScriptable[1];
            clip_m900.MinimalPattern[0] = ammo_codex_m900;

            Util.Coalesce(ref clip_codex_m900);
            clip_codex_m900.name = "clip_m900";
            clip_codex_m900.ClipType = clip_m900;

            ammo_m900_vis = GameObject.Instantiate(SharedAssetz.ammo_m833.VisualModel);
            ammo_m900_vis.name = "m900 visual";
            ammo_m900.VisualModel = ammo_m900_vis;
            ammo_m900.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m900;
            ammo_m900.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m900;

            ///////////////////////////////////////////////////////////////////////////////////////////////
            ammo_dm105_33 = new AmmoType();
            Util.ShallowCopy(ammo_dm105_33, SharedAssetz.ammo_dm105);
            ammo_dm105_33.Name = "DM33 APFSDS-T";
            ammo_dm105_33.RhaPenetration = 435;
            ammo_dm105_33.Caliber = 105;
            ammo_dm105_33.MuzzleVelocity = 1450;
            ammo_dm105_33.Mass = 4.1f;
            ammo_dm105_33.MaxSpallRha = 20;
            ammo_dm105_33.MinSpallRha = 2;
            ammo_dm105_33.Coeff = 0.195f;

            Util.Coalesce(ref ammo_codex_dm105_33);
            ammo_codex_dm105_33.AmmoType = ammo_dm105_33;
            ammo_codex_dm105_33.name = "ammo_dm_105_33";

            clip_dm105_33 = new AmmoType.AmmoClip();
            clip_dm105_33.Capacity = 1;
            clip_dm105_33.Name = "DM33 APFSDS-T";
            clip_dm105_33.MinimalPattern = new AmmoCodexScriptable[1];
            clip_dm105_33.MinimalPattern[0] = ammo_codex_dm105_33;

            Util.Coalesce(ref clip_codex_dm105_33);
            clip_codex_dm105_33.name = "clip_dm_105_33";
            clip_codex_dm105_33.ClipType = clip_dm105_33;

            ammo_dm105_33_vis = GameObject.Instantiate(SharedAssetz.ammo_dm105.VisualModel);
            ammo_dm105_33_vis.name = "dm105_33 visual";
            ammo_dm105_33.VisualModel = ammo_dm105_33_vis;
            ammo_dm105_33.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_dm105_33;
            ammo_dm105_33.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_dm105_33;

            ///////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bm36 = new AmmoType();
            Util.ShallowCopy(ammo_3bm36, SharedAssetz.ammo_3bm32);
            ammo_3bm36.Name = "3BM36 APFSDS-T";
            ammo_3bm36.RhaPenetration = 535;
            ammo_3bm36.Caliber = 115;
            ammo_3bm36.MuzzleVelocity = 1650;
            ammo_3bm36.SpallMultiplier = 0.7f;

            Util.Coalesce(ref ammo_codex_3bm36);
            ammo_codex_3bm36.AmmoType = ammo_3bm36;
            ammo_codex_3bm36.name = "ammo_3bm36";

            clip_3bm36 = new AmmoType.AmmoClip();
            clip_3bm36.Capacity = 1;
            clip_3bm36.Name = "3BM36 APFSDS-T";
            clip_3bm36.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bm36.MinimalPattern[0] = ammo_codex_3bm36;

            Util.Coalesce(ref clip_codex_3bm36);
            clip_codex_3bm36.name = "clip_3bm36";
            clip_codex_3bm36.ClipType = clip_3bm36;

            ammo_3bm36_vis = GameObject.Instantiate(SharedAssetz.ammo_3bm28.VisualModel);
            ammo_3bm36_vis.name = "3bm36 visual";
            ammo_3bm36.VisualModel = ammo_3bm36_vis;
            ammo_3bm36.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bm36;
            ammo_3bm36.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bm36;
            ///////////////////////////////////////////////////////////////////////////////////////////////
            // anti Era Optimizations //
            if (k5_type != null)
            {
                BindingFlags flags = BindingFlags.Static | BindingFlags.Public;
                FieldInfo era_schema_so = era_schema_type.GetField("era_so", BindingFlags.Public | BindingFlags.Instance);
                Func<Type, ArmorCodexScriptable> get_codex = type => (ArmorCodexScriptable)era_schema_so.GetValue(type.GetField("schema", flags).GetValue(null));

                ammo_dm53.ArmorOptimizations = new AmmoType.ArmorOptimization[] {
                    new AmmoType.ArmorOptimization() {
                        Armor = get_codex(k5_type),
                        RhaRatio = 0.3f
                    },

                    new AmmoType.ArmorOptimization() {
                        Armor = get_codex(relikt_type),
                        RhaRatio = 0.4f
                    }
                };
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////


            leoap = new Dictionary<string, AmmoClipCodexScriptable>()
            {
                ["DM23"] = SharedAssetz.codex_dm120,
                ["DM33"] = clip_codex_dm33,
                ["DM53"] = clip_codex_dm53
            };
        }
    }
}
