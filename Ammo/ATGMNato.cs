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
    public class ATGMNato : ModUtil.Module
    {
        public static AmmoClipCodexScriptable clip_codex_milan2;
        public static AmmoType.AmmoClip clip_milan2;
        public static AmmoCodexScriptable ammo_codex_milan2;
        public static AmmoType ammo_milan2;
        public static GameObject ammo_milan2_vis = null;

        public static AmmoClipCodexScriptable clip_codex_milan3;
        public static AmmoType.AmmoClip clip_milan3;
        public static AmmoCodexScriptable ammo_codex_milan3;
        public static AmmoType ammo_milan3;
        public static GameObject ammo_milan3_vis = null;

        public static AmmoClipCodexScriptable clip_codex_milan3ER;
        public static AmmoType.AmmoClip clip_milan3ER;
        public static AmmoCodexScriptable ammo_codex_milan3ER;
        public static AmmoType ammo_milan3ER;
        public static GameObject ammo_milan3ER_vis = null;

        public static AmmoClipCodexScriptable clip_codex_tow2;
        public static AmmoType.AmmoClip clip_tow2;
        public static AmmoCodexScriptable ammo_codex_tow2;
        public static AmmoType ammo_tow2;
        public static GameObject ammo_tow2_vis = null;

        public static AmmoClipCodexScriptable clip_codex_tow2a;
        public static AmmoType.AmmoClip clip_tow2a;
        public static AmmoCodexScriptable ammo_codex_tow2a;
        public static AmmoType ammo_tow2a;
        public static GameObject ammo_tow2a_vis = null;

        public static AmmoClipCodexScriptable clip_codex_itow;
        public static AmmoType.AmmoClip clip_itow;
        public static AmmoCodexScriptable ammo_codex_itow;
        public static AmmoType ammo_itow;
        public static GameObject ammo_itow_vis = null;

        public override void UnloadDynamicAssets()
        {
            GameObject.DestroyImmediate(ammo_milan2_vis);
            GameObject.DestroyImmediate(ammo_milan3_vis);
            GameObject.DestroyImmediate(ammo_milan3ER_vis);
            GameObject.DestroyImmediate(ammo_tow2_vis);
            GameObject.DestroyImmediate(ammo_tow2a_vis);
            GameObject.DestroyImmediate(ammo_itow_vis);
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

            // example.ArmorOptimizations = tandem.ToArray();
            ammo_milan3.ArmorOptimizations = tandem.ToArray();
            ammo_milan3ER.ArmorOptimizations = tandem.ToArray();
            ammo_tow2a.ArmorOptimizations = tandem.ToArray();
            yield break;
        }
        public override void LoadDynamicAssets()
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            /// ATGMS //
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ammo_milan2 = new AmmoType();
            Util.ShallowCopy(ammo_milan2, SharedAssets.ammo_milan);
            ammo_milan2.Name = "MILAN-2";
            ammo_milan2.RhaPenetration = 750;
            ammo_milan2.TurnSpeed = 0.18f;
            ammo_milan2.MuzzleVelocity = 185f;
            ammo_milan2.TntEquivalentKg = 2.3f;
            ammo_milan2.NoisePowerX = 35;
            ammo_milan2.NoisePowerY = 35;
            ammo_milan2.TerrainImpactEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HE Terrain Impact").First();
            ammo_milan2.DetonateEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HEAT_explosion_large").First();
            ammo_milan2.ShotVisual = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "MILAN 1 visual").First();
            Util.Coalesce(ref ammo_codex_milan2);
            ammo_codex_milan2.AmmoType = ammo_milan2;
            ammo_codex_milan2.name = "ammo_MILAN2";

            clip_milan2 = new AmmoType.AmmoClip();
            clip_milan2.Capacity = 1;
            clip_milan2.Name = "MILAN-2";
            clip_milan2.MinimalPattern = new AmmoCodexScriptable[1];
            clip_milan2.MinimalPattern[0] = ammo_codex_milan2;

            Util.Coalesce(ref clip_codex_milan2);
            clip_codex_milan2.name = "clip_MILAN2";
            clip_codex_milan2.ClipType = clip_milan2;
            /////////////////////////////////////////////////////////////////////////////////////////
            ammo_milan3 = new AmmoType();
            Util.ShallowCopy(ammo_milan3, ammo_milan2);
            ammo_milan3.Name = "MILAN-3";
            ammo_milan3.RhaPenetration = 850;
            ammo_milan3.TurnSpeed = 0.15f;
            ammo_milan3.TntEquivalentKg = 1.87f;
            ammo_milan3.TerrainImpactEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HE Terrain Impact").First();
            ammo_milan3.DetonateEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HEAT_explosion_large").First();
            ammo_milan3.ShotVisual = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "MILAN 1 visual").First();
            Util.Coalesce(ref ammo_codex_milan3);
            ammo_codex_milan3.AmmoType = ammo_milan3;
            ammo_codex_milan3.name = "ammo_MILAN3";

            clip_milan3 = new AmmoType.AmmoClip();
            clip_milan3.Capacity = 1;
            clip_milan3.Name = "MILAN-3";
            clip_milan3.MinimalPattern = new AmmoCodexScriptable[1];
            clip_milan3.MinimalPattern[0] = ammo_codex_milan3;

            Util.Coalesce(ref clip_codex_milan3);
            clip_codex_milan3.name = "clip_MILAN3";
            clip_codex_milan3.ClipType = clip_milan3;
            /////////////////////////////////////////////////////////////////////////////////////////
            ammo_milan3ER = new AmmoType();
            Util.ShallowCopy(ammo_milan3ER, ammo_milan3);
            ammo_milan3ER.Name = "MILAN-3ER";
            ammo_milan3ER.RhaPenetration = 1000;
            ammo_milan3ER.TurnSpeed = 0.1f;
            ammo_milan3ER.MaximumRange = 3000;
            ammo_milan3ER.TerrainImpactEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HE Terrain Impact").First();
            ammo_milan3ER.DetonateEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HEAT_explosion_large").First();
            ammo_milan3ER.ShotVisual = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "MILAN 1 visual").First();
            Util.Coalesce(ref ammo_codex_milan3ER);
            ammo_codex_milan3ER.AmmoType = ammo_milan3ER;
            ammo_codex_milan3ER.name = "ammo_MILAN3ER";

            clip_milan3ER = new AmmoType.AmmoClip();
            clip_milan3ER.Capacity = 1;
            clip_milan3ER.Name = "MILAN-3ER";
            clip_milan3ER.MinimalPattern = new AmmoCodexScriptable[1];
            clip_milan3ER.MinimalPattern[0] = ammo_codex_milan3ER;

            Util.Coalesce(ref clip_codex_milan3ER);
            clip_codex_milan3ER.name = "clip_MILAN3ER";
            clip_codex_milan3ER.ClipType = clip_milan3ER;
            /////////////////////////////////////////////////////////////////////////////////////////
            ammo_itow = new AmmoType();
            // this is identical to the stats of the vanilla ITOW, because the ITOW is a piece of shit that breaks on everything.
            Util.ShallowCopy(ammo_itow, SharedAssets.ammo_itow); 
            ammo_itow.ShotVisual = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "ITOW visual").First();
            ammo_itow.TerrainImpactEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HE Terrain Impact").First();
            ammo_itow.VisualModel = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "BGM-71C I-TOW visual placeholder").First();
            ammo_itow.VisualType = LiveRoundMarshaller.LiveRoundVisualType.Custom;
            Util.Coalesce(ref ammo_codex_itow);
            ammo_codex_itow.AmmoType = ammo_itow;
            ammo_codex_itow.name = "ammo_ITOW";

            clip_itow = new AmmoType.AmmoClip();
            clip_itow.Capacity = 1;
            clip_itow.Name = ammo_itow.Name;
            clip_itow.MinimalPattern = new AmmoCodexScriptable[1];
            clip_itow.MinimalPattern[0] = ammo_codex_itow;

            Util.Coalesce(ref clip_codex_itow);
            clip_codex_itow.name = "clip_ITOW";
            clip_codex_itow.ClipType = clip_itow;
            ////////////////////////////////////////////////////////////////////////
            ammo_tow2 = new AmmoType();
            Util.ShallowCopy(ammo_tow2, ammo_itow);
            ammo_tow2.Name = "BGM-71D TOW-2";
            ammo_tow2.RhaPenetration = 800f;
            ammo_tow2.MuzzleVelocity = 329f;
            ammo_tow2.TntEquivalentKg = 4.41f;
            ammo_tow2.SpallMultiplier = 2.5f;
            ammo_tow2.NoisePowerX = 30f;
            ammo_tow2.NoisePowerY = 30f;
            ammo_tow2.TurnSpeed = 0.18f;
            ammo_tow2.NoLeadCompensation = true;
            ammo_tow2.TerrainImpactEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HE Terrain Impact").First();
            ammo_tow2.DetonateEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HEAT_explosion_large").First();
            ammo_tow2.ShotVisual = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "ITOW visual").First();
            ammo_tow2.VisualModel = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "BGM-71C I-TOW visual placeholder").First();

            Util.Coalesce(ref ammo_codex_tow2);
            ammo_codex_tow2.AmmoType = ammo_tow2;
            ammo_codex_tow2.name = "ammo_TOW2";

            clip_tow2 = new AmmoType.AmmoClip();
            clip_tow2.Capacity = 1;
            clip_tow2.Name = "BGM-71D TOW-2";
            clip_tow2.MinimalPattern = new AmmoCodexScriptable[1];
            clip_tow2.MinimalPattern[0] = ammo_codex_tow2;

            Util.Coalesce(ref clip_codex_tow2);
            clip_codex_tow2.name = "clip_TOW2";
            clip_codex_tow2.ClipType = clip_tow2;
            ////////////////////////////////////////////////////////////////////////
            ammo_tow2a = new AmmoType();
            Util.ShallowCopy(ammo_tow2a, ammo_tow2);
            ammo_tow2a.Name = "BGM-71E TOW-2A";
            ammo_tow2a.RhaPenetration = 1000f;
            ammo_tow2a.TntEquivalentKg = 4.5f;
            ammo_tow2a.NoLeadCompensation = true;
            ammo_tow2a.TerrainImpactEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HE Terrain Impact").First();
            ammo_tow2a.DetonateEffect = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "HEAT_explosion_large").First();
            ammo_tow2a.ShotVisual = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "ITOW visual").First();
            ammo_tow2a.VisualModel = Resources.FindObjectsOfTypeAll<GameObject>().Where(o => o.name == "BGM-71C I-TOW visual placeholder").First();

            Util.Coalesce(ref ammo_codex_tow2a);
            ammo_codex_tow2a.AmmoType = ammo_tow2a;
            ammo_codex_tow2a.name = "ammo_TOW2A";

            clip_tow2a = new AmmoType.AmmoClip();
            clip_tow2a.Capacity = 1;
            clip_tow2a.Name = "BGM-71E TOW-2A";
            clip_tow2a.MinimalPattern = new AmmoCodexScriptable[1];
            clip_tow2a.MinimalPattern[0] = ammo_codex_tow2a;

            Util.Coalesce(ref clip_codex_tow2a);
            clip_codex_tow2a.name = "clip_TOW2A";
            clip_codex_tow2a.ClipType = clip_tow2a;
            ////////////////////////////////////////////////////////////////////////
        }
    }
    }
