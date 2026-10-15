using GHPC.Weaponry;
using GHPC.Weapons;
using ModUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AmmoUpgradePack
{
    public class Shells : Module
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
            //
            ammo_dm33 = new AmmoType();
            Util.ShallowCopy(ammo_dm33, SharedAssetz.ammo_dm120);
            ammo_dm33.Name = "DM33 APFSDS-T";
            ammo_dm33.RhaPenetration = 420;
            ammo_dm33.Caliber = 120;
            ammo_dm33.MuzzleVelocity = 1680;
            ammo_dm33.SpallMultiplier = 1.5f;
            ammo_dm33.MaxSpallRha = 30;
            ammo_dm33.MinSpallRha = 8;

            Util.Coalesce(ref ammo_codex_dm33);
            ammo_codex_dm33.AmmoType = ammo_dm33;
            ammo_codex_dm33.name = "ammo_dm33";

            clip_dm33 = new AmmoType.AmmoClip();
            clip_dm33.Capacity = 1;
            clip_dm33.Name = "DM33 APFSDS-T";
            clip_dm33.MinimalPattern = new AmmoCodexScriptable[1];
            clip_dm33.MinimalPattern[0] = ammo_codex_dm33;

            Util.Coalesce(ref clip_codex_dm33);
            clip_codex_dm33.name = "clip_dm33";
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
            ammo_dm53.SpallMultiplier = 1.5f;
            ammo_dm53.MaxSpallRha = 30;
            ammo_dm53.MinSpallRha = 8;

            Util.Coalesce(ref ammo_codex_dm53);
            ammo_codex_dm53.AmmoType = ammo_dm53;
            ammo_codex_dm53.name = "ammo_dm53";

            clip_dm53 = new AmmoType.AmmoClip();
            clip_dm53.Capacity = 1;
            clip_dm53.Name = "DM53 APFSDS-T";
            clip_dm53.MinimalPattern = new AmmoCodexScriptable[1];
            clip_dm53.MinimalPattern[0] = ammo_codex_dm53;

            Util.Coalesce(ref clip_codex_dm53);
            clip_codex_dm53.name = "clip_dm53";
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
            ammo_dm105_33.RhaPenetration = 420;
            ammo_dm105_33.Caliber = 105;
            ammo_dm105_33.MuzzleVelocity = 1450;

            Util.Coalesce(ref ammo_codex_dm105_33);
            ammo_codex_dm105_33.AmmoType = ammo_dm105_33;
            ammo_codex_dm105_33.name = "ammo_dm105_33";

            clip_dm105_33 = new AmmoType.AmmoClip();
            clip_dm105_33.Capacity = 1;
            clip_dm105_33.Name = "DM33 APFSDS-T";
            clip_dm105_33.MinimalPattern = new AmmoCodexScriptable[1];
            clip_dm105_33.MinimalPattern[0] = ammo_codex_dm105_33;

            Util.Coalesce(ref clip_codex_dm105_33);
            clip_codex_dm105_33.name = "clip_dm105_33";
            clip_codex_dm105_33.ClipType = clip_dm105_33;

            ammo_dm105_33_vis = GameObject.Instantiate(SharedAssetz.ammo_dm105.VisualModel);
            ammo_dm105_33_vis.name = "dm105_33 visual";
            ammo_dm105_33.VisualModel = ammo_dm105_33_vis;
            ammo_dm105_33.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_dm105_33;
            ammo_dm105_33.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_dm105_33;

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
