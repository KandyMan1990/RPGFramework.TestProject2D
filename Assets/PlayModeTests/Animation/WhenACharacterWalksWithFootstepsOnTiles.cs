using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Animation
{
    /// <summary>
    /// UseCaseFootsteps on tiles: talked to, `SET_FOOTSTEP_SOUND UseCaseSound false`, `SET_FOOTSTEPS_ENABLED true false`,
    /// `MOVE_ENTITY_AND_WAIT` three to its right and `ADD_MONEY 1`, on its base `Walk`.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharacterWalksWithFootstepsOnTiles
    {
        private UseCaseInput m_Input;

        [SetUp]
        public void SetUp()
        {
            m_Input = new UseCaseInput();
        }

        [TearDown]
        public void TearDown()
        {
            m_Input.TearDown();
        }

        [UnityTest]
        public IEnumerator ThenItsStepsAreHeard()
        {
            yield return UseCaseGame.Enter(UseCaseField.ANIMATION_TILES, 24);

            Transform actor  = UseCaseMovement.Body("UseCaseFootsteps");
            uint      before = UseCaseMovement.Money;

            yield return UseCaseAudio.Silence();
            yield return m_Input.Talk();
            yield return Wait.Until(() => UseCaseAudio.Sound("UseCaseSound") != null, 3f, "a step heard");
            yield return Wait.Until(() => UseCaseMovement.Money == before + 1, 5f, "the script went on once it had arrived");
        }
    }
}
