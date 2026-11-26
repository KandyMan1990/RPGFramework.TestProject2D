using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Movement
{
    /// <summary>
    /// UseCaseLeaderDirectionRead: talked to, the project's stand direction set to 45, `GET_PARTY_MEMBER_DIRECTION 0`, the
    /// leader the player plays, into it, and `ADD_MONEY 1`.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenTheLeadersDirectionIsRead
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
        public IEnumerator ThenTheVariableHoldsTheWayThePlayerFaces()
        {
            yield return UseCaseGame.Enter(UseCaseField.MOVEMENT, 30);

            uint before = UseCaseMovement.Money;

            yield return m_Input.Talk();
            yield return Wait.Until(() => UseCaseMovement.Money == before + 1, 2f, "the script ran");

            Assert.That(UseCaseMovement.Faces(UseCaseGame.ReadFloat(UseCaseProject.STAND_DIRECTION), 0f), "the direction read back as the player's, facing ahead from its spawn point");
        }
    }
}
