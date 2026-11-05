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
    internal class T55A : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> patch;
        static MelonPreferences_Entry<string> APAmmo;
        static MelonPreferences_Entry<bool> BK17;
        public static void Config(MelonPreferences_Category cfg)
        {
            patch = cfg.CreateEntry<bool>("T55A Ammo Upgrade Toggle", true);
            patch.Comment = "///////////////////////////////";

            APAmmo = cfg.CreateEntry<string>("(T-55A) AP Ammo", "3BM25");
            APAmmo.Comment = "3BM20 (Stock), 3BM25, M309";

            BK17 = cfg.CreateEntry<bool>("(T-55A) 3BK17M HEATFS", true);
            BK17.Comment = "Improved Ballistics and pen over 3BK5M";
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;
            GameObject vic_go = vic.gameObject;
            if (vic.UniqueName != "T55A") return;
            MelonLogger.Msg("T55A FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            MelonLogger.Msg("WEAPON MANAGER FOUND");
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            MelonLogger.Msg("LOADOUT MANAGER FOUND");
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            if (APAmmo.Value == "3BM25")
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsPACT.clip_codex_3bm25;
                MelonLogger.Msg("3BM25 SET");
            }
            if (APAmmo.Value == "M309")
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsPACT.clip_codex_M309;
                MelonLogger.Msg("M309 SET");
            }
            if (BK17.Value == true)
            {
                loadout_manager.LoadedAmmoList.AmmoClips[1] = shellsPACT.clip_codex_3bk17;
                MelonLogger.Msg("3BK17M SET");
            }
            for (int i = 0; i < loadout_manager.RackLoadouts.Length; i++)
            {
                GHPC.Weapons.AmmoRack rack = loadout_manager.RackLoadouts[i].Rack;
                Util.EmptyRack(rack);
            }
            MelonLogger.Msg("RACKS EMPTIED");
            main_gun.Feed.AmmoTypeInBreech = null;
            MelonLogger.Msg("BREACH EMPTIED");
            loadout_manager.SpawnCurrentLoadout();
            MelonLogger.Msg("LOADOUT SPAWNED");
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
            if (patch.Value == false) return;
            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Medium);
        }
    }
}
