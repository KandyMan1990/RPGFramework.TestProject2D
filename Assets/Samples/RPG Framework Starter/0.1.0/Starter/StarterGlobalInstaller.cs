using System.Threading.Tasks;
using RPGFramework.Audio;
using RPGFramework.Audio.Music;
using RPGFramework.Audio.Sfx;
using RPGFramework.Battle.SharedTypes.Stores;
using RPGFramework.Battle.Stores;
using RPGFramework.Core;
using RPGFramework.Core.Audio;
using RPGFramework.Core.Databases;
using RPGFramework.Core.Dialogue.UI;
using RPGFramework.Core.Memory;
using RPGFramework.Core.Settings;
using RPGFramework.Core.SharedTypes;
using RPGFramework.Core.Transitions;
using RPGFramework.DI;
using RPGFramework.Field;
using RPGFramework.Field.SharedTypes.Stores;
using RPGFramework.Localisation;
using RPGFramework.Menu;
using RPGFramework.Menu.SharedTypes.Stores;
using RPGFramework.ModuleRouter;
using UnityEngine;
using UnityEngine.Audio;

namespace StarterSample
{
    /// <summary>
    /// The game's global bindings, made once as the game starts and kept for its life: what the framework asks the game
    /// for, and the stores the modules share. Core and each module bind their own types after these.
    /// </summary>
    internal sealed class StarterGlobalInstaller : GlobalInstallerBase
    {
        [SerializeField]
        private MusicAssetProvider m_MusicProvider;

        [SerializeField]
        private AudioMixerGroup[] m_MusicMixerGroups;

        [SerializeField]
        private SfxAssetProvider m_SfxProvider;

        [SerializeField]
        private AudioMixerGroup[] m_SfxMixerGroups;

        [SerializeField]
        private DialogueWindowUIProvider m_DialogueWindowUIProvider;

        [SerializeField]
        private VariableMapAsset m_VariableMap;

        [SerializeField]
        private TransitionConfig m_TransitionConfig;

        [SerializeField]
        private TransitionDatabase m_TransitionDatabase;

        [SerializeField]
        private ModuleRouterConfig m_ModuleRouterConfig;

        public override void InstallBindings(IDIContainer container)
        {
            container.BindSingleton<ILocalisationService, LocalisationService>().AsNonLazy();

            ISfxPlayer sfxPlayer = new UnitySfxPlayer();
            sfxPlayer.SetSfxAssetProvider(m_SfxProvider);
            sfxPlayer.SetStemMixerGroups(m_SfxMixerGroups);
            container.BindSingletonFromInstance(sfxPlayer);

            IMusicPlayer musicPlayer = new UnityMusicPlayer();
            musicPlayer.SetMusicAssetProvider(m_MusicProvider);
            musicPlayer.SetStemMixerGroups(m_MusicMixerGroups);
            container.BindSingletonFromInstance(musicPlayer);

#if ENABLE_RPG_FRAMEWORK_DEBUG
            // The players' own providers, so the debug room lists what they play.
            container.BindSingletonFromInstance<IDebugSfxAssetProvider>(m_SfxProvider);
            container.BindSingletonFromInstance<IDebugMusicAssetProvider>(m_MusicProvider);
#endif

            container.BindSingletonFromInstance<IAudioIntentPlayer>(new SilentAudioIntentPlayer());

            container.BindSingletonFromInstance<ITransitionConfig>(m_TransitionConfig);
            container.BindSingletonFromInstance<ITransitionDatabase>(m_TransitionDatabase);
            container.BindSingletonFromInstance<IModuleRouterConfig>(m_ModuleRouterConfig);
            container.BindSingletonFromInstance<IDialogueWindowUIProvider>(m_DialogueWindowUIProvider);

            container.BindSingletonFromInstance<IMemoryServiceArgs>(m_VariableMap);
            container.BindSingletonFromInstance<ITempMemoryArgs>(m_VariableMap);
            container.BindSingletonFromInstance<IVariableMap>(m_VariableMap);

            container.BindSingleton<IModuleDatabase, StarterModuleDatabase>();
            container.BindSingleton<ISceneDatabase, StarterSceneDatabase>();
            container.BindSingleton<IModuleRouter, StarterModuleRouter>();
            container.BindSingleton<IDefaultSettings, StarterDefaultSettings>();

            // The modules' shared stores, used before the module that owns each has loaded.
            container.BindSingleton<IFieldArgsStore, FieldArgsStore>();
            container.BindSingleton<IGameOverFieldStore, GameOverFieldStore>();
            container.BindSingleton<IFieldResumeDataStore, FieldResumeDataStore>();
            container.BindSingleton<IMenuArgsStore, MenuArgsStore>();
            container.BindSingleton<IBattleArgsStore, BattleArgsStore>();
            container.BindSingleton<IBattleModeStore, BattleModeStore>();
            container.BindSingleton<IBattleCompleteStateStore, BattleCompleteStateStore>();
        }

        public override Task Bootstrap(IDIResolver resolver)
        {
            ILocalisationService localisationService = resolver.Resolve<ILocalisationService>();

            return localisationService.InitialiseAsync();
        }
    }
}
