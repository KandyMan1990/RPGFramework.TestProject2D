using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Animation
{
    /// <summary>
    /// UseCaseFootstepsOff on tiles: talked to, `SET_FOOTSTEP_SOUND UseCaseSound false`, its footsteps turned on and off again, `MOVE_ENTITY_AND_WAIT`
    /// three to its right and `ADD_MONEY 1`.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharacterWalksWithFootstepsOffOnTiles
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
        public IEnumerator ThenNoStepIsHeard()
        {
            yield return UseCaseGame.Enter(UseCaseField.ANIMATION_TILES, 25);

            Transform actor  = UseCaseMovement.Body("UseCaseFootstepsOff");
            uint      before = UseCaseMovement.Money;

            yield return UseCaseAudio.Silence();
            yield return m_Input.Talk();

            bool  heard = false;
            float until = Time.realtimeSinceStartup + 5f;

            while (UseCaseMovement.Money != before + 1 && Time.realtimeSinceStartup < until)
            {
                heard |= UseCaseAudio.Sound("UseCaseSound") != null;

                yield return null;
            }

            Assert.That(UseCaseMovement.Money, Is.EqualTo(before + 1), "the script went on once it had arrived");
            Assert.That(heard, Is.False, "a step heard with its footsteps off");
        }
    }
}
