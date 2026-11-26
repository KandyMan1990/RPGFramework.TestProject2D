using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.ScreenAndCamera
{
    /// <summary>
    /// UseCaseScrollToLeader: talked to, `SCROLL_SCREEN_TO_POSITION` a point ahead of it at once, then
    /// `SCROLL_SCREEN_TO_PARTY_MEMBER 0`, the leader the player plays, over half a second, `WAIT_FOR_SCROLLING` and
    /// `ADD_MONEY 1`: the view back on the player.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenTheViewIsScrolledToTheLeader
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
        public IEnumerator ThenItIsOnThePlayer()
        {
            yield return UseCaseGame.Enter(UseCaseField.SCREEN, 10);

            uint      before = UseCaseGame.ReadUint("Money");
            Transform player = UseCaseScreen.Find(UseCaseField.Loaded().transform, "Player0").transform;

            yield return m_Input.Talk();
            yield return Wait.Until(() => UseCaseGame.ReadUint("Money") == before + 1, 4f, "the script went on once the view arrived");

            Assert.That((UseCaseScreen.Focus() - player.position).magnitude, Is.LessThan(0.01f), "the view on the player");
        }
    }
}
