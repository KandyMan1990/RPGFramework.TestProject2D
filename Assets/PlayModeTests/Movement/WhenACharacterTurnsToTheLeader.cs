using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Movement
{
    /// <summary>
    /// UseCaseTurnsToLeader walked freely: talked to, `SET_ENTITY_ROTATION` back to none, `TURN_TO_PARTY_MEMBER_AND_WAIT 0 0.5 0`,
    /// the leader the player plays, `GET_ENTITY_DIRECTION` of itself and `ADD_MONEY 1`.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharacterTurnsToTheLeader
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
        public IEnumerator ThenTheScriptGoesOnOnceItHasTurned()
        {
            yield return UseCaseGame.Enter(UseCaseField.MOVEMENT, 28);

            Transform actor  = UseCaseMovement.Body("UseCaseTurnsToLeader");
            uint      before = UseCaseMovement.Money;

            yield return m_Input.Talk();
            yield return Wait.Seconds(0.2f);

            Assert.That(UseCaseMovement.Money, Is.EqualTo(before), "the script went on before the turn ended");

            yield return Wait.Until(() => UseCaseMovement.Money == before + 1, 3f, "the script went on once the turn ended");

            Assert.That(UseCaseMovement.Faces(UseCaseGame.ReadFloat(UseCaseProject.STAND_DIRECTION), 180f), "the direction read back as facing the player");
        }
    }
}
