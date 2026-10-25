using RPGFramework.Audio;
using RPGFramework.Battle.SharedTypes.Stores;
using RPGFramework.Core.SharedTypes;
using RPGFramework.Core.Store;
using RPGFramework.Core.Transitions;
using RPGFramework.Field.SharedTypes.Stores;
using RPGFramework.Menu.SharedTypes.Constants;
using RPGFramework.Menu.SharedTypes.Stores;
using RPGFramework.ModuleRouter;
using StarterSample.SplashScreen;

namespace StarterSample
{
    /// <summary>The framework's routes, and the splash screen's, a module of the game's own: on to the title menu.</summary>
    internal sealed class StarterModuleRouter : DefaultModuleRouter
    {
        internal StarterModuleRouter(ICurrentModuleStore       currentModuleStore,
                                     IBattleArgsStore          battleArgsStore,
                                     IBattleModeStore          battleModeStore,
                                     IBattleCompleteStateStore battleCompleteStateStore,
                                     IBattleMusicStore         battleMusicStore,
                                     IPausedMusicStore         pausedMusicStore,
                                     IFieldArgsStore           fieldArgsStore,
                                     IGameOverFieldStore       gameOverFieldStore,
                                     IMenuArgsStore            menuArgsStore,
                                     IMusicPlayer              musicPlayer,
                                     IModuleRouterConfig       config,
                                     ITransitionService        transitions) : base(currentModuleStore,
                                                                                   battleArgsStore,
                                                                                   battleModeStore,
                                                                                   battleCompleteStateStore,
                                                                                   battleMusicStore,
                                                                                   pausedMusicStore,
                                                                                   fieldArgsStore,
                                                                                   gameOverFieldStore,
                                                                                   menuArgsStore,
                                                                                   musicPlayer,
                                                                                   config,
                                                                                   transitions)
        {
        }

        protected override ModuleChange Route(byte moduleId, byte outcome)
        {
            if (moduleId == SplashScreenConstants.MODULE_ID && outcome == SplashScreenConstants.OUTCOME_FINISHED)
            {
                return ModuleChange.Clear(MenuConstants.MODULE_ID);
            }

            return base.Route(moduleId, outcome);
        }
    }
}
