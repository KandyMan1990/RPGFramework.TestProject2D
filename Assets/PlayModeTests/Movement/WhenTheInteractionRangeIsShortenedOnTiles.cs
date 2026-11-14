using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Movement
{
    /// <summary>
    /// UseCaseInteractionRange on tiles: talked to, `ADD_MONEY 1` and `SET_INTERACTION_RANGE 1`, the player two away.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenTheInteractionRangeIsShortenedOnTiles
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
        public IEnumerator ThenThePlayerIsOutOfReach()
        {
            yield return UseCaseGame.Enter(UseCaseField.MOVEMENT_TILES, 22);

            uint before = UseCaseMovement.Money;

            yield return m_Input.Talk();
            yield return Wait.Until(() => UseCaseMovement.Money == before + 1, 2f, "talked to");
            yield return m_Input.Talk();
            yield return Wait.Seconds(0.5f);

            Assert.That(UseCaseMovement.Money, Is.EqualTo(before + 1), "talked to again from out of its reach");
        }
    }
}
