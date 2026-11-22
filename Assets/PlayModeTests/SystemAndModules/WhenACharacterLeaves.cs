using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.SystemAndModules
{
    /// <summary>
    /// UseCaseCharacterLeaves: talked to, `SET_PARTY` three characters, then `SET_CHARACTER_JOINED` the second false.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharacterLeaves
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
        public IEnumerator ThenTheyLeaveThePartyToo()
        {
            yield return UseCaseGame.Enter(UseCaseField.SYSTEM, 19);

            yield return m_Input.Talk();

            yield return Wait.Until(() => !UseCaseParty.HasJoined(UseCaseParty.Second) && UseCaseParty.IsSlotEmpty(1) && UseCaseParty.SlotOf(UseCaseParty.Unjoined) == 2, 5f, "the second character gone, their slot empty");
        }
    }
}
