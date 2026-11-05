using System.Threading.Tasks;
using RPGFramework.Core;
using RPGFramework.Core.SharedTypes;
using RPGFramework.Menu.SharedTypes;
using RPGFramework.Menu.SharedTypes.Constants;
using RPGFramework.Menu.SharedTypes.Stores;
using UnityEngine;

namespace StarterSample.SplashScreen
{
    internal sealed class SplashScreenModule : ISplashScreenModule
    {
        private const float HOLD_SECONDS = 3f;

        private readonly ICoreModule    m_CoreModule;
        private readonly IMenuArgsStore m_MenuArgsStore;

        internal SplashScreenModule(ICoreModule coreModule, IMenuArgsStore menuArgsStore)
        {
            m_CoreModule    = coreModule;
            m_MenuArgsStore = menuArgsStore;
        }

        Task IModule.OnEnterAsync(byte entry)
        {
            return Task.CompletedTask;
        }

        Task IModule.OnExitAsync()
        {
            return Task.CompletedTask;
        }

        Task IModule.OnSuspendAsync()
        {
            return Task.CompletedTask;
        }

        Task IModule.OnResumeAsync()
        {
            return Task.CompletedTask;
        }

        void IModule.OnRevealed()
        {
            LeaveAfterHoldAsync().FireAndForget();
        }

        // Core's reveal fades the splash in, and the route out of it covers it again.
        private async Task LeaveAfterHoldAsync()
        {
            await Awaitable.WaitForSecondsAsync(HOLD_SECONDS);

            // The menu module opens whichever menu it is given, as the field gives it the party menu.
            m_MenuArgsStore.Set(new MenuArgs(MenuIds.Begin));
            m_CoreModule.RequestModuleChangeAsync(SplashScreenConstants.OUTCOME_FINISHED).FireAndForget();
        }
    }
}
