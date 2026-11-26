using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Movement
{
    /// <summary>
    /// UseCaseFacesLeader walked freely: talked to, `SET_ENTITY_ROTATION` back to none, `SET_DIRECTION_TO_FACE_PARTY_MEMBER 0`, the
    /// leader the player plays, and `GET_ENTITY_DIRECTION` of itself: turned round to the player behind it.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharacterIsFacedToTheLeader
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
        public IEnumerator ThenItFacesThePlayer()
        {
            yield return UseCaseGame.Enter(UseCaseField.MOVEMENT, 32);

            Transform actor = UseCaseMovement.Body("UseCaseFacesLeader");

            yield return m_Input.Talk();
            yield return Wait.Until(() => UseCaseMovement.Faces(UseCaseGame.ReadFloat(UseCaseProject.STAND_DIRECTION), 180f), 2f, "the direction read back as facing the player");
        }
    }
}
