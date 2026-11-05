using AmmoUpgrade;
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
    public class shellsPACT : ModUtil.Module
    {

        public static AmmoClipCodexScriptable clip_codex_3bm36;
        public static AmmoType.AmmoClip clip_3bm36;
        public static AmmoCodexScriptable ammo_codex_3bm36;
        public static AmmoType ammo_3bm36;
        public static GameObject ammo_3bm36_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bm25;
        public static AmmoType.AmmoClip clip_3bm25;
        public static AmmoCodexScriptable ammo_codex_3bm25;
        public static AmmoType ammo_3bm25;
        public static GameObject ammo_3bm25_vis = null;

        public static AmmoClipCodexScriptable clip_codex_M309;
        public static AmmoType.AmmoClip clip_M309;
        public static AmmoCodexScriptable ammo_codex_M309;
        public static AmmoType ammo_M309;
        public static GameObject ammo_M309_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bm59;
        public static AmmoType.AmmoClip clip_3bm59;
        public static AmmoCodexScriptable ammo_codex_3bm59;
        public static AmmoType ammo_3bm59;
        public static GameObject ammo_3bm59_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bk29;
        public static AmmoType.AmmoClip clip_3bk29;
        public static AmmoCodexScriptable ammo_codex_3bk29;
        public static AmmoType ammo_3bk29;
        public static GameObject ammo_3bk29_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bk17;
        public static AmmoType.AmmoClip clip_3bk17;
        public static AmmoCodexScriptable ammo_codex_3bk17;
        public static AmmoType ammo_3bk17;
        public static GameObject ammo_3bk17_vis = null;

        public static AmmoClipCodexScriptable clip_codex_pg15vnt;
        public static AmmoType.AmmoClip clip_pg15vnt;
        public static AmmoCodexScriptable ammo_codex_pg15vnt;
        public static AmmoType ammo_pg15vnt;
        public static GameObject ammo_pg15vnt_vis = null;

        internal static AmmoClipCodexScriptable clip_codex_3ubr8;
        internal static AmmoType.AmmoClip clip_3ubr8;
        internal static AmmoCodexScriptable ammo_codex_3ubr8;
        internal static AmmoType ammo_3ubr8;
        
        internal static AmmoClipCodexScriptable clip_codex_3ubr11;
        internal static AmmoType.AmmoClip clip_3ubr11;
        internal static AmmoCodexScriptable ammo_codex_3ubr11;
        internal static AmmoType ammo_3ubr11;


        public override void UnloadDynamicAssets()
        {
            GameObject.DestroyImmediate(ammo_3bm59_vis);
            GameObject.DestroyImmediate(ammo_3bm36_vis);
            GameObject.DestroyImmediate(ammo_3bk29_vis);
            GameObject.DestroyImmediate(ammo_pg15vnt_vis);
        }
        public override void LoadDynamicAssets()
        {
            // actual shells //
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ///115mm Shells
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bm36 = new AmmoType();
            Util.ShallowCopy(ammo_3bm36, SharedAssets.ammo_3bm32);
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

            ammo_3bm36_vis = GameObject.Instantiate(SharedAssets.ammo_3bm28.VisualModel);
            ammo_3bm36_vis.name = "3bm36 visual";
            ammo_3bm36.VisualModel = ammo_3bm36_vis;
            ammo_3bm36.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bm36;
            ammo_3bm36.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bm36;
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ///125mm Shells //
            //////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bm59 = new AmmoType();
            Util.ShallowCopy(ammo_3bm59, SharedAssets.ammo_3bm32);
            ammo_3bm59.Name = "3BM59 APFSDS-T";
            ammo_3bm59.Caliber = 125;
            ammo_3bm59.RhaPenetration = 770f;
            ammo_3bm59.Mass = 4.93f;
            ammo_3bm59.MuzzleVelocity = 1725f;
            ammo_3bm59.SpallMultiplier = 1.8f;
            ammo_3bm59.MaxSpallRha = 30f;
            ammo_3bm59.MinSpallRha = 6f;

            Util.Coalesce(ref ammo_codex_3bm59);
            ammo_codex_3bm59.AmmoType = ammo_3bm59;
            ammo_codex_3bm59.name = "ammo_3bm59";

            clip_3bm59 = new AmmoType.AmmoClip();
            clip_3bm59.Capacity = 1;
            clip_3bm59.Name = "3BM59 APFSDS-T";
            clip_3bm59.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bm59.MinimalPattern[0] = ammo_codex_3bm59;

            Util.Coalesce(ref clip_codex_3bm59);
            clip_codex_3bm59.name = "clip_3bm59";
            clip_codex_3bm59.ClipType = clip_3bm59;

            ammo_3bm59_vis = GameObject.Instantiate(SharedAssets.ammo_3bm32.VisualModel);
            ammo_3bm59_vis.name = "3bm59 visual";
            ammo_3bm59.VisualModel = ammo_3bm59_vis;
            ammo_3bm59.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bm59;
            ammo_3bm59.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bm59;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bk29 = new AmmoType();
            Util.ShallowCopy(ammo_3bk29, SharedAssets.ammo_3bk18m);
            ammo_3bk29.Name = "3BK29 HEAT-FS-T";
            ammo_3bk29.RhaPenetration = 630;
            ammo_3bk29.Caliber = 125;
            ammo_3bk29.MuzzleVelocity = 915;
            ammo_3bk29.ForcedSpallAngle = 90;
            ammo_3bk29.MaxSpallRha = 24;
            ammo_3bk29.MinSpallRha = 1;
            ammo_3bk29.SpallMultiplier = 1.85f;

            Util.Coalesce(ref ammo_codex_3bk29);
            ammo_codex_3bk29.AmmoType = ammo_3bk29;
            ammo_codex_3bk29.name = "ammo_3BK29";

            clip_3bk29 = new AmmoType.AmmoClip();
            clip_3bk29.Capacity = 1;
            clip_3bk29.Name = "3BK29 HEAT-FS-T";
            clip_3bk29.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bk29.MinimalPattern[0] = ammo_codex_3bk29;

            Util.Coalesce(ref clip_codex_3bk29);
            clip_codex_3bk29.name = "clip_3BK29";
            clip_codex_3bk29.ClipType = clip_3bk29;

            ammo_3bk29_vis = GameObject.Instantiate(SharedAssets.ammo_3bk18m.VisualModel);
            ammo_3bk29_vis.name = "3BK29 visual";
            ammo_3bk29.VisualModel = ammo_3bk29_vis;
            ammo_3bk29.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bk29;
            ammo_3bk29.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bk29;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            /// 73mm ///
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_pg15vnt = new AmmoType();
            Util.ShallowCopy(ammo_pg15vnt, SharedAssets.ammo_pg15);
            ammo_pg15vnt.Name = "PG-15VNT HEAT";
            ammo_pg15vnt.Category = AmmoType.AmmoCategory.ShapedCharge;
            ammo_pg15vnt.RhaPenetration = 440;

            Util.Coalesce(ref ammo_codex_pg15vnt);
            ammo_codex_pg15vnt.AmmoType = ammo_pg15vnt;
            ammo_codex_pg15vnt.name = "ammo_pg15vnt";

            clip_pg15vnt = new AmmoType.AmmoClip();
            clip_pg15vnt.Capacity = 1;
            clip_pg15vnt.Name = "PG-15VNT HEAT";
            clip_pg15vnt.MinimalPattern = new AmmoCodexScriptable[1];
            clip_pg15vnt.MinimalPattern[0] = ammo_codex_pg15vnt;

            Util.Coalesce(ref clip_codex_pg15vnt);
            clip_codex_pg15vnt.name = "clip_pg15vnt";
            clip_codex_pg15vnt.ClipType = clip_pg15vnt;

            ammo_pg15vnt_vis = GameObject.Instantiate(SharedAssets.ammo_pg15.VisualModel);
            ammo_pg15vnt_vis.name = "pg15vnt visual";
            ammo_pg15vnt.VisualModel = ammo_pg15vnt_vis;
            ammo_pg15vnt.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_pg15vnt;
            ammo_pg15vnt.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_pg15vnt;
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ///100mm Shells //
            //////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bk17 = new AmmoType();
            Util.ShallowCopy(ammo_3bk17, SharedAssets.ammo_3bk5m);
            ammo_3bk17.Name = "3BK17M HEAT-FS-T";
            ammo_3bk17.Mass = 10.0f;
            ammo_3bk17.Coeff = 0.25f;
            ammo_3bk17.MuzzleVelocity = 1085f;
            ammo_3bk17.RhaPenetration = 410f;
            ammo_3bk17.TntEquivalentKg = 0.25f;

            Util.Coalesce(ref ammo_codex_3bk17);
            ammo_codex_3bk17.AmmoType = ammo_3bk17;
            ammo_codex_3bk17.name = "ammo_3BK17M";

            clip_3bk17 = new AmmoType.AmmoClip();
            clip_3bk17.Capacity = 1;
            clip_3bk17.Name = "3BK17M HEAT-FS-T";
            clip_3bk17.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bk17.MinimalPattern[0] = ammo_codex_3bk17;

            Util.Coalesce(ref clip_codex_3bk17);
            clip_codex_3bk17.name = "clip_3BK17M";
            clip_codex_3bk17.ClipType = clip_3bk17;

            ammo_3bk17_vis = GameObject.Instantiate(SharedAssets.ammo_3bk5m.VisualModel);
            ammo_3bk17_vis.name = "3BK17M visual";
            ammo_3bk17.VisualModel = ammo_3bk17_vis;
            ammo_3bk17.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bk17;
            ammo_3bk17.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bk17;
            //////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bm25 = new AmmoType();
            Util.ShallowCopy(ammo_3bm25, SharedAssets.ammo_3bm20);
            ammo_3bm25.RhaPenetration = 380; // maintain parity with PIL 3bm25
            ammo_3bm25.Name = "3BM25 APFSDS-T";

            Util.Coalesce(ref ammo_codex_3bm25);
            ammo_codex_3bm25.AmmoType = ammo_3bm25;
            ammo_codex_3bm25.name = "ammo_3BM25";

            clip_3bm25 = new AmmoType.AmmoClip();
            clip_3bm25.Capacity = 1;
            clip_3bm25.Name = "3BM25 APFSDS-T";
            clip_3bm25.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bm25.MinimalPattern[0] = ammo_codex_3bm25;

            Util.Coalesce(ref clip_codex_3bm25);
            clip_codex_3bm25.name = "clip_3BM25";
            clip_codex_3bm25.ClipType = clip_3bm25;

            ammo_3bm25_vis = GameObject.Instantiate(SharedAssets.ammo_3bm20.VisualModel);
            ammo_3bm25_vis.name = "3BM25 visual";
            ammo_3bm25.VisualModel = ammo_3bm25_vis;
            ammo_3bm25.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bm25;
            ammo_3bm25.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bm25;
            //////////////////////////////////////////////////////////////////////////////////////////
            ammo_M309 = new AmmoType();
            Util.ShallowCopy(ammo_M309, SharedAssets.ammo_3bm20);
            ammo_M309.RhaPenetration = 470;
            ammo_M309.Name = "M309 APFSDS-T";

            Util.Coalesce(ref ammo_codex_M309);
            ammo_codex_M309.AmmoType = ammo_M309;
            ammo_codex_M309.name = "ammo_M309";

            clip_M309 = new AmmoType.AmmoClip();
            clip_M309.Capacity = 1;
            clip_M309.Name = "M309 APFSDS-T";
            clip_M309.MinimalPattern = new AmmoCodexScriptable[1];
            clip_M309.MinimalPattern[0] = ammo_codex_M309;

            Util.Coalesce(ref clip_codex_M309);
            clip_codex_M309.name = "clip_M309";
            clip_codex_M309.ClipType = clip_M309;

            ammo_M309_vis = GameObject.Instantiate(SharedAssets.ammo_3bm20.VisualModel);
            ammo_M309_vis.name = "M309 visual";
            ammo_M309.VisualModel = ammo_M309_vis;
            ammo_M309.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_M309;
            ammo_M309.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_M309;
            //////////////////////////////////////////////////////////////////////////////////////////
            /// 30mm 
            /////////////////////////////////////////////////////////////////////////////////////////
            ammo_3ubr11 = new AmmoType();
            Util.ShallowCopy(ammo_3ubr11, SharedAssets.ammo_3ubr6);
            ammo_3ubr11.Name = "3UBR11 APFSDS-T";
            ammo_3ubr11.Mass = 0.15f;
            ammo_3ubr11.Coeff = 0.008f;
            ammo_3ubr11.MuzzleVelocity = 1260f;
            ammo_3ubr11.RhaPenetration = 97f;
            ammo_3ubr11.SpallMultiplier = 0.9f;
            ammo_3ubr11.VisualType = GHPC.Weapons.LiveRoundMarshaller.LiveRoundVisualType.Custom;

            Util.Coalesce(ref ammo_codex_3ubr11);
            ammo_codex_3ubr11.AmmoType = ammo_3ubr11;
            ammo_codex_3ubr11.name = "ammo_3ubr11";

            clip_3ubr11 = new AmmoType.AmmoClip();
            clip_3ubr11.Capacity = 160;
            clip_3ubr11.Name = "3UBR11 APFSDS-T";
            clip_3ubr11.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3ubr11.MinimalPattern[0] = ammo_codex_3ubr11;

            Util.Coalesce(ref clip_codex_3ubr11);
            clip_codex_3ubr11.name = "clip_3ubr11";
            clip_codex_3ubr11.ClipType = clip_3ubr11;

            //////////////////////////////////////////////////////////////////////////////
            ammo_3ubr8 = new AmmoType();
            Util.ShallowCopy(ammo_3ubr8, SharedAssets.ammo_3ubr6);
            ammo_3ubr8.Name = "3UBR8 APDS-T";
            ammo_3ubr8.Mass = 0.23f;
            ammo_3ubr8.Coeff = 0.011f;
            ammo_3ubr8.MuzzleVelocity = 1120f;
            ammo_3ubr8.RhaPenetration = 78f;
            ammo_3ubr8.VisualType = GHPC.Weapons.LiveRoundMarshaller.LiveRoundVisualType.Custom;

            Util.Coalesce(ref ammo_codex_3ubr8);
            ammo_codex_3ubr8.AmmoType = ammo_3ubr8;
            ammo_codex_3ubr8.name = "ammo_3ubr8";

            clip_3ubr8 = new AmmoType.AmmoClip();
            clip_3ubr8.Capacity = 160;
            clip_3ubr8.Name = "3UBR8 APDS-T";
            clip_3ubr8.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3ubr8.MinimalPattern[0] = ammo_codex_3ubr8;

            Util.Coalesce(ref clip_codex_3ubr8);
            clip_codex_3ubr8.name = "clip_3ubr8";
            clip_codex_3ubr8.ClipType = clip_3ubr8;

            //////////////////////////////////////////////////////////////////////////////
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

            // for shitty tandem rounds
            List<AmmoType.ArmorOptimization> shittytandem = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable lightcodex in lightERA)
            {
                shittytandem.Add(Util.CreateArmourOptimization(lightcodex, 0.1f));
            }

            foreach (ArmorCodexScriptable natocodex in natoERA)
            {
                shittytandem.Add(Util.CreateArmourOptimization(natocodex, 0.2f));
            }

            foreach (ArmorCodexScriptable heavycodex in RUHeavy)
            {
                shittytandem.Add(Util.CreateArmourOptimization(heavycodex, 0.4f));
            }
            ///


            ammo_3bk29.ArmorOptimizations = tandem.ToArray();

            ammo_pg15vnt.ArmorOptimizations = shittytandem.ToArray();
            yield break;
        }
    }
}