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
        static MelonPreferences_Entry<bool> atgm;

        public static void Config(MelonPreferences_Category cfg)
        {
            atgm = cfg.CreateEntry<bool>("(BMP-2) Konkurs-M ATGM", true);
            atgm.Comment = "Tandem ATGM, becomes Kornet-M if PIL kornets are enabled";
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (!vic.UniqueName.Contains("BMP2")) return;
            if (atgm.Value == false) return;
            MelonLogger.Msg("BMP-2 FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            GHPC.Weapons.AmmoRack rack = loadout_manager.RackLoadouts[0].Rack;
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystemInfo launcher_info = weapons_manager.Weapons[1];
            WeaponSystem main_gun = main_gun_info.Weapon;
            WeaponSystem launcher = launcher_info.Weapon;
            GHPC.Weapons.AmmoRack atgm_rack = launcher.Feed.ReadyRack;
            AmmoType.AmmoClip konkursM = shellsPACT.clip_konkursM;
            AmmoType.AmmoClip kornet = shellsPACT.clip_9m133M;
            if (launcher_info.Name == "Twin ATGM Launchers")
            {
                MelonLogger.Msg("Kornets Detected: Applying Kornet-M");
                atgm_rack.ClipTypes[0] = kornet;
                atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    kornet,
                    kornet,
                };
            }
            else
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
            launcher.Feed.AmmoTypeInBreech = null;
            launcher.Feed.Start();
        }
        public static IEnumerator Convert(GameState _)
        {
            foreach (Vehicle vic in Mod.vics)
            {
                HandleConversion(vic);
            }

            yield break;
        }

        public static void Init()
        {
            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Medium);
        }
    }
}