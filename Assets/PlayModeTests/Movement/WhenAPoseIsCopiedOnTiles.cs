using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Movement
{
    /// <summary>
    /// UseCasePoseCopied on tiles: talked to, `SET_ENTITY_ROTATION` back to none, `COPY_ENTITY_POSE` of `UseCasePoseMarker` three to its
    /// right, and `GET_ENTITY_DIRECTION` of itself.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenAPoseIsCopiedOnTiles
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
        public IEnumerator ThenItStandsAndFacesAsTheMarkerDoes()
        {
            yield return UseCaseGame.Enter(UseCaseField.MOVEMENT_TILES, 18);

            Transform actor  = UseCaseMovement.Body("UseCasePoseCopied");
            Transform marker = UseCaseMovement.Body("UseCasePoseMarker");

            yield return m_Input.Talk();
            yield return Wait.Until(() => UseCaseMovement.Apart(actor, marker) < 0.01f, 2f, "standing where the marker stands");
            yield return Wait.Until(() => UseCaseMovement.Faces(UseCaseGame.ReadFloat(UseCaseProject.STAND_DIRECTION), UseCaseProject.MARKER_FACING), 2f, "facing the way the marker faces");
        }
    }
}
