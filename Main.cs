using System.Collections;
using System.Linq;
using GHPC.State;
using MelonLoader;
using ModNameSpace;
using ModUtil;

[assembly: MelonInfo(typeof(Mod), "Mod Name", "1.0.0", "Author")]
[assembly: MelonGame("Radian Simulations LLC", "GHPC")]

namespace ModNameSpace
{
    public class Mod : MelonMod
    {
        private ModuleManager module_manager;

        internal IEnumerator OnGameReady(GameState _)
        {
            module_manager.LoadAllDynamicAssets();

            yield break;
        }

        public override void OnInitializeMelon()
        {
            module_manager = new ModuleManager("InternalModName");
            // module_manager.Add("ModuleName", new Module());
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            module_manager.UnloadAllDynamicAssets();

            if (sceneName == "MainMenu2_Scene" || sceneName == "MainMenu2-1_Scene" || sceneName == "t64_menu")
            {
                module_manager.LoadAllStaticAssets();
                AssetUtil.ReleaseVanillaAssets();
            }

            if (Util.menu_screens.Contains(sceneName)) return;

            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(OnGameReady), GameStatePriority.Medium);
        }
    }
}
