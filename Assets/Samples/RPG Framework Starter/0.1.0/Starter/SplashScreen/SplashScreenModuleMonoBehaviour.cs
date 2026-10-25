using RPGFramework.Core;
using RPGFramework.DI;
using UnityEngine;

namespace StarterSample.SplashScreen
{
    /// <summary>The splash screen's own bindings, on a component in its scene, as every module's are.</summary>
    internal sealed class SplashScreenModuleMonoBehaviour : MonoBehaviour, IModuleBindings
    {
        void IModuleBindings.Bind(IDIContainer sceneContainer)
        {
            sceneContainer.BindSingletonIfNotRegistered<ISplashScreenModule, SplashScreenModule>();
        }
    }
}
