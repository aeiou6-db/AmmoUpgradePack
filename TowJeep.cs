using AmmoUpgrade;
using GHPC.State;
using GHPC.Vehicle;
using GHPC.Weaponry;
using GHPC.Weapons;
using MelonLoader;
using ModUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AmmoUpgradePack
{
    public class TOWJeep : ModUtil.Module
    {
        static MelonPreferences_Entry<string> atgm;
        private static AmmoClipCodexScriptable missile;

        public static void Config(MelonPreferences_Category cfg)
        {
            atgm = cfg.CreateEntry<string>("(TOW Jeep) ATGM Ammo", "TOW2");
            atgm.Comment = "ITOW (STOCK), TOW2, TOW2A (Tandem)"; 
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (vic.UniqueName != "M151M232") return;
            if (atgm.Value == "ITOW") return;
            MelonLogger.Msg("TOW Jeep FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            MelonLogger.Msg("WEAPONS MANAGER FOUND");
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            MelonLogger.Msg("LAUNCHER FOUND");
            GHPC.Weapons.AmmoRack cannonrack = main_gun.Feed.ReadyRack;
            MelonLogger.Msg("READY RACK FOUND");
            string ammo_str = atgm.Value;
            if (ammo_str == "TOW2")
            {
                missile = shellsNATO.clip_codex_tow2 ;
            }
            if (ammo_str == "TOW2A")
            {
                missile = shellsNATO.clip_codex_tow2a;
            }
            MelonLogger.Msg("ATGM FOUND");
            loadout_manager.LoadedAmmoList.AmmoClips[0] = missile;
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
            StateController.RunOrDefer(GameState.PlayerReady, new GameStateEventHandler(Convert), GameStatePriority.Low);
        }
    }
}
   