using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.SystemAndModules
{
    /// <summary>
    /// UseCaseSetParty: talked to, `SET_PARTY` the second character, then the first.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenThePartyIsSet
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
        public IEnumerator ThenItHoldsTheCharactersInOrder()
        {
            yield return UseCaseGame.Enter(UseCaseField.SYSTEM, 17);

            yield return m_Input.Talk();

            yield return Wait.Until(() => UseCaseParty.SlotOf(UseCaseParty.Second) == 0 && UseCaseParty.SlotOf(UseCaseParty.First) == 1 && UseCaseParty.IsSlotEmpty(2), 5f, "the second character leading the first");
        }
    }
}
