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
        public static AmmoClipCodexScriptable clip_codex_konkursM;
        public static AmmoType.AmmoClip clip_konkursM;
        public static AmmoCodexScriptable ammo_codex_konkursM;
        public static AmmoType ammo_konkursM;
        public static GameObject ammo_konkursM_vis = null;

        public static AmmoClipCodexScriptable clip_codex_9m133M;
        public static AmmoType.AmmoClip clip_9m133M;
        public static AmmoCodexScriptable ammo_codex_9m133M;
        public static AmmoType ammo_9m133M;
        public static GameObject ammo_9m133M_vis = null;

        public static AmmoClipCodexScriptable clip_codex_3bm36;
        public static AmmoType.AmmoClip clip_3bm36;
        public static AmmoCodexScriptable ammo_codex_3bm36;
        public static AmmoType ammo_3bm36;
        public static GameObject ammo_3bm36_vis = null;

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

        public override void UnloadDynamicAssets()
        {
            GameObject.DestroyImmediate(ammo_3bm59_vis);
            GameObject.DestroyImmediate(ammo_3bm36_vis);
            GameObject.DestroyImmediate(ammo_3bk29_vis);
            GameObject.DestroyImmediate(ammo_konkursM_vis);
            GameObject.DestroyImmediate(ammo_9m133M_vis);
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
           

            ammo_3bk29.ArmorOptimizations = tandem.ToArray();
            ammo_konkursM.ArmorOptimizations = tandem.ToArray();
            ammo_9m133M.ArmorOptimizations = tandem.ToArray();
            yield break;
        }
        public override void LoadDynamicAssets()
        {
            // actual shells //
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ///115mm Shells
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
            ///125mm Shells //
            //////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bm59 = new AmmoType();
            Util.ShallowCopy(ammo_3bm59, SharedAssetz.ammo_3bm32);
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

            ammo_3bm59_vis = GameObject.Instantiate(SharedAssetz.ammo_3bm32.VisualModel);
            ammo_3bm59_vis.name = "3bm59 visual";
            ammo_3bm59.VisualModel = ammo_3bm59_vis;
            ammo_3bm59.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bm59;
            ammo_3bm59.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bm59;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_3bk29 = new AmmoType();
            Util.ShallowCopy(ammo_3bk29, SharedAssetz.ammo_3bk18m);
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

            ammo_3bk29_vis = GameObject.Instantiate(SharedAssetz.ammo_3bk18m.VisualModel);
            ammo_3bk29_vis.name = "3BK29 visual";
            ammo_3bk29.VisualModel = ammo_3bk29_vis;
            ammo_3bk29.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_3bk29;
            ammo_3bk29.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_3bk29;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            /// ATGMS ///
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_konkursM = new AmmoType();
            Util.ShallowCopy(ammo_konkursM, SharedAssetz.ammo_konkurs);
            ammo_konkursM.Name = "9M113M Konkurs-M";
            ammo_konkursM.Category = AmmoType.AmmoCategory.ShapedCharge;
            ammo_konkursM.RhaPenetration = 900;
            ammo_konkursM.MuzzleVelocity = 206;
            ammo_konkursM.Caliber = 135;
            ammo_konkursM.RangedFuseTime = 12f;
            ammo_konkursM.ImpactFuseTime = 0;
            ammo_konkursM.RhaToFuse = 0;
            ammo_konkursM.Mass = 16.5f;
            ammo_konkursM.TntEquivalentKg = 4.75f;
            ammo_konkursM.ForcedSpallAngle = 80;
            ammo_konkursM.TerrainImpactEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HE Terrain Impact").First();
            ammo_konkursM.DetonateEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HEAT_explosion_large").First();
            ammo_konkursM.ShotVisual = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "9M111 visual new").First();

            Util.Coalesce(ref ammo_codex_konkursM);
            ammo_codex_konkursM.AmmoType = ammo_konkursM;
            ammo_codex_konkursM.name = "ammo_9M113M";

            clip_konkursM = new AmmoType.AmmoClip();
            clip_konkursM.Capacity = 1;
            clip_konkursM.Name = "9M113M Konkurs-M";
            clip_konkursM.MinimalPattern = new AmmoCodexScriptable[1];
            clip_konkursM.MinimalPattern[0] = ammo_codex_konkursM;

            Util.Coalesce(ref clip_codex_konkursM);
            clip_codex_konkursM.name = "clip_9M113M";
            clip_codex_konkursM.ClipType = clip_konkursM;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_9m133M = new AmmoType();
            Util.ShallowCopy(ammo_9m133M, SharedAssetz.ammo_konkurs);
            ammo_9m133M.Name = "9M133M Kornet-M";
            ammo_9m133M.Category = AmmoType.AmmoCategory.ShapedCharge;
            ammo_9m133M.RhaPenetration = 1500f;
            ammo_9m133M.MuzzleVelocity = 350f;
            ammo_9m133M.SpiralPower = 20f;
            ammo_9m133M.TntEquivalentKg = 6.5f;
            ammo_9m133M.SpallMultiplier = 2.3f;
            ammo_9m133M._radius = 0.076f;
            ammo_9m133M.TurnSpeed = 4f;
            ammo_9m133M.SectionalArea = 0.018146f;
            ammo_9m133M.Guidance = AmmoType.GuidanceType.Laser;
            ammo_9m133M.TerrainImpactEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HE Terrain Impact").First();
            ammo_9m133M.DetonateEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HEAT_explosion_large").First();
            ammo_9m133M.ShotVisual = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "9M111 visual new").First();

            Util.Coalesce(ref ammo_codex_9m133M);
            ammo_codex_9m133M.AmmoType = ammo_9m133M;
            ammo_codex_9m133M.name = "ammo_9m133M";

            clip_9m133M = new AmmoType.AmmoClip();
            clip_9m133M.Capacity = 4;
            clip_9m133M.Name = "9M133M Kornet-M";
            clip_9m133M.MinimalPattern = new AmmoCodexScriptable[] { ammo_codex_9m133M };
            clip_9m133M.MinimalPattern[0] = ammo_codex_9m133M;

            Util.Coalesce(ref ammo_codex_9m133M);
            ammo_codex_9m133M.name = "clip_9m133M";
            clip_codex_9m133M.ClipType = clip_9m133M;
            ////////////////////////////////////////////////////////////////////////////////////////////////

        }
    }
}
