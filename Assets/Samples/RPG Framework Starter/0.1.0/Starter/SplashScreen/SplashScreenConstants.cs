namespace StarterSample.SplashScreen
{
    public static class SplashScreenConstants
    {
        /// <summary>A game's own module id, clear of the framework's: Field 0, Menu 1, Battle 2 and the debug room 255.</summary>
        public const byte MODULE_ID = 128;

        /// <summary>The splash screen has finished, for the module router.</summary>
        public const byte OUTCOME_FINISHED = 1;
    }
}
