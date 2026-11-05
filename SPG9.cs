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
    public class SPG9 : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> pg15vnt;
        public static void Config(MelonPreferences_Category cfg)
        {
            pg15vnt = cfg.CreateEntry<bool>("(SPG-9) PG-15VNT", true);
            pg15vnt.Comment = "73mm Tandem HEAT"; 
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (!vic.UniqueName.Contains("SPG9")) return;
            if (pg15vnt.Value != true) return;
            MelonLogger.Msg("STATIC SPG-9 FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            GHPC.Weapons.AmmoRack cannonrack = main_gun.Feed.ReadyRack;
            AmmoType.AmmoClip HEAT = shellsPACT.clip_pg15vnt;
            cannonrack._clipTypes[0] = HEAT;
            cannonrack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    HEAT,HEAT,HEAT,HEAT,HEAT,HEAT,HEAT,HEAT,HEAT,HEAT,HEAT,HEAT
                };
            main_gun.Feed.AmmoTypeInBreech = null;
            main_gun.Feed.Start();
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
            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Low);
        }
    }
}
   