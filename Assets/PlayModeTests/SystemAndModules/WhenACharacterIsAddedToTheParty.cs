using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.SystemAndModules
{
    /// <summary>
    /// UseCaseAddToParty: talked to, `SET_PARTY` the first character alone, then `ADD_TO_PARTY` the second.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharacterIsAddedToTheParty
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
        public IEnumerator ThenTheyTakeTheFirstEmptySlot()
        {
            yield return UseCaseGame.Enter(UseCaseField.SYSTEM, 15);

            yield return m_Input.Talk();

            yield return Wait.Until(() => UseCaseParty.SlotOf(UseCaseParty.Second) == 1 && UseCaseParty.IsSlotEmpty(2), 5f, "the second character in slot 1");
        }
    }
}
