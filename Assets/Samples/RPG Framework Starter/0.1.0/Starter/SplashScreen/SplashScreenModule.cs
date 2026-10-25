using System.Threading.Tasks;
using RPGFramework.Core;
using RPGFramework.Core.SharedTypes;
using UnityEngine;

namespace StarterSample.SplashScreen
{
    internal sealed class SplashScreenModule : ISplashScreenModule
    {
        private const float HOLD_SECONDS = 3f;

        private readonly ICoreModule m_CoreModule;

        internal SplashScreenModule(ICoreModule coreModule)
        {
            m_CoreModule = coreModule;
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

            m_CoreModule.RequestModuleChangeAsync(SplashScreenConstants.OUTCOME_FINISHED).FireAndForget();
        }
    }
}
