using GHPC.State;
using GHPC.Weaponry;
using GHPC.Weapons;
using ModUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AmmoUpgradePack
{
    public class shellsNATO : ModUtil.Module
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

        public static AmmoClipCodexScriptable clip_codex_dm105_33;
        public static AmmoType.AmmoClip clip_dm105_33;
        public static AmmoCodexScriptable ammo_codex_dm105_33;
        public static AmmoType ammo_dm105_33;
        public static GameObject ammo_dm105_33_vis = null;

        public static AmmoClipCodexScriptable clip_codex_dm105_63;
        public static AmmoType.AmmoClip clip_dm105_63;
        public static AmmoCodexScriptable ammo_codex_dm105_63;
        public static AmmoType ammo_dm105_63;
        public static GameObject ammo_dm105_63_vis = null;

        public override void UnloadDynamicAssets()
        {
            GameObject.DestroyImmediate(ammo_dm33_vis);
            GameObject.DestroyImmediate(ammo_dm53_vis);
            GameObject.DestroyImmediate(ammo_m900_vis);
            GameObject.DestroyImmediate(ammo_dm105_33_vis);
            GameObject.DestroyImmediate(ammo_dm105_63_vis);
        }
        public static IEnumerator TandemOptimization(GameState _)
        {
            ArmorCodexScriptable[] armor_codices = Resources.FindObjectsOfTypeAll<ArmorCodexScriptable>();
            ArmorCodexScriptable[] lightERA = armor_codices.Where
            (
                o =>
                o.name.Contains("Kontakt-1") ||
                o.name.Contains("M1 ERA")
            ).ToArray();

            ArmorCodexScriptable[] natoERA = armor_codices.Where
             (
                 o =>
                 o.name.Contains("ARAT-1") ||
                 o.name.Contains("BRAT-M3") ||
                 o.name.Contains("BRAT-M5")
             ).ToArray();

            ArmorCodexScriptable[] RUHeavy = armor_codices.Where(
                o =>
                o.name.Contains("Kontakt-5") ||
                o.name.Contains("Relikt")
                ).ToArray();
            ///
            List<AmmoType.ArmorOptimization> tandem = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable lightcodex in lightERA)
            {
                tandem.Add(Util.CreateArmourOptimization(lightcodex, 0.05f));
            }

            foreach (ArmorCodexScriptable natocodex in natoERA)
            {
                tandem.Add(Util.CreateArmourOptimization(natocodex, 0.1f));
            }

            foreach (ArmorCodexScriptable heavycodex in RUHeavy)
            {
                tandem.Add(Util.CreateArmourOptimization(heavycodex, 0.2f));
            }
            ///


            // example.ArmorOptimizations = tandem.ToArray();
            // milan-2 soon?
            yield break;
        }
        public override void LoadDynamicAssets()
        {
            // anti-era tip optimization defining // 
            string era_schema = Assembly.CreateQualifiedName("PactIncreasedLethality", "PactIncreasedLethality.EraSchema");
            string k5 = Assembly.CreateQualifiedName("PactIncreasedLethality", "PactIncreasedLethality.Kontakt5");
            string relikt = Assembly.CreateQualifiedName("PactIncreasedLethality", "PactIncreasedLethality.Relikt");
            Type era_schema_type = Type.GetType(era_schema);
            Type k5_type = Type.GetType(k5);
            Type relikt_type = Type.GetType(relikt);

        // actual shells // 
        ///////////////////////////////////////////////////////////////////////////////////////////////
        ///120mm German Shells
        ///////////////////////////////////////////////////////////////////////////////////////////////
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
            ///105 US Shells
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
            ///105 German Shells
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
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_dm105_63 = new AmmoType();
            Util.ShallowCopy(ammo_dm105_63, SharedAssetz.ammo_dm105);
            ammo_dm105_63.Name = "DM63 APFSDS-T";
            ammo_dm105_63.RhaPenetration = 540;
            ammo_dm105_63.Caliber = 105;
            ammo_dm105_63.MuzzleVelocity = 1455;
            ammo_dm105_63.Mass = 4.2f;
            ammo_dm105_63.MaxSpallRha = 26;
            ammo_dm105_63.MinSpallRha = 2;
            ammo_dm105_63.Coeff = 0.195f;

            Util.Coalesce(ref ammo_codex_dm105_63);
            ammo_codex_dm105_63.AmmoType = ammo_dm105_63;
            ammo_codex_dm105_63.name = "ammo_dm_105_63";

            clip_dm105_63 = new AmmoType.AmmoClip();
            clip_dm105_63.Capacity = 1;
            clip_dm105_63.Name = "DM63 APFSDS-T";
            clip_dm105_63.MinimalPattern = new AmmoCodexScriptable[1];
            clip_dm105_63.MinimalPattern[0] = ammo_codex_dm105_63;

            Util.Coalesce(ref clip_codex_dm105_63);
            clip_codex_dm105_63.name = "clip_dm_105_63";
            clip_codex_dm105_63.ClipType = clip_dm105_63;

            ammo_dm105_63_vis = GameObject.Instantiate(SharedAssetz.ammo_dm105.VisualModel);
            ammo_dm105_63_vis.name = "dm105_63 visual";
            ammo_dm105_63.VisualModel = ammo_dm105_63_vis;
            ammo_dm105_63.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_dm105_63;
            ammo_dm105_63.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_dm105_63;
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
                ///////////////////////////////////////////////////////////////////////////////////////////////
            }
        }
    }
}
