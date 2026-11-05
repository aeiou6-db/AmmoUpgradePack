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
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.PostProcessing;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.GridLayoutGroup;

namespace AmmoUpgradePack
{
    public class BMP1P : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> patch;
        static MelonPreferences_Entry<bool> pg15vnt;
        static MelonPreferences_Entry<bool> atgm;

        public static void Config(MelonPreferences_Category cfg)
        {
            patch = cfg.CreateEntry<bool>("BMP-1P Patch", true);
            patch.Comment = "////////////////////////////////";

            pg15vnt = cfg.CreateEntry<bool>("(BMP-1P) PG-15VNT", true);
            pg15vnt.Comment = "tandem HEAT round for the 73mm cannon";

            atgm = cfg.CreateEntry<bool>("(BMP-1P) Konkurs-M ATGM", true);
            atgm.Comment = "Improved penetration and tandem warhead";
        }
        
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (!vic.UniqueName.Contains("BMP1P")) return;
            MelonLogger.Msg("BMP-1P FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            GHPC.Weapons.AmmoRack rack = loadout_manager.RackLoadouts[0].Rack;
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystemInfo launcher_info = weapons_manager.Weapons[1];
            WeaponSystem main_gun = main_gun_info.Weapon;
            WeaponSystem launcher = launcher_info.Weapon;
            GHPC.Weapons.AmmoRack atgm_rack = launcher.Feed.ReadyRack;
            if (atgm.Value == true)
            {
                AmmoType.AmmoClip konkursM = ATGMPact.clip_konkursM;
                atgm_rack._clipTypes[0] = konkursM;
                atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    konkursM,
                    konkursM,
                    konkursM,
                    konkursM,
                    konkursM,
                };
                launcher.Feed.AmmoTypeInBreech = null;
                launcher.Feed.Start();
            }
            if (pg15vnt.Value == true)
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsPACT.clip_codex_pg15vnt;
            }
            loadout_manager.SpawnCurrentLoadout();
            main_gun.Feed.AmmoTypeInBreech = null;
            main_gun.Feed.Start();
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
            if (!patch.Value) return;
            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Medium);
        }
    }
}