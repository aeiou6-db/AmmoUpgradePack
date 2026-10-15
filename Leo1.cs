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
    public class Leo1 : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> dm33;
        public static void Config(MelonPreferences_Category cfg)
        {
            dm33 = cfg.CreateEntry<bool>("(LEOPARD 1) DM33 APFSDS-T", true);
            dm33.Comment = "Adds 105mm DM33 to the Leopard 1s";
        }
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (vic.UniqueName != "LEO1A3"
                && vic.UniqueName != "LEO1A1"
                && vic.UniqueName != "LEO1A1A2"
                && vic.UniqueName != "LEO1A1A3"
                && vic.UniqueName != "LEO1A1A4"
                && vic.UniqueName != "LEO1A3A1"
                && vic.UniqueName != "LEO1A3A1"
                && vic.UniqueName != "LEO1A3A1"
                && vic.UniqueName != "LEO1A3A2"
                && vic.UniqueName != "LEO1A3A3"
                && vic.UniqueName != "LEO1A4") 
                return; // list of doom
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystem main_gun = main_gun_info.Weapon;
            if (main_gun_info.Name == "120mm Gun M256") return;
            loadout_manager.LoadedAmmoList.AmmoClips[0] = Shells.clip_codex_dm105_33;
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
            StateController.RunOrDefer(GameState.PlayerReady, new GameStateEventHandler(Convert), GameStatePriority.Low);
        }
    }
}
   