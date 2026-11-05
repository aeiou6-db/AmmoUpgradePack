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
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.PostProcessing;
using static UnityEngine.GraphicsBuffer;

namespace AmmoUpgradePack
{
    public class BMP2 : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> patch;
        static MelonPreferences_Entry<string> ammo_ap;
        static MelonPreferences_Entry<bool> atgm;

        public static void Config(MelonPreferences_Category cfg)
        {
            patch = cfg.CreateEntry<bool>("BMP-2 Patch", true);
            patch.Comment = "////////////////////////////////";

            ammo_ap = cfg.CreateEntry<string>("(BMP-2) AP Ammo", "3UBR8");
            ammo_ap.Comment = "3UBR6 (Stock), 3UBR8, 3UBR11";

            atgm = cfg.CreateEntry<bool>("(BMP-2) Konkurs-M ATGM", true);
            atgm.Comment = "Tandem ATGM, becomes Kornet-M if PIL kornets are enabled";
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (!vic.UniqueName.Contains("BMP2")) return;
            MelonLogger.Msg("BMP-2 FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            GHPC.Weapons.AmmoRack rack = loadout_manager.RackLoadouts[0].Rack;
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystemInfo launcher_info = weapons_manager.Weapons[1];
            WeaponSystem main_gun = main_gun_info.Weapon;
            WeaponSystem launcher = launcher_info.Weapon;
            GHPC.Weapons.AmmoRack atgm_rack = launcher.Feed.ReadyRack;
            AmmoType.AmmoClip konkursM = ATGMPact.clip_konkursM;
            AmmoType.AmmoClip kornet = ATGMPact.clip_9m133M;
            if (ammo_ap.Value == "3UBR8")
            {
                loadout_manager._loadedAmmoList.AmmoClips[0] = shellsPACT.clip_codex_3ubr8;
            }
            if (ammo_ap.Value == "3UBR11")
            {
                loadout_manager._loadedAmmoList.AmmoClips[0] = shellsPACT.clip_codex_3ubr11;
            }
            if (launcher_info.Name == "Twin ATGM Launchers")
            {
                if (atgm.Value == true)
                {
                    MelonLogger.Msg("Kornets Detected: Applying Kornet-M");
                    atgm_rack.ClipTypes[0] = kornet;
                    atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    kornet,
                    kornet,
                };
                }
            }
            else
            {
                if (atgm.Value == true)
                {
                    MelonLogger.Msg("Standard BMP2: Applying Konkurs-M");
                    atgm_rack._clipTypes[0] = konkursM;
                    atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    konkursM,
                    konkursM,
                    konkursM,
                    konkursM,
                    konkursM,
                    konkursM,
                    konkursM,
                    konkursM,
                };
                }
            }
            loadout_manager.SpawnCurrentLoadout();
            launcher.Feed.AmmoTypeInBreech = null;
            main_gun.Feed.AmmoTypeInBreech = null;
            main_gun.Feed.Start();
            launcher.Feed.Start();
            loadout_manager.RegisterAllBallistics();
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
            if (patch.Value == false) return;
            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Medium);
        }
    }
}