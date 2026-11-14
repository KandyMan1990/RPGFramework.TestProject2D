using UnityEngine;

namespace Test2D.PlayModeTests
{
    /// <summary>
    /// What differs between the two projects' use cases: the game's installer and actions, the variables their scripts
    /// store into, and which way is up.
    /// </summary>
    internal static class UseCaseProject
    {
        internal const string GAME_INSTALLER = "Assets/Global Installer.asset";
        internal const string ACTIONS        = "Assets/Samples/RPG Framework Starter/0.1.0/Starter/Starter Input Actions.inputactions";
        internal const string CONFIRM        = "Player/Confirm";
        internal const string BATTLE_CANCEL  = "Player/Cancel";
        internal const string BATTLE_RESULT  = "UseCaseBattleResult";
        internal const string COUNTDOWN_LEFT = "UseCaseCountdownLeft";
        internal const string ANSWER         = "UseCaseAnswer";
        internal const string MUSIC_PLAYING  = "UseCaseMusicPlaying";
        internal const string GAME_OVER_FIELD = "GameOver";
        internal const string STAND_X         = "UseCaseStandX";
        internal const string STAND_Y         = "UseCaseStandY";
        internal const string STAND_Z         = "UseCaseStandZ";
        internal const string STAND_DIRECTION = "UseCaseStandDirection";
        internal const string IN_RANGE        = "UseCaseInRange";

        // Which way an entity faces, as GET_ENTITY_DIRECTION reads it: a 2D turn is anticlockwise from up the screen.
        internal const float FACING_RIGHT  = -90f;
        internal const float MARKER_FACING = 180f;

        internal static Vector3 Up => Vector3.forward;

        // The way an unturned spawn point faces the player.
        internal static Vector3 Ahead => Vector3.up;

        // Where UseCaseScrollToPoint scrolls the view.
        internal static Vector3 ScrollPoint => new Vector3(-7.4f, 6.5f, 0f);
    }
}
