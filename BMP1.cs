using AmmoUpgrade;
using GHPC;
using GHPC.AI;
using GHPC.AI.Targeting;
using GHPC.Camera;
using GHPC.Effects;
using GHPC.Effects.Voices;
using GHPC.Equipment;
using GHPC.Equipment.Optics;
using GHPC.Mission;
using GHPC.Multiplayer.Entity;
using GHPC.State;
using GHPC.Thermals;
using GHPC.UI.Tips;
using GHPC.Utility;
using GHPC.Vehicle;
using GHPC.Weaponry;
using GHPC.Weapons;
using Harmony;
using HarmonyLib;
using MelonLoader;
using MelonLoader.Utils;
using ModUtil;
using NWH.VehiclePhysics;
using Reticle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.PostProcessing;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.GridLayoutGroup;

namespace AmmoUpgradePack
{
    public class BMP1 : ModUtil.Module
    {
        static MelonPreferences_Entry<bool> patch;

        static MelonPreferences_Entry<bool> pg15vnt;

        static MelonPreferences_Entry<string> atgm;


        public static void Config(MelonPreferences_Category cfg)
        {
            patch = cfg.CreateEntry<bool>("BMP 1 Conversion Toggle", true);
            patch.Comment = "///////////////////////////////////////"; 

            pg15vnt = cfg.CreateEntry<bool>("(BMP-1) PG-15VNT", true);
            pg15vnt.Comment = "tandem HEAT round for the 73mm gun";

            atgm = cfg.CreateEntry<string>("(BMP-1) ATGM Ammo", "9M14-2");
            atgm.Comment = "9M14M (vanilla), 9M14P (SACLOS) , 9M14-2 (SACLOS), 9M14-2M (Tandem, SACLOS)";
        }
        
        private static void HandleConversion(Vehicle vic)
        {
            if (vic == null) return;

            GameObject vic_go = vic.gameObject;

            if (vic.UniqueName != "BMP1" && vic.UniqueName != "BMP1_SA") return;
            MelonLogger.Msg("BMP-1 FOUND");
            WeaponsManager weapons_manager = vic.GetComponent<WeaponsManager>();
            LoadoutManager loadout_manager = vic.GetComponent<LoadoutManager>();
            GHPC.Weapons.AmmoRack rack = loadout_manager.RackLoadouts[0].Rack;
            WeaponSystemInfo main_gun_info = weapons_manager.Weapons[0];
            WeaponSystemInfo launcher_info = weapons_manager.Weapons[1];
            WeaponSystem main_gun = main_gun_info.Weapon;
            WeaponSystem launcher = launcher_info.Weapon;
            GHPC.Weapons.AmmoRack atgm_rack = launcher.Feed.ReadyRack;
            FireControlSystem fcs = vic.GetComponentInChildren<FireControlSystem>();
            UsableOptic day_optic = Util.GetDayOptic(main_gun.FCS);
            MelonLogger.Msg("Adding PG-15VNT");
            if (pg15vnt.Value == true)
            {
                loadout_manager.LoadedAmmoList.AmmoClips[0] = shellsPACT.clip_codex_pg15vnt;
            }
            string ammo_str = atgm.Value;

            if (ammo_str == "9M14P")
            {
                AmmoType.AmmoClip missile = ATGMPact.clip_9M14P;
                atgm_rack._clipTypes[0] = missile;
                atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    missile,
                    missile,
                    missile,
                    missile
                };
            }
            if (ammo_str == "9M14-2")
            {
                AmmoType.AmmoClip missile = ATGMPact.clip_9M142;
                atgm_rack._clipTypes[0] = missile;
                atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    missile,
                    missile,
                    missile,
                    missile
                };
            }
            if (ammo_str == "9M14-2M")
            {
                AmmoType.AmmoClip missile = ATGMPact.clip_9M142M;
                atgm_rack._clipTypes[0] = missile;
                atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    missile,
                    missile,
                    missile,
                    missile
                };
            }
            if (ammo_str == "9M14M")
            {
                AmmoType.AmmoClip missile = SharedAssets.codex_malyutka.ClipType;
                atgm_rack._clipTypes[0] = missile;
                atgm_rack.StoredClips = new List<AmmoType.AmmoClip>()
                {
                    missile,
                    missile,
                    missile,
                    missile
                };
            }
            if (ammo_str != "9M14M")
            {
                GameObject guidance_computer_obj = GameObject.Instantiate(new GameObject("guidance computer"), fcs.transform.parent);
                guidance_computer_obj.transform.localPosition = fcs.transform.localPosition + new Vector3(0, 0, 0f);
                guidance_computer_obj.transform.SetParent(day_optic.transform.parent, true);
                MissileGuidanceUnit computer = guidance_computer_obj.AddComponent<MissileGuidanceUnit>();
                computer.AimElement = guidance_computer_obj.transform;
                launcher.GuidanceUnit = computer;
                launcher.FCS = main_gun.FCS;
                launcher_info.FCS = main_gun_info.FCS;
            }
            loadout_manager.SpawnCurrentLoadout();
            launcher.Feed.AmmoTypeInBreech = null;
            main_gun.Feed.AmmoTypeInBreech = null;
            main_gun.Feed.Start();
            launcher.Feed.Start();
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
            if (!patch.Value) return;
            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Medium);
        }
    }
}