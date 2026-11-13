using UnityEngine;

namespace Test2D.PlayModeTests
{
    /// <summary>
    /// What differs between the two projects' use cases: the game's installer and actions, the variables their scripts
    /// store into, and which way is up.
    /// </summary>
    internal static class UseCaseProject
    {
        internal const string GAME_INSTALLER = "Assets/Samples/RPG Framework Starter/0.1.0/Starter/Starter Global Installer.asset";
        internal const string ACTIONS        = "Assets/Samples/RPG Framework Starter/0.1.0/Starter/Starter Input Actions.inputactions";
        internal const string CONFIRM        = "Player/Confirm";
        internal const string BATTLE_CANCEL  = "Player/Cancel";
        internal const string BATTLE_RESULT  = "UseCaseBattleResult";
        internal const string COUNTDOWN_LEFT = "UseCaseCountdownLeft";
        internal const string GAME_OVER_FIELD = "GameOver";

        internal static Vector3 Up => Vector3.forward;
    }
}
