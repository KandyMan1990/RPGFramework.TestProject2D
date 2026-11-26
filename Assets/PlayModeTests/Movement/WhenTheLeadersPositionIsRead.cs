using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Movement
{
    /// <summary>
    /// UseCaseLeaderPositionRead walked freely: talked to, `GET_PARTY_MEMBER_POSITION 0`, the leader the player plays, into the
    /// project's three stand variables.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenTheLeadersPositionIsRead
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
        public IEnumerator ThenTheVariablesHoldIt()
        {
            yield return UseCaseGame.Enter(UseCaseField.MOVEMENT, 29);

            Transform player = UseCaseMovement.Body("Player0");

            yield return m_Input.Talk();
            yield return Wait.Until(() => (Stored() - player.position).magnitude < 0.01f, 2f, "where the player stands stored");
        }

        private static Vector3 Stored()
        {
            return new Vector3(UseCaseGame.ReadFloat(UseCaseProject.STAND_X), UseCaseGame.ReadFloat(UseCaseProject.STAND_Y), UseCaseGame.ReadFloat(UseCaseProject.STAND_Z));
        }
    }
}
