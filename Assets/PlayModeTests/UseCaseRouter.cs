using RPGFramework.Core.SharedTypes;
using RPGFramework.Field.SharedTypes.Constants;
using RPGFramework.ModuleRouter;

namespace Test2D.PlayModeTests
{
    /// <summary>
    /// The framework's default router, with one route of the tests' own: from whatever is on top to the field. The
    /// Starter's router is internal to its sample, and its one route of its own, the splash screen's, never runs here.
    /// </summary>
    internal sealed class UseCaseRouter : IModuleRouter
    {
        // Clear of every module's outcomes, which are small numbers, and the debug room's 255.
        internal const byte ENTER_FIELD = 254;

        private readonly IModuleRouter m_Default;

        public UseCaseRouter(IDefaultModuleRouter defaultRouter)
        {
            m_Default = defaultRouter;
        }

        ModuleChange IModuleRouter.Route(byte moduleId, byte outcome)
        {
            return outcome == ENTER_FIELD ? ModuleChange.Clear(FieldConstants.MODULE_ID) : m_Default.Route(moduleId, outcome);
        }
    }
}
