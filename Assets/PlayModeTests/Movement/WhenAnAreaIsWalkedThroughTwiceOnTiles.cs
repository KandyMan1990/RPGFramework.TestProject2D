using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.Movement
{
    /// <summary>
    /// UseCaseCollisionArea on tiles: walked into, `ADD_MONEY 1` and `COLLISION_TRIGGER_ACTIVATION false` on entering: walked out and in
    /// again, it runs no more.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenAnAreaIsWalkedThroughTwiceOnTiles
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
        public IEnumerator ThenItsEnterScriptRunsOnce()
        {
            yield return UseCaseGame.Enter(UseCaseField.MOVEMENT_TILES, 25);

            uint before = UseCaseMovement.Money;

            m_Input.Hold(m_Input.Keyboard.wKey);

            yield return Wait.Until(() => UseCaseMovement.Money == before + 1, 3f, "its enter script run");
            yield return Wait.Seconds(0.5f);

            m_Input.Release(m_Input.Keyboard.wKey);
            m_Input.Hold(m_Input.Keyboard.sKey);

            yield return Wait.Seconds(1.5f);

            m_Input.Release(m_Input.Keyboard.sKey);
            m_Input.Hold(m_Input.Keyboard.wKey);

            yield return Wait.Seconds(1.5f);

            m_Input.Release(m_Input.Keyboard.wKey);

            Assert.That(UseCaseMovement.Money, Is.EqualTo(before + 1), "its enter script run again with its trigger off");
        }
    }
}
