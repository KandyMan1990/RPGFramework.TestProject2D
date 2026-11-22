using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.SystemAndModules
{
    /// <summary>
    /// UseCasePartySlot: talked to, `SET_PARTY` the first and second characters, then `GET_PARTY_SLOT` the second.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharactersPartySlotIsAskedFor
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
        public IEnumerator ThenTheVariableHoldsIt()
        {
            yield return UseCaseGame.Enter(UseCaseField.SYSTEM, 18);

            yield return m_Input.Talk();

            yield return Wait.Until(() => UseCaseGame.ReadByte(UseCaseProject.PARTY_SLOT) == 1, 5f, "the second character's slot stored");
        }
    }
}
