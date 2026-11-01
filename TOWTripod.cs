using AmmoUpgrade;
using GHPC.State;
using GHPC.Vehicle;
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
    public class TOWTripod : ModUtil.Module
    {
        static MelonPreferences_Entry<string> atgm;
        private static AmmoType.AmmoClip missile;

        public static void Config(MelonPreferences_Category cfg)
        {
            atgm = cfg.CreateEntry<string>("(TOW Tripod) ATGM Ammo", "TOW2");
            atgm.Comment = "TOW (STOCK) ,ITOW, TOW2, TOW2A (Tandem)"; 
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (vic.UniqueName != "STATIC_TOW") return;
            if (atgm.Value == "TOW") return;
            MelonLogger.Msg("STATIC TOW FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            MelonLogger.Msg("WEAPONS MANAGER FOUND");
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            MelonLogger.Msg("LAUNCHER FOUND");
            GHPC.Weapons.AmmoRack cannonrack = main_gun.Feed.ReadyRack;
            MelonLogger.Msg("READY RACK FOUND");
            string ammo_str = atgm.Value;
            if (ammo_str == "ITOW")
            {
                missile = shellsNATO.clip_itow;
            }
            if (ammo_str == "TOW2")
            {
                missile = shellsNATO.clip_tow2;
            }
            if (ammo_str == "TOW2A")
            {
                missile = shellsNATO.clip_tow2a;
            }
            MelonLogger.Msg("ATGM FOUND");
            cannonrack._clipTypes[0] = missile;
            cannonrack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    missile,missile,missile,missile,missile
                };
            main_gun.Feed.AmmoTypeInBreech = null;
            main_gun.Feed.Start();
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
   