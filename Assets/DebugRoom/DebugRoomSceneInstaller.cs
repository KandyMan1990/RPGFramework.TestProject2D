using RPGFramework.Battle.Databases;
using RPGFramework.Battle.SharedTypes;
using RPGFramework.DebugRoom.SharedTypes;
using RPGFramework.DI;
using RPGFramework.Field;
using RPGFramework.Field.SharedTypes;
using Test2D.Battle;
using Test2D.Field;
using UnityEngine;

namespace Test2D.DebugRoom
{
    internal sealed class DebugRoomSceneInstaller : SceneInstallerBase
    {
        [SerializeField]
        private BattleEncounterDatabase m_Encounters;

        public override void InstallBindings(IDIContainer container)
        {
            container.BindInterfacesToSelfSingleton<FieldDatabase>();
            container.BindSingleton<IDebugSpawnPointLoader, DebugSpawnPointLoader>();
            container.BindSingleton<IDebugBattleArenaDatabase, BattleArenaDatabase>();
            container.BindSingletonFromInstance<IDebugBattleEncounterDatabase>(m_Encounters);
        }
    }
}
