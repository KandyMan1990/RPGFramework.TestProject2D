using RPGFramework.DI;
using RPGFramework.Field;

namespace Test2D.Field
{
    /// <summary>
    /// The field scene's bindings: this project's own field database, listing the 2D Field Sample's fields and the use
    /// cases, which export writes here rather than into the sample.
    /// </summary>
    internal sealed class FieldModuleSceneInstaller : SceneInstallerBase
    {
        public override void InstallBindings(IDIContainer container)
        {
            container.BindSingleton<IFieldDatabase, FieldDatabase>();
        }
    }
}
