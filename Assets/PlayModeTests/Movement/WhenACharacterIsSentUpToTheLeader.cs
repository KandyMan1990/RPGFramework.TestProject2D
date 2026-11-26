using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Movement
{
    /// <summary>
    /// UseCaseWalkToLeader walked freely: talked to, `SET_ENTITY_POSITION` four to its right, `MOVE_ENTITY_TO_PARTY_MEMBER 0 1.5`,
    /// the leader the player plays, `ADD_MONEY 1`, `WAIT_FOR_MOVEMENT` and `ADD_MONEY 1`.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharacterIsSentUpToTheLeader
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
        public IEnumerator ThenTheScriptGoesOnAndThenWaitsForIt()
        {
            yield return UseCaseGame.Enter(UseCaseField.MOVEMENT, 34);

            Transform actor  = UseCaseMovement.Body("UseCaseWalkToLeader");
            Transform player = UseCaseMovement.Body("Player0");
            uint      before = UseCaseMovement.Money;

            yield return m_Input.Talk();
            yield return Wait.Until(() => UseCaseMovement.Money >= before + 1, 2f, "the script went on as it set off");

            Assert.That(UseCaseMovement.Apart(actor, player), Is.GreaterThan(2f), "the script waited for it to arrive before going on");

            yield return Wait.Until(() => UseCaseMovement.Money == before + 2, 6f, "the script went on once it arrived");

            Assert.That(UseCaseMovement.Apart(actor, player), Is.InRange(0.9f, 1.7f), "it stopped short of the player");
        }
    }
}
