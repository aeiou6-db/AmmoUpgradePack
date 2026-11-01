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

            List<AmmoType.ArmorOptimization> EraTip = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable lightcodex in lightERA)
            {
                EraTip.Add(Util.CreateArmourOptimization(lightcodex, 0.32f));
            }

            foreach (ArmorCodexScriptable natocodex in natoERA)
            {
                EraTip.Add(Util.CreateArmourOptimization(natocodex, 0.32f));
            }

            foreach (ArmorCodexScriptable heavycodex in RUHeavy)
            {
                EraTip.Add(Util.CreateArmourOptimization(heavycodex, 0.32f));
            }
            ///


            // example.ArmorOptimizations = tandem.ToArray();
            ammo_milan3.ArmorOptimizations = tandem.ToArray();
            ammo_milan3ER.ArmorOptimizations = tandem.ToArray();
            ammo_tow2a.ArmorOptimizations = tandem.ToArray();
            ammo_dm53.ArmorOptimizations = EraTip.ToArray();
            yield break;
        }
        public override void LoadDynamicAssets()
        {
        // actual shells // 
        ///////////////////////////////////////////////////////////////////////////////////////////////
        ///120mm German Shells
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        ammo_dm33 = new AmmoType();
            Util.ShallowCopy(ammo_dm33, SharedAssets.ammo_dm120);
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

            ammo_dm33_vis = GameObject.Instantiate(SharedAssets.ammo_dm120.VisualModel);
            ammo_dm33_vis.name = "dm33 visual";
            ammo_dm33.VisualModel = ammo_dm33_vis;
            ammo_dm33.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_dm33;
            ammo_dm33.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_dm33;

            ///////////////////////////////////////////////////////////////////////////////////////////////

            ammo_dm53 = new AmmoType();
            Util.ShallowCopy(ammo_dm53, SharedAssets.ammo_dm120);
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

            ammo_dm53_vis = GameObject.Instantiate(SharedAssets.ammo_dm120.VisualModel);
            ammo_dm53_vis.name = "dm53 visual";
            ammo_dm53.VisualModel = ammo_dm53_vis;
            ammo_dm53.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_dm53;
            ammo_dm53.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_dm53;
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ///105 US Shells
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ammo_m900 = new AmmoType();
            Util.ShallowCopy(ammo_m900, SharedAssets.ammo_m833);
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

            ammo_m900_vis = GameObject.Instantiate(SharedAssets.ammo_m833.VisualModel);
            ammo_m900_vis.name = "m900 visual";
            ammo_m900.VisualModel = ammo_m900_vis;
            ammo_m900.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m900;
            ammo_m900.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m900;
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ///105 German Shells
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ammo_dm105_33 = new AmmoType();
            Util.ShallowCopy(ammo_dm105_33, SharedAssets.ammo_dm105);
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

            ammo_dm105_33_vis = GameObject.Instantiate(SharedAssets.ammo_dm105.VisualModel);
            ammo_dm105_33_vis.name = "dm105_33 visual";
            ammo_dm105_33.VisualModel = ammo_dm105_33_vis;
            ammo_dm105_33.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_dm105_33;
            ammo_dm105_33.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_dm105_33;
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ammo_dm105_63 = new AmmoType();
            Util.ShallowCopy(ammo_dm105_63, SharedAssets.ammo_dm105);
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

            ammo_dm105_63_vis = GameObject.Instantiate(SharedAssets.ammo_dm105.VisualModel);
            ammo_dm105_63_vis.name = "dm105_63 visual";
            ammo_dm105_63.VisualModel = ammo_dm105_63_vis;
            ammo_dm105_63.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_dm105_63;
            ammo_dm105_63.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_dm105_63;
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
            Util.ShallowCopy(ammo_itow, SharedAssets.ammo_itow);
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

            ammo_itow_vis = GameObject.Instantiate(SharedAssets.ammo_itow.VisualModel);
            ammo_itow_vis.name = "itow visual";
            ammo_itow.VisualModel = ammo_itow_vis;
            ammo_itow.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_itow;
            ammo_itow.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_itow;
            ////////////////////////////////////////////////////////////////////////
            ammo_tow2 = new AmmoType();
            Util.ShallowCopy(ammo_tow2, SharedAssets.ammo_itow);
            ammo_tow2.Name = "BGM-71D TOW-2";
            ammo_tow2.RhaPenetration = 800f;
            ammo_tow2.MuzzleVelocity = 329f;
            ammo_tow2.TntEquivalentKg = 4.41f;
            ammo_tow2.SpallMultiplier = 2.5f;
            ammo_tow2.NoisePowerX = 30f;
            ammo_tow2.NoisePowerY = 30f;
            ammo_tow2.TurnSpeed = 0.18f;
            ammo_tow2.NoLeadCompensation = true;
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

            ammo_tow2_vis = GameObject.Instantiate(SharedAssets.ammo_itow.VisualModel);
            ammo_tow2_vis.name = "tow2 visual";
            ammo_tow2.VisualModel = ammo_tow2_vis;
            ammo_tow2.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_tow2;
            ammo_tow2.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_tow2;
            ////////////////////////////////////////////////////////////////////////
            ammo_tow2a = new AmmoType();
            Util.ShallowCopy(ammo_tow2a, ammo_tow2);
            ammo_tow2a.Name = "BGM-71E TOW-2A";
            ammo_tow2a.RhaPenetration = 1000f;
            ammo_tow2a.TntEquivalentKg = 4.5f;
            ammo_tow2a.NoLeadCompensation = true;
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

            ammo_tow2a_vis = GameObject.Instantiate(SharedAssets.ammo_itow.VisualModel);
            ammo_tow2a_vis.name = "tow2a visual";
            ammo_tow2a.VisualModel = ammo_tow2a_vis;
            ammo_tow2a.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_tow2a;
            ammo_tow2a.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_tow2a;
            ////////////////////////////////////////////////////////////////////////
        }
    }
    }
