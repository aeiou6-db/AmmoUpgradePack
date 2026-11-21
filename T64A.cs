using AmmoUpgrade;
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
    internal class T64A : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> patch;
        static MelonPreferences_Entry<bool> APToggle;
        static MelonPreferences_Entry<string> AP;

        static MelonPreferences_Entry<bool> HEATToggle;
        static MelonPreferences_Entry<string> HEAT;
        public static void Config(MelonPreferences_Category cfg)
        {
            patch = cfg.CreateEntry<bool>("T64A Ammo Upgrade Toggle", true);
            patch.Comment = "///////////////////////////////";

            APToggle = cfg.CreateEntry<bool>("(T-64A) AP Toggle", true);
            APToggle.Comment = "Toggles the AP shell converter";

            AP = cfg.CreateEntry<string>("(T-64A) AP Shell", "3BM42");
            AP.Comment = "3BM42 (comp optimized), 3BM46, 3BM42M (comp optimized), 3BM60, 3BM59 (comp optimized)";

            HEATToggle = cfg.CreateEntry<bool>("(T-64A) HEAT Toggle", true);
            HEATToggle.Comment = "Toggles the HEAT shell converter";

            HEAT = cfg.CreateEntry<string>("(T-64A) HEAT Shell", "3BK29");
            HEAT.Comment = "3BK29, 3BK29M, 3BK31";
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;
            GameObject vic_go = vic.gameObject;
            if (!vic.UniqueName.Contains("T64A")) return;
            MelonLogger.Msg("T64A FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            if (APToggle.Value == true)
            {
                if (AP.Value == "3BM42")
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[0] = Shells125.clip_codex_3bm42;
                }
                if (AP.Value == "3BM42M")
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[0] = Shells125.clip_codex_3bm44;
                }
                if (AP.Value == "3BM46")
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[0] = Shells125.clip_codex_3bm46;
                }
                if (AP.Value == "3BM59")
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[0] = Shells125.clip_codex_3bm59;
                }
                if (AP.Value == "3BM60")
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[0] = Shells125.clip_codex_3bm60;
                }
            }
            if (HEATToggle.Value == true)
            {
                if (HEAT.Value == "3BK29")
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[1] = Shells125.clip_codex_3bk29;
                }
                if (HEAT.Value == "3BK29M")
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[1] = Shells125.clip_codex_3bk29M;
                }
                if (HEAT.Value == "3BK31")
                {
                    loadout_manager.LoadedAmmoList.AmmoClips[1] = Shells125.clip_codex_3bk31;
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
            foreach (Vehicle vic in AmmoUpgradeMod.vics)
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
