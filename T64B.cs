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
    internal class T64B : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> patch;
        static MelonPreferences_Entry<bool> BM59;
        static MelonPreferences_Entry<bool> BK29;
        public static void Config(MelonPreferences_Category cfg)
        {
            patch = cfg.CreateEntry<bool>("T64B Ammo Upgrade Toggle", true);
            patch.Comment = "///////////////////////////////";

            BM59 = cfg.CreateEntry<bool>("(T-64B) 3BM59 APFSDS", false);
            BM59.Comment = "what do you mean this shell wont fit in the t-64 autoloader? No such problem exists";


            BK29 = cfg.CreateEntry<bool>("(T-64B) 3BK29 HEATFS", true);
            BK29.Comment = "Tandem HEAT-FS";
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;
            GameObject vic_go = vic.gameObject;
            if (!vic.UniqueName.Contains("T64B")) return;
            MelonLogger.Msg("T64B FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            if (BM59.Value == true)
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsPACT.clip_codex_3bm59;
            }
            if (BK29.Value == true)
            {
                loadout_manager.LoadedAmmoList.AmmoClips[1] = shellsPACT.clip_codex_3bk29;
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
            if (patch.Value == false) return;
            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Medium);
        }
    }
}