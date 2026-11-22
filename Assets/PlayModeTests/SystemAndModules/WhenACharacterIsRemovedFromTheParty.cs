using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.SystemAndModules
{
    /// <summary>
    /// UseCaseRemoveFromParty: talked to, `SET_PARTY` the first and second characters, then `REMOVE_FROM_PARTY` the second.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharacterIsRemovedFromTheParty
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
        public IEnumerator ThenTheirSlotIsLeftEmptyAndTheyStayJoined()
        {
            yield return UseCaseGame.Enter(UseCaseField.SYSTEM, 16);

            yield return m_Input.Talk();

            yield return Wait.Until(() => UseCaseParty.HasJoined(UseCaseParty.Second) && UseCaseParty.IsSlotEmpty(1) && UseCaseParty.SlotOf(UseCaseParty.First) == 0, 5f, "the second character out of slot 1, still joined");
        }
    }
}
