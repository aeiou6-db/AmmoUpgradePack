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
    public class Launcher9K111 : ModUtil.Module
    {
        static MelonPreferences_Entry<string> atgm;
        private static AmmoType.AmmoClip missile;

        public static void Config(MelonPreferences_Category cfg)
        {
            atgm = cfg.CreateEntry<string>("(9K111) ATGM Ammo", "9M111M");
            atgm.Comment = "9M111, 9M111M, 9M113, 9M113M (Tandem)"; 
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (!vic.UniqueName.Contains("9K111")) return;
            MelonLogger.Msg("STATIC 9K111 FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            MelonLogger.Msg("WEAPONS MANAGER FOUND");
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            MelonLogger.Msg("LAUNCHER FOUND");
            GHPC.Weapons.AmmoRack cannonrack = main_gun.Feed.ReadyRack;
            MelonLogger.Msg("READY RACK FOUND");
            string ammo_str = atgm.Value;
            if (ammo_str == "9M113M")
            {
                missile = shellsPACT.clip_konkursM;
            }
            if (ammo_str == "9M113")
            {
                missile = shellsPACT.clip_konkurs;
            }
            if (ammo_str == "9M111M")
            {
                missile = shellsPACT.clip_9M111M;
            }
            if (ammo_str == "9M111")
            {
                return;
            }
            MelonLogger.Msg("ATGM FOUND");
            cannonrack._clipTypes[0] = missile;
            cannonrack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    missile,missile,missile,missile,missile,missile
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
   