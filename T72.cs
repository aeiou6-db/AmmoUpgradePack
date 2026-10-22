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
    internal class T72 : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> patch;
        static MelonPreferences_Entry<bool> BM59M;
        static MelonPreferences_Entry<bool> BM59M1;
        static MelonPreferences_Entry<bool> BK29M;
        static MelonPreferences_Entry<bool> BK29M1;
        public static void Config(MelonPreferences_Category cfg)
        {
            patch = cfg.CreateEntry<bool>("T72 Ammo Upgrade Toggle", true);
            patch.Comment = "///////////////////////////////";

            BM59M = cfg.CreateEntry<bool>("(T-72M) 3BM59 APFSDS", false);
            BM59M.Comment = "Effectively a DU version of 3BM60, with superior pen";

            BK29M = cfg.CreateEntry<bool>("(T-72M) 3BK29 HEATFS", true);
            BK29M.Comment = "Tandem HEATFS for the T-72. Compatible with PIL";

            //// 72m1 ///

            BM59M1 = cfg.CreateEntry<bool>("(T-72M1) 3BM59 APFSDS", false);

            BK29M1 = cfg.CreateEntry<bool>("(T-72M1) 3BK29 HEATFS", true);
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;
            GameObject vic_go = vic.gameObject;
            if (vic.UniqueName != "T72M" && vic.UniqueName != "T72M1") return;
            MelonLogger.Msg("T72 FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            if (vic.UniqueName == "T72M")
            {
                if (BM59M.Value == true)
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsPACT.clip_codex_3bm59;
                }
                if (BK29M.Value == true)
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[1] = shellsPACT.clip_codex_3bk29;
                }
            }
            if (vic.UniqueName == "T72M1")
            {
                if (BM59M1.Value == true)
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsPACT.clip_codex_3bm59;
                }
                if (BK29M1.Value == true)
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[1] = shellsPACT.clip_codex_3bk29;
                }
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
