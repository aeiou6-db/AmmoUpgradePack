using AmmoUpgrade;
using GHPC;
using GHPC.AI;
using GHPC.AI.Targeting;
using GHPC.Camera;
using GHPC.Effects;
using GHPC.Effects.Voices;
using GHPC.Equipment;
using GHPC.Equipment.Optics;
using GHPC.Mission;
using GHPC.Multiplayer.Entity;
using GHPC.State;
using GHPC.Thermals;
using GHPC.UI.Tips;
using GHPC.Utility;
using GHPC.Vehicle;
using GHPC.Weaponry;
using GHPC.Weapons;
using Harmony;
using HarmonyLib;
using MelonLoader;
using MelonLoader.Utils;
using ModUtil;
using NWH.VehiclePhysics;
using Reticle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.PostProcessing;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.GridLayoutGroup;

namespace AmmoUpgradePack
{
    public class Marder : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> patch;
        static MelonPreferences_Entry<string> atgm;


        public static void Config(MelonPreferences_Category cfg)
        {
            patch = cfg.CreateEntry<bool>("Marder Conversion Toggle", true);
            patch.Comment = "///////////////////////////////////////"; 

            atgm = cfg.CreateEntry<string>("(Marder) ATGM Ammo", "Milan-2");
            atgm.Comment = "Milan (Vanilla), Milan-2, Milan-3 (Tandem), Milan-3ER (Tandem, Extended Range)";
        }
        
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (!vic.UniqueName.Contains("MARDER")) return;
            MelonLogger.Msg("MARDER FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            GHPC.Weapons.AmmoRack rack = loadout_manager.RackLoadouts[0].Rack;
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystemInfo launcher_info = weapons_manager.Weapons[1];
            WeaponSystem main_gun = main_gun_info.Weapon;
            WeaponSystem launcher = launcher_info.Weapon;
            GHPC.Weapons.AmmoRack atgm_rack = launcher.Feed.ReadyRack;
            FireControlSystem fcs = vic.GetComponentInChildren<FireControlSystem>();
            UsableOptic day_optic = Util.GetDayOptic(main_gun.FCS);
            string ammo_str = atgm.Value;

            if (ammo_str == "Milan")
            {
                return;
            }
            if (ammo_str == "Milan-2")
            {
                AmmoType.AmmoClip missile = ATGMNato.clip_milan2;
                atgm_rack._clipTypes[0] = missile;
                atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    missile,
                    missile,
                    missile,
                    missile
                };
            }
            if (ammo_str == "Milan-3")
            {
                AmmoType.AmmoClip missile = ATGMNato.clip_milan3;
                atgm_rack._clipTypes[0] = missile;
                atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    missile,
                    missile,
                    missile,
                    missile
                };
            }
            if (ammo_str == "Milan-3ER")
            {
                AmmoType.AmmoClip missile = ATGMNato.clip_milan3ER;
                atgm_rack._clipTypes[0] = missile;
                atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    missile,
                    missile,
                    missile,
                    missile
                };
            }
            launcher.Feed.AmmoTypeInBreech = null;
            launcher.Feed.Start();
        }
        public static IEnumerator Convert(GameState _)
        {
            foreach (Vehicle vic in AmmoUpgradeMod.vics)
            {
                HandleConversion(vic);
            }

            yield break;
        }

        public static void Init()
        {
            if (!patch.Value) return;
            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Medium);
        }
    }
}