using System.Threading.Tasks;
using RPGFramework.Core;
using StarterSample.SplashScreen;
using UnityEngine;

namespace StarterSample
{
    /// <summary>The game's first scene: builds Core from the global installer and enters the first module.</summary>
    internal sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private StarterGlobalInstaller m_GlobalInstaller;

        private void Start()
        {
            StartAsync().FireAndForget();
        }

        private async Task StartAsync()
        {
            ICoreModule core = await CoreModuleFactory.Create(m_GlobalInstaller, SplashScreenConstants.MODULE_ID);

            await core.StartAsync();
        }
    }
}
