using AmmoUpgrade;
using GHPC.State;
using GHPC.Vehicle;
using GHPC.Weapons;
using MelonLoader;
using ModUtil;
using System.Collections;
using UnityEngine;

namespace AmmoUpgradePack
{
    public class Leo2a4 : Module
    {
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;
            if (vic.FriendlyName != "Leopard 2A4 (1988)") return; // this vehicle is such a pain in the ass for no reason
            MelonLogger.Msg("LEO2A4 VIC IS NOT NULL");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            MelonLogger.Msg("LEO2A4 HAS A WEAPON MANAGER");
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            MelonLogger.Msg("LEO2A4 HAS A LOADOUT MANAGER");
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            MelonLogger.Msg("LEO2A4 HAS A WEAPON INFO");
            WeaponSystem main_gun = main_gun_info.Weapon;
            MelonLogger.Msg("LEO2A4 HAS A WEAPON");
            MelonLogger.Msg("LEO2A4 FOUND");

            string ammostr = Leo2.ammo_ap.Value;
            if (ammostr == "DM53")
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsNATO.clip_codex_dm53;
            }
            if (ammostr == "DM33")
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsNATO.clip_codex_dm33;
            }
            if (ammostr == "DM23")
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = SharedAssetz.codex_dm120;
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
            if (!Leo2.patch.Value) return;
            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Low);
        }
    }
}