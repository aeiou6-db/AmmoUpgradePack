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
    public class Leo2 : ModUtil.Module
    {
        public static MelonPreferences_Entry<string> ammo_ap;
        public static MelonPreferences_Entry<bool> patch;
        public static void Config(MelonPreferences_Category cfg)
        {
            patch = cfg.CreateEntry<bool>("Leopard 2 Ammo Upgrade Toggle", true);
            patch.Comment = "///////////////////////////////";

            ammo_ap = cfg.CreateEntry<string>("AP Ammo", "DM33");
            ammo_ap.Comment = "DM23, DM33, DM53";
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;


            GameObject vic_go = vic.gameObject;

            if (vic.FriendlyName != "Leopard 2A3"
                && vic.FriendlyName != "Leopard 2A2"
                && vic.FriendlyName != "Leopard 2A1"
                && vic.FriendlyName != "Leopard 2") return;
            MelonLogger.Msg("LEO2 FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;

            string ammostr = ammo_ap.Value;
            if (ammostr == "DM53")
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsNATO.clip_codex_dm53;
            }
            if (ammostr == "DM33")
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsNATO.clip_codex_dm33;
            }
            if (ammostr == "DM23")
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = SharedAssetz.codex_dm120;
            }
            for (int i = 0; i < loadout_manager.RackLoadouts.Length; i++)
            {
                GHPC.Weapons.AmmoRack rack = loadout_manager.RackLoadouts[i].Rack;
                Util.EmptyRack(rack);
            }
            main_gun.Feed.AmmoTypeInBreech = null;
            loadout_manager.SpawnCurrentLoadout();
            main_gun.Feed.Start();
            loadout_manager.RegisterAllBallistics();
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
            if (!patch.Value) return;
            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Medium);
        }
    }
}