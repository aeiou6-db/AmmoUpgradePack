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
    public class ATGMPact : ModUtil.Module
    {
        public static AmmoClipCodexScriptable clip_codex_konkursM;
        public static AmmoType.AmmoClip clip_konkursM;
        public static AmmoCodexScriptable ammo_codex_konkursM;
        public static AmmoType ammo_konkursM;
        public static GameObject ammo_konkursM_vis = null;

        public static AmmoClipCodexScriptable clip_codex_konkurs;
        public static AmmoType.AmmoClip clip_konkurs;
        public static AmmoCodexScriptable ammo_codex_konkurs;
        public static AmmoType ammo_konkurs;
        public static GameObject ammo_konkurs_vis = null;

        public static AmmoClipCodexScriptable clip_codex_9M111M;
        public static AmmoType.AmmoClip clip_9M111M;
        public static AmmoCodexScriptable ammo_codex_9M111M;
        public static AmmoType ammo_9M111M;
        public static GameObject ammo_9M111M_vis = null;

        public static AmmoClipCodexScriptable clip_codex_9M14P;
        public static AmmoType.AmmoClip clip_9M14P;
        public static AmmoCodexScriptable ammo_codex_9M14P;
        public static AmmoType ammo_9M14P;
        public static GameObject ammo_9M14P_vis = null;

        public static AmmoClipCodexScriptable clip_codex_9M142;
        public static AmmoType.AmmoClip clip_9M142;
        public static AmmoCodexScriptable ammo_codex_9M142;
        public static AmmoType ammo_9M142;
        public static GameObject ammo_9M142_vis = null;

        public static AmmoClipCodexScriptable clip_codex_9M142M;
        public static AmmoType.AmmoClip clip_9M142M;
        public static AmmoCodexScriptable ammo_codex_9M142M;
        public static AmmoType ammo_9M142M;
        public static GameObject ammo_9M142M_vis = null;

        public static AmmoClipCodexScriptable clip_codex_9m133M;
        public static AmmoType.AmmoClip clip_9m133M;
        public static AmmoCodexScriptable ammo_codex_9m133M;
        public static AmmoType ammo_9m133M;
        public static GameObject ammo_9m133M_vis = null;


        public override void UnloadDynamicAssets()
        {
            GameObject.DestroyImmediate(ammo_9M14P_vis);
            GameObject.DestroyImmediate(ammo_9M142_vis);
            GameObject.DestroyImmediate(ammo_9M142M_vis);
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
            ammo_konkursM.ArmorOptimizations = tandem.ToArray();
            ammo_9m133M.ArmorOptimizations = tandem.ToArray();

            ammo_9M142M.ArmorOptimizations = shittytandem.ToArray();
            yield break;
        }
        public override void LoadDynamicAssets()
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////
            /// ATGMS ///
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_9M111M = new AmmoType();
            Util.ShallowCopy(ammo_9M111M, SharedAssets.ammo_fagot);
            ammo_9M111M.Name = "9M111M Fagot-M";
            ammo_9M111M.Category = AmmoType.AmmoCategory.ShapedCharge;
            ammo_9M111M.RhaPenetration = 500;
            ammo_9M111M.TerrainImpactEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HE Terrain Impact").First();
            ammo_9M111M.DetonateEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HEAT_explosion_large").First();
            ammo_9M111M.ShotVisual = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "9M111 visual new").First();

            Util.Coalesce(ref ammo_codex_9M111M);
            ammo_codex_9M111M.AmmoType = ammo_9M111M;
            ammo_codex_9M111M.name = "ammo_9M111M";

            clip_9M111M = new AmmoType.AmmoClip();
            clip_9M111M.Capacity = 1;
            clip_9M111M.Name = "9M111M Fagot-M";
            clip_9M111M.MinimalPattern = new AmmoCodexScriptable[1];
            clip_9M111M.MinimalPattern[0] = ammo_codex_9M111M;

            Util.Coalesce(ref clip_codex_9M111M);
            clip_codex_9M111M.name = "clip_9M111M";
            clip_codex_9M111M.ClipType = clip_9M111M;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_9M14P = new AmmoType();
            Util.ShallowCopy(ammo_9M14P, SharedAssets.ammo_malyutka);
            ammo_9M14P.Name = "9M14P Malyutka-P";
            ammo_9M14P.Category = AmmoType.AmmoCategory.ShapedCharge;
            ammo_9M14P.Guidance = AmmoType.GuidanceType.SACLOS;
            ammo_9M14P.NoisePowerX = 60;
            ammo_9M14P.NoisePowerY = 60;

            Util.Coalesce(ref ammo_codex_9M14P);
            ammo_codex_9M14P.AmmoType = ammo_9M14P;
            ammo_codex_9M14P.name = "ammo_9M14P";

            clip_9M14P = new AmmoType.AmmoClip();
            clip_9M14P.Capacity = 1;
            clip_9M14P.Name = "9M14P Malyutka-P";
            clip_9M14P.MinimalPattern = new AmmoCodexScriptable[1];
            clip_9M14P.MinimalPattern[0] = ammo_codex_9M14P;

            Util.Coalesce(ref clip_codex_9M14P);
            clip_codex_9M14P.name = "clip_9M14P";
            clip_codex_9M14P.ClipType = clip_9M14P;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_9M142 = new AmmoType();
            Util.ShallowCopy(ammo_9M142, SharedAssets.ammo_malyutka);
            ammo_9M142.Name = "9M14-2 Malyutka-2";
            ammo_9M142.Category = AmmoType.AmmoCategory.ShapedCharge;
            ammo_9M142.Guidance = AmmoType.GuidanceType.SACLOS;
            ammo_9M142.NoisePowerX = 45;
            ammo_9M142.NoisePowerY = 45;
            ammo_9M142.RhaPenetration = 580;

            Util.Coalesce(ref ammo_codex_9M142);
            ammo_codex_9M142.AmmoType = ammo_9M142;
            ammo_codex_9M142.name = "ammo_9M142";

            clip_9M142 = new AmmoType.AmmoClip();
            clip_9M142.Capacity = 1;
            clip_9M142.Name = "9M14-2 Malyutka-2";
            clip_9M142.MinimalPattern = new AmmoCodexScriptable[1];
            clip_9M142.MinimalPattern[0] = ammo_codex_9M142;

            Util.Coalesce(ref clip_codex_9M142);
            clip_codex_9M142.name = "clip_9M142";
            clip_codex_9M142.ClipType = clip_9M142;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_9M142M = new AmmoType();
            Util.ShallowCopy(ammo_9M142M, SharedAssets.ammo_malyutka);
            ammo_9M142M.Name = "9M14-2M Malyutka-2M";
            ammo_9M142M.Category = AmmoType.AmmoCategory.ShapedCharge;
            ammo_9M142M.Guidance = AmmoType.GuidanceType.SACLOS;
            ammo_9M142M.NoisePowerX = 45;
            ammo_9M142M.NoisePowerY = 45;
            ammo_9M142M.RhaPenetration = 600;

            Util.Coalesce(ref ammo_codex_9M142M);
            ammo_codex_9M142M.AmmoType = ammo_9M142M;
            ammo_codex_9M142M.name = "ammo_9M142M";

            clip_9M142M = new AmmoType.AmmoClip();
            clip_9M142M.Capacity = 1;
            clip_9M142M.Name = "9M14-2M Malyutka-2M";
            clip_9M142M.MinimalPattern = new AmmoCodexScriptable[1];
            clip_9M142M.MinimalPattern[0] = ammo_codex_9M142M;

            Util.Coalesce(ref clip_codex_9M142M);
            clip_codex_9M142M.name = "clip_9M142M";
            clip_codex_9M142M.ClipType = clip_9M142M;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_konkursM = new AmmoType();
            Util.ShallowCopy(ammo_konkursM, SharedAssets.ammo_konkurs);
            ammo_konkursM.Name = "9M113M Konkurs-M";
            ammo_konkursM.Category = AmmoType.AmmoCategory.ShapedCharge;
            ammo_konkursM.RhaPenetration = 850;
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
            ammo_konkurs = new AmmoType();
            // this is just a vanilla konkurs
            Util.ShallowCopy(ammo_konkurs, SharedAssets.ammo_konkurs);
            ammo_konkurs.TerrainImpactEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HE Terrain Impact").First();
            ammo_konkurs.DetonateEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HEAT_explosion_large").First();
            ammo_konkurs.ShotVisual = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "9M111 visual new").First();

            Util.Coalesce(ref ammo_codex_konkurs);
            ammo_codex_konkurs.AmmoType = ammo_konkurs;
            ammo_codex_konkurs.name = "ammo_konkurs";

            clip_konkurs = new AmmoType.AmmoClip();
            clip_konkurs.Capacity = 1;
            clip_konkurs.Name = "9M113 Konkurs";
            clip_konkurs.MinimalPattern = new AmmoCodexScriptable[1];
            clip_konkurs.MinimalPattern[0] = ammo_codex_konkurs;

            Util.Coalesce(ref clip_codex_konkurs);
            clip_codex_konkurs.name = "clip_konkurs";
            clip_codex_konkurs.ClipType = clip_konkurs;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_9m133M = new AmmoType();
            Util.ShallowCopy(ammo_9m133M, SharedAssets.ammo_konkurs);
            ammo_9m133M.Name = "9M133M Kornet-M";
            ammo_9m133M.Category = AmmoType.AmmoCategory.ShapedCharge;
            ammo_9m133M.RhaPenetration = 1350f;
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
            clip_9m133M.MinimalPattern = new AmmoCodexScriptable[1];
            clip_9m133M.MinimalPattern[0] = ammo_codex_9m133M;

            Util.Coalesce(ref clip_codex_9m133M);
            clip_codex_9m133M.name = "clip_9m133M";
            clip_codex_9m133M.ClipType = clip_9m133M;
            ////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}