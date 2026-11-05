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
            MelonLogger.Msg("TOW Jeep WeaponsManager");
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            MelonLogger.Msg("TOW Jeep LoadoutManager");
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            MelonLogger.Msg("TOW Jeep Main Gun Info");
            WeaponSystem main_gun = main_gun_info.Weapon;
            MelonLogger.Msg("TOW Jeep Main Gun");
            if (atgm.Value == "TOW2")
            {
                MelonLogger.Msg("TOW 2 SET");
                loadout_manager.LoadedAmmoList.AmmoClips[0] = ATGMNato.clip_codex_tow2;
            }
            if (atgm.Value == "TOW2A")
            {
                MelonLogger.Msg("TOW 2A SET");
                loadout_manager.LoadedAmmoList.AmmoClips[0] = ATGMNato.clip_codex_tow2a;
            }
            MelonLogger.Msg("COMPLETED, EMPTYING RACKS");
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
            MelonLogger.Msg("CONVERSION COMPLETED");
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
   