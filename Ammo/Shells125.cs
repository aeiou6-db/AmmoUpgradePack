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
    public class Shells125 : ModUtil.Module
    {
        public static AmmoClipCodexScriptable clip_codex_3bm42;
        public static AmmoType.AmmoClip clip_3bm42;
        public static AmmoCodexScriptable ammo_codex_3bm42;
        public static AmmoType ammo_3bm42;
        public static GameObject ammo_3bm42_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bm46;
        public static AmmoType.AmmoClip clip_3bm46;
        public static AmmoCodexScriptable ammo_codex_3bm46;
        public static AmmoType ammo_3bm46;
        public static GameObject ammo_3bm46_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bm44;
        public static AmmoType.AmmoClip clip_3bm44;
        public static AmmoCodexScriptable ammo_codex_3bm44;
        public static AmmoType ammo_3bm44;
        public static GameObject ammo_3bm44_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bm59;
        public static AmmoType.AmmoClip clip_3bm59;
        public static AmmoCodexScriptable ammo_codex_3bm59;
        public static AmmoType ammo_3bm59;
        public static GameObject ammo_3bm59_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bm60;
        public static AmmoType.AmmoClip clip_3bm60;
        public static AmmoCodexScriptable ammo_codex_3bm60;
        public static AmmoType ammo_3bm60;
        public static GameObject ammo_3bm60_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bk29;
        public static AmmoType.AmmoClip clip_3bk29;
        public static AmmoCodexScriptable ammo_codex_3bk29;
        public static AmmoType ammo_3bk29;
        public static GameObject ammo_3bk29_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bk29M;
        public static AmmoType.AmmoClip clip_3bk29M;
        public static AmmoCodexScriptable ammo_codex_3bk29M;
        public static AmmoType ammo_3bk29M;
        public static GameObject ammo_3bk29M_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bk31;
        public static AmmoType.AmmoClip clip_3bk31;
        public static AmmoCodexScriptable ammo_codex_3bk31;
        public static AmmoType ammo_3bk31;
        public static GameObject ammo_3bk31_vis = null;


        public override void UnloadDynamicAssets()
        {
            GameObject.DestroyImmediate(ammo_3bm59_vis);
            GameObject.DestroyImmediate(ammo_3bk29_vis);
        }
        public override void LoadDynamicAssets()
        {
            // actual shells //
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ///125mm AP //
            //////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bm42 = new AmmoType();
            Util.ShallowCopy(ammo_3bm42, SharedAssets.ammo_3bm32);
            ammo_3bm42.Name = "3BM42 APFSDS-T";
            ammo_3bm42.Coeff = 0.152f;
            ammo_3bm42.Caliber = 125;
            ammo_3bm42.RhaPenetration = 530f;
            ammo_3bm42.Mass = 4.85f;
            ammo_3bm42.MuzzleVelocity = 1700f;
            ammo_3bm42.MaxSpallRha = 24f;
            ammo_3bm42.MinSpallRha = 6f;
            ammo_3bm42.SpallMultiplier = 0.9f;

            Util.Coalesce(ref ammo_codex_3bm42);
            ammo_codex_3bm42.AmmoType = ammo_3bm42;
            ammo_codex_3bm42.name = "ammo_3bm42";

            clip_3bm42 = new AmmoType.AmmoClip();
            clip_3bm42.Capacity = 1;
            clip_3bm42.Name = "3BM42 APFSDS-T";
            clip_3bm42.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bm42.MinimalPattern[0] = ammo_codex_3bm42;

            Util.Coalesce(ref clip_codex_3bm42);
            clip_codex_3bm42.name = "clip_3bm42";
            clip_codex_3bm42.ClipType = clip_3bm42;

            ammo_3bm42_vis = GameObject.Instantiate(SharedAssets.ammo_3bm32.VisualModel);
            ammo_3bm42_vis.name = "3bm42 visual";
            ammo_3bm42.VisualModel = ammo_3bm42_vis;
            ammo_3bm42.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bm42;
            ammo_3bm42.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bm42;

            ////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bm44 = new AmmoType();
            Util.ShallowCopy(ammo_3bm44, SharedAssets.ammo_3bm32);
            ammo_3bm44.Name = "3BM42M APFSDS-T";
            ammo_3bm44.Coeff = 0.152f;
            ammo_3bm44.Caliber = 125;
            ammo_3bm44.RhaPenetration = 680f;
            ammo_3bm44.Mass = 4.85f;
            ammo_3bm44.MuzzleVelocity = 1700f;
            ammo_3bm44.MaxSpallRha = 24f;
            ammo_3bm44.MinSpallRha = 6f;

            Util.Coalesce(ref ammo_codex_3bm44);
            ammo_codex_3bm44.AmmoType = ammo_3bm44;
            ammo_codex_3bm44.name = "ammo_3bm44";

            clip_3bm44 = new AmmoType.AmmoClip();
            clip_3bm44.Capacity = 1;
            clip_3bm44.Name = "3BM42M APFSDS-T";
            clip_3bm44.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bm44.MinimalPattern[0] = ammo_codex_3bm44;

            Util.Coalesce(ref clip_codex_3bm44);
            clip_codex_3bm44.name = "clip_3bm44";
            clip_codex_3bm44.ClipType = clip_3bm44;

            ammo_3bm44_vis = GameObject.Instantiate(SharedAssets.ammo_3bm32.VisualModel);
            ammo_3bm44_vis.name = "3bm44 visual";
            ammo_3bm44.VisualModel = ammo_3bm44_vis;
            ammo_3bm44.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bm44;
            ammo_3bm44.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bm44;

            ////////////////////////////////////////////////////////////////////////////////////////////////

            ammo_3bm46 = new AmmoType();
            Util.ShallowCopy(ammo_3bm46, SharedAssets.ammo_3bm32);
            ammo_3bm46.Name = "3BM46 APFSDS-T";
            ammo_3bm46.Caliber = 125;
            ammo_3bm46.RhaPenetration = 660f;
            ammo_3bm46.Mass = 4.85f;
            ammo_3bm46.MuzzleVelocity = 1700f;
            ammo_3bm46.SpallMultiplier = 1.25f;
            ammo_3bm46.MaxSpallRha = 24f;
            ammo_3bm46.MinSpallRha = 6f;

            Util.Coalesce(ref ammo_codex_3bm46);
            ammo_codex_3bm46.AmmoType = ammo_3bm46;
            ammo_codex_3bm46.name = "ammo_3bm46";

            clip_3bm46 = new AmmoType.AmmoClip();
            clip_3bm46.Capacity = 1;
            clip_3bm46.Name = "3BM46 APFSDS-T";
            clip_3bm46.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bm46.MinimalPattern[0] = ammo_codex_3bm46;

            Util.Coalesce(ref clip_codex_3bm46);
            clip_codex_3bm46.name = "clip_3bm46";
            clip_codex_3bm46.ClipType = clip_3bm46;

            ammo_3bm46_vis = GameObject.Instantiate(SharedAssets.ammo_3bm32.VisualModel);
            ammo_3bm46_vis.name = "3bm46 visual";
            ammo_3bm46.VisualModel = ammo_3bm46_vis;
            ammo_3bm46.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bm46;
            ammo_3bm46.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bm46;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bm59 = new AmmoType();
            Util.ShallowCopy(ammo_3bm59, SharedAssets.ammo_3bm32);
            ammo_3bm59.Name = "3BM59 APFSDS-T";
            ammo_3bm59.Caliber = 125;
            ammo_3bm59.RhaPenetration = 800f;
            ammo_3bm59.Mass = 4.53f;
            ammo_3bm59.MuzzleVelocity = 1610f;
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
            ammo_3bm60 = new AmmoType();
            Util.ShallowCopy(ammo_3bm60, SharedAssets.ammo_3bm32);
            ammo_3bm60.Name = "3BM60 APFSDS-T";
            ammo_3bm60.Caliber = 125;
            ammo_3bm60.RhaPenetration = 780f;
            ammo_3bm60.Mass = 4.35f;
            ammo_3bm60.MuzzleVelocity = 1660f;
            ammo_3bm60.SpallMultiplier = 1.25f;
            ammo_3bm60.MaxSpallRha = 24f;
            ammo_3bm60.MinSpallRha = 6f;

            Util.Coalesce(ref ammo_codex_3bm60);
            ammo_codex_3bm60.AmmoType = ammo_3bm60;
            ammo_codex_3bm60.name = "ammo_3bm60";

            clip_3bm60 = new AmmoType.AmmoClip();
            clip_3bm60.Capacity = 1;
            clip_3bm60.Name = "3BM60 APFSDS-T";
            clip_3bm60.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bm60.MinimalPattern[0] = ammo_codex_3bm60;

            Util.Coalesce(ref clip_codex_3bm60);
            clip_codex_3bm60.name = "clip_3bm60";
            clip_codex_3bm60.ClipType = clip_3bm60;

            ammo_3bm60_vis = GameObject.Instantiate(SharedAssets.ammo_3bm32.VisualModel);
            ammo_3bm60_vis.name = "3bm60 visual";
            ammo_3bm60.VisualModel = ammo_3bm60_vis;
            ammo_3bm60.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bm60;
            ammo_3bm60.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bm60;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ///HEAT ///
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
            ammo_3bk29M = new AmmoType();
            Util.ShallowCopy(ammo_3bk29M, SharedAssets.ammo_3bk18m);
            ammo_3bk29M.Name = "3BK29M HEAT-FS-T";
            ammo_3bk29M.RhaPenetration = 730;
            ammo_3bk29M.Caliber = 125;
            ammo_3bk29M.MuzzleVelocity = 915;
            ammo_3bk29M.ForcedSpallAngle = 90;
            ammo_3bk29M.MaxSpallRha = 24;
            ammo_3bk29M.MinSpallRha = 1;
            ammo_3bk29M.SpallMultiplier = 1.85f;

            Util.Coalesce(ref ammo_codex_3bk29M);
            ammo_codex_3bk29M.AmmoType = ammo_3bk29M;
            ammo_codex_3bk29M.name = "ammo_3BK29M";

            clip_3bk29M = new AmmoType.AmmoClip();
            clip_3bk29M.Capacity = 1;
            clip_3bk29M.Name = "3BK29M HEAT-FS-T";
            clip_3bk29M.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bk29M.MinimalPattern[0] = ammo_codex_3bk29M;

            Util.Coalesce(ref clip_codex_3bk29M);
            clip_codex_3bk29M.name = "clip_3BK29M";
            clip_codex_3bk29M.ClipType = clip_3bk29M;

            ammo_3bk29M_vis = GameObject.Instantiate(SharedAssets.ammo_3bk18m.VisualModel);
            ammo_3bk29M_vis.name = "3BK29M visual";
            ammo_3bk29M.VisualModel = ammo_3bk29M_vis;
            ammo_3bk29M.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bk29M;
            ammo_3bk29M.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bk29M;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bk31 = new AmmoType();
            Util.ShallowCopy(ammo_3bk31, SharedAssets.ammo_3bk18m);
            ammo_3bk31.Name = "3BK31 HEAT-FS-T";
            ammo_3bk31.RhaPenetration = 800;
            ammo_3bk31.Caliber = 125;
            ammo_3bk31.MuzzleVelocity = 915;
            ammo_3bk31.ForcedSpallAngle = 90;
            ammo_3bk31.MaxSpallRha = 24;
            ammo_3bk31.MinSpallRha = 1;
            ammo_3bk31.SpallMultiplier = 1.85f;

            Util.Coalesce(ref ammo_codex_3bk31);
            ammo_codex_3bk31.AmmoType = ammo_3bk31;
            ammo_codex_3bk31.name = "ammo_3BK31";

            clip_3bk31 = new AmmoType.AmmoClip();
            clip_3bk31.Capacity = 1;
            clip_3bk31.Name = "3BK31 HEAT-FS-T";
            clip_3bk31.MinimalPattern = new AmmoCodexScriptable[1];
            clip_3bk31.MinimalPattern[0] = ammo_codex_3bk31;

            Util.Coalesce(ref clip_codex_3bk31);
            clip_codex_3bk31.name = "clip_3BK31";
            clip_codex_3bk31.ClipType = clip_3bk31;

            ammo_3bk31_vis = GameObject.Instantiate(SharedAssets.ammo_3bk18m.VisualModel);
            ammo_3bk31_vis.name = "3BK31 visual";
            ammo_3bk31.VisualModel = ammo_3bk31_vis;
            ammo_3bk31.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bk31;
            ammo_3bk31.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bk31;
            ////////////////////////////////////////////////////////////////////////////////////////////////
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

            ArmorCodexScriptable[] composites = armor_codices.Where(
                o =>
                o.name.Contains("C-Tech composite") ||
                o.name.Contains("Vorschlaghammer composite") ||
                o.name.Contains("Eber composite") ||
                o.name.Contains("Abrams special armor gen 1 hull front") ||
                o.name.Contains("Abrams special armor gen 1 mantlet") ||
                o.name.Contains("Abrams special armor gen 1 turret cheeks") ||
                o.name.Contains("Abrams special armor gen 1 turret sides") ||
                o.name.Contains("Abrams special armor gen 0 turret cheeks") ||
                o.name.Contains("Corundum ball armor") ||
                o.name.Contains("ru metal polymer") ||
                o.name.Contains("t80u ru composite") ||
                o.name.Contains("ru composite") ||
                o.name.Contains("B tech") ||
                o.name.Contains("Abrams DU composite") ||
                o.name.Contains("Kvartz") 
                ).ToArray();

            ///
            List<AmmoType.ArmorOptimization> tandem = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable lightcodex in lightERA)
            {
                tandem.Add(Util.CreateArmourOptimization(lightcodex, 0.05f));
            }

            foreach (ArmorCodexScriptable natocodex in natoERA)
            {
                tandem.Add(Util.CreateArmourOptimization(natocodex, 0.25f));
            }

            foreach (ArmorCodexScriptable heavycodex in RUHeavy)
            {
                tandem.Add(Util.CreateArmourOptimization(heavycodex, 0.4f));
            }
            ///
            List<AmmoType.ArmorOptimization> bk31 = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable lightcodex in lightERA)
            {
                bk31.Add(Util.CreateArmourOptimization(lightcodex, 0.01f));
            }

            foreach (ArmorCodexScriptable natocodex in natoERA)
            {
                bk31.Add(Util.CreateArmourOptimization(natocodex, 0.1f));
            }

            foreach (ArmorCodexScriptable heavycodex in RUHeavy)
            {
                bk31.Add(Util.CreateArmourOptimization(heavycodex, 0.2f));
            }
            foreach (ArmorCodexScriptable comp in composites)
            {
                bk31.Add(Util.CreateArmourOptimization(comp, 0.9f));
            }

            // for shitty tandem rounds
            List<AmmoType.ArmorOptimization> shittytandem = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable lightcodex in lightERA)
            {
                shittytandem.Add(Util.CreateArmourOptimization(lightcodex, 0.1f));
            }

            foreach (ArmorCodexScriptable natocodex in natoERA)
            {
                shittytandem.Add(Util.CreateArmourOptimization(natocodex, 0.4f));
            }

            foreach (ArmorCodexScriptable heavycodex in RUHeavy)
            {
                shittytandem.Add(Util.CreateArmourOptimization(heavycodex, 0.6f));
            }
            //// composite optimization //
            List<AmmoType.ArmorOptimization> anticomp0 = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable compcodex in composites)
            {
                anticomp0.Add(Util.CreateArmourOptimization(compcodex, 0.85f));
            }
            List<AmmoType.ArmorOptimization> anticomp1 = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable compcodex in composites)
            {
                anticomp1.Add(Util.CreateArmourOptimization(compcodex, 0.8f));
            }
            ///
            List<AmmoType.ArmorOptimization> anticomp2 = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable compcodex in composites)
            {
                anticomp2.Add(Util.CreateArmourOptimization(compcodex, 0.6f));
            }
            ///
            List<AmmoType.ArmorOptimization> anticomp3 = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable compcodex in composites)
            {
                anticomp3.Add(Util.CreateArmourOptimization(compcodex, 0.5f));
            }
            ///

            ammo_3bm42.ArmorOptimizations = anticomp1.ToArray();
            ammo_3bm44.ArmorOptimizations = anticomp2.ToArray();
            ammo_3bm59.ArmorOptimizations = anticomp3.ToArray();
            ///
            ammo_3bk29.ArmorOptimizations = tandem.ToArray();
            ammo_3bk29M.ArmorOptimizations = tandem.ToArray();
            ammo_3bk31.ArmorOptimizations = bk31.ToArray();
            yield break;
        }
    }
}