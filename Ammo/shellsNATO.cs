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

        public static AmmoClipCodexScriptable clip_codex_dm63;
        public static AmmoType.AmmoClip clip_dm63;
        public static AmmoCodexScriptable ammo_codex_dm63;
        public static AmmoType ammo_dm63;
        public static GameObject ammo_dm63_vis = null;


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
            List<AmmoType.ArmorOptimization> supertandem = new List<AmmoType.ArmorOptimization>();

            foreach (ArmorCodexScriptable lightcodex in lightERA)
            {
                supertandem.Add(Util.CreateArmourOptimization(lightcodex, 0.01f));
            }

            foreach (ArmorCodexScriptable natocodex in natoERA)
            {
                supertandem.Add(Util.CreateArmourOptimization(natocodex, 0.1f));
            }

            foreach (ArmorCodexScriptable heavycodex in RUHeavy)
            {
                supertandem.Add(Util.CreateArmourOptimization(heavycodex, 0.15f));
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
                anticomp1.Add(Util.CreateArmourOptimization(compcodex, 0.75f));
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
            //////////////////////////////



            // example.ArmorOptimizations = tandem.ToArray();

            ammo_dm33.ArmorOptimizations = anticomp1.ToArray();
            ammo_dm53.ArmorOptimizations = EraTip.ToArray();
            ammo_dm63.ArmorOptimizations = EraTip.ToArray();
            ammo_dm105_63.ArmorOptimizations = anticomp2.ToArray();
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
            ammo_dm33.Coeff = 0.24f;
            ammo_dm33.MuzzleVelocity = 1650;
            ammo_dm33.SpallMultiplier = 2f;
            ammo_dm33.Mass = 4.38f;
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
            ammo_dm53.RhaPenetration = 740;
            ammo_dm53.Caliber = 120;
            ammo_dm53.MuzzleVelocity = 1650;
            ammo_dm53.Mass = 5.01f;
            ammo_dm53.Coeff = 0.185f;
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

            ammo_dm63 = new AmmoType();
            Util.ShallowCopy(ammo_dm63, SharedAssets.ammo_dm120);
            ammo_dm63.Name = "DM63 APFSDS-T";
            ammo_dm63.RhaPenetration = 740;
            ammo_dm63.Caliber = 120;
            ammo_dm63.Coeff = 0.185f;
            ammo_dm63.MuzzleVelocity = 1650;
            ammo_dm63.Mass = 5.01f;
            ammo_dm63.MaxSpallRha = 30;
            ammo_dm63.MinSpallRha = 8;

            Util.Coalesce(ref ammo_codex_dm63);
            ammo_codex_dm63.AmmoType = ammo_dm63;
            ammo_codex_dm63.name = "ammo_dm63(120)";

            clip_dm63 = new AmmoType.AmmoClip();
            clip_dm63.Capacity = 1;
            clip_dm63.Name = "DM63 APFSDS-T";
            clip_dm63.MinimalPattern = new AmmoCodexScriptable[1];
            clip_dm63.MinimalPattern[0] = ammo_codex_dm63;

            Util.Coalesce(ref clip_codex_dm63);
            clip_codex_dm63.name = "clip_dm63(120)";
            clip_codex_dm63.ClipType = clip_dm63;

            ammo_dm63_vis = GameObject.Instantiate(SharedAssets.ammo_dm120.VisualModel);
            ammo_dm63_vis.name = "dm63 visual";
            ammo_dm63.VisualModel = ammo_dm63_vis;
            ammo_dm63.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_dm63;
            ammo_dm63.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_dm63;
            ///////////////////////////////////////////////////////////////////////////////////////////////
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
            ammo_m900.Coeff = 0.21f;

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
            ammo_dm105_33.MuzzleVelocity = 1455;
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
        }
    }
    }
