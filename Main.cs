using AmmoUpgrade;
using AmmoUpgradePack;
using GHPC;
using GHPC.Audio;
using GHPC.Camera;
using GHPC.Mission;
using GHPC.Player;
using GHPC.State;
using GHPC.Utility;
using GHPC.Vehicle;
using GHPC.Weaponry;
using GHPC.Weapons;
using MelonLoader;
using ModUtil;
using NWH.VehiclePhysics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

[assembly: MelonInfo(typeof(Mod), "Ammo Upgrade Pack", "1.1", "Aeiou6")]
[assembly: MelonGame("Radian Simulations LLC", "GHPC")]

namespace AmmoUpgrade
{ 
    public class Mod : MelonMod
    {
        private static ModuleManager module_manager;
        internal static Vehicle[] vics;
        internal static MelonPreferences_Category cfg;

        private GameObject game_manager;
        internal static AudioSettingsManager audio_settings_manager;
        internal static PlayerInput player_manager;
        internal static CameraManager camera_manager;
        private int valid_scene_count = 0;

        internal static FMOD.ChannelGroup audio_channel_group;

        public IEnumerator OnPlayerReady(GameState _)
        {
            game_manager = GameObject.Find("_APP_GHPC_");
            audio_settings_manager = game_manager.GetComponent<AudioSettingsManager>();
            player_manager = game_manager.GetComponent<PlayerInput>();
            camera_manager = game_manager.GetComponent<CameraManager>();
            vics = GameObject.FindObjectsByType<Vehicle>(FindObjectsSortMode.None);

            module_manager.LoadAllDynamicAssets();
            yield break;
        }
        public override void OnInitializeMelon()
        {
            module_manager = new ModuleManager("AmmoUpgradePack");
            MelonPreferences_Category cfg = MelonPreferences.CreateCategory("AmmoUpgradePack");
            Leo2.Config(cfg);
            Leo1.Config(cfg);
            M1.Config(cfg);
            M60.Config(cfg);
            T62.Config(cfg);

            module_manager.Add("SharedAssetz", new SharedAssetz());
            module_manager.Add("Shells", new Shells());
            module_manager.Add("Leo2", new Leo2());
            module_manager.Add("Leo1", new Leo1());
            module_manager.Add("M1", new M1());
            module_manager.Add("M60", new M60());
            module_manager.Add("T62", new T62());
            MelonLogger.Msg("Completed Intial loading");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            module_manager.UnloadAllDynamicAssets();

            if (sceneName == "MainMenu2_Scene" ||
                sceneName == "MainMenu2-1_Scene" ||
                sceneName == "t64_menu" ||
                sceneName == "leo2_menu")
            {
                MelonLogger.Msg("Loading Static Assets");
                module_manager.LoadAllStaticAssets();
                MelonLogger.Msg("Releasing Vanilla Assets");
                AssetUtil.ReleaseVanillaAssets();
                MelonLogger.Msg("Done");
            }
            if (Util.menu_screens.Contains(sceneName)) return;

            valid_scene_count++;
            if (valid_scene_count == 2)
            {
                StateController.RunOrDefer(GameState.PlayerReady, new GameStateEventHandler(AssetUtil.ReleaseTempVanillaAssetsDeferred), GameStatePriority.Medium);
                StateController.RunOrDefer(GameState.PlayerReady, new GameStateEventHandler(OnPlayerReady), GameStatePriority.Medium);
                Leo2.Init();
                Leo1.Init();
                M1.Init();
                M60.Init();
                T62.Init();
                valid_scene_count = 0;
            }
        }
    }
}
