using AmmoUpgrade;
using FMOD.Studio;
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
    internal class T62 : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> BM36;
        public static void Config(MelonPreferences_Category cfg)
        {

            BM36 = cfg.CreateEntry<bool>("(T-62) 3BM36 APFSDS-T", true);
            BM36.Comment = "effectively 3BM32 Vant for the T-62";
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (vic.UniqueName != "T62") return;
            if (BM36.Value == false) return;
            MelonLogger.Msg("T62 FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsPACT.clip_codex_3bm36;
            for (int i = 0; i < loadout_manager.RackLoadouts.Length; i++)
            {
                GHPC.Weapons.AmmoRack rack = loadout_manager.RackLoadouts[i].Rack;
                ModUtil.Util.EmptyRack(rack);
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
            StateController.RunOrDefer(GameState.PlayerReady, new GameStateEventHandler(Convert), GameStatePriority.Low);
        }
    }
}