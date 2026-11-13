using RPGFramework.Battle;
using RPGFramework.Battle.Databases;
using RPGFramework.Battle.Providers;
using RPGFramework.Battle.SharedTypes;
using RPGFramework.DI;
using UnityEngine;

namespace Test2D.Battle
{
    /// <summary>
    /// The battle scene's bindings: the test project's placeholder enemies, groups and encounters, one empty arena and an
    /// audio provider with no fanfare, as the use cases' battles turn it off (item 35).
    /// </summary>
    internal sealed class BattleSceneInstaller : SceneInstallerBase
    {
        [SerializeField]
        private BattleAudioProvider m_AudioProvider;

        [SerializeField]
        private BattleEncounterDatabase m_Encounters;

        public override void InstallBindings(IDIContainer container)
        {
            container.BindSingletonFromInstance<IBattleAudioProvider>(m_AudioProvider);
            container.BindSingletonFromInstance<IBattleEncounterDatabase>(m_Encounters);

            container.BindSingleton<IBattleArenaDatabase, BattleArenaDatabase>();
        }
    }
}
