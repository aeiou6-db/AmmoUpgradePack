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
    public class M60 : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> M900;
        public static void Config(MelonPreferences_Category cfg)
        {
            M900 = cfg.CreateEntry<bool>("(M60) M900 APFSDS-T", true);
            M900.Comment = "Applies to all M60s";
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (vic.UniqueName != "M60A1AOS"
                && vic.UniqueName != "M60A3TTS"
                && vic.UniqueName != "M60A1"
                && vic.UniqueName != "M60A1RISEP")
                return;
            if (M900.Value == false) return;
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            loadout_manager.LoadedAmmoList.AmmoClips[0] = Shells.clip_codex_m900;
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
            StateController.RunOrDefer(GameState.PlayerReady, new GameStateEventHandler(Convert), GameStatePriority.Medium);
        }
    }
}