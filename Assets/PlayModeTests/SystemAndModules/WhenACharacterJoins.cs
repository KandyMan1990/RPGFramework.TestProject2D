using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Test2D.PlayModeTests.SystemAndModules
{
    /// <summary>
    /// UseCaseCharacterJoins: talked to, `SET_CHARACTER_JOINED` a character not joined true, then `GET_CHARACTER_JOINED` them.
    /// </summary>
    [PrebuildSetup("Test2D.PlayModeTests.Editor.UseCaseBundles")]
    internal sealed class WhenACharacterJoins
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
        public IEnumerator ThenTheScriptReadsThatTheyHave()
        {
            yield return UseCaseGame.Enter(UseCaseField.SYSTEM, 20);

            yield return m_Input.Talk();

            yield return Wait.Until(() => UseCaseGame.ReadBool(UseCaseProject.CHARACTER_JOINED) && UseCaseParty.HasJoined(UseCaseParty.Unjoined), 5f, "the character joined and read so");
        }
    }
}
