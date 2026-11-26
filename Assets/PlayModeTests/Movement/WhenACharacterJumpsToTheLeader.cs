using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Movement
{
    /// <summary>
    /// UseCaseJumpsToLeader walked freely: talked to, `JUMP_ENTITY_TO_PARTY_MEMBER_AND_WAIT 0`, the leader the player plays,
    /// over half a second and `ADD_MONEY 1`.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharacterJumpsToTheLeader
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
        public IEnumerator ThenItLandsAtThePointAndTheScriptGoesOn()
        {
            yield return UseCaseGame.Enter(UseCaseField.MOVEMENT, 31);

            Transform actor  = UseCaseMovement.Body("UseCaseJumpsToLeader");
            Vector3   target = UseCaseMovement.Body("Player0").position;
            uint      before = UseCaseMovement.Money;

            yield return m_Input.Talk();
            yield return Wait.Seconds(0.2f);

            Assert.That(UseCaseMovement.Money, Is.EqualTo(before), "the script went on before it landed");

            yield return Wait.Until(() => UseCaseMovement.Money == before + 1, 3f, "the script went on once it landed");

            Assert.That(UseCaseMovement.Apart(actor, target), Is.LessThan(0.05f), "landed where the player stands");
        }
    }
}
