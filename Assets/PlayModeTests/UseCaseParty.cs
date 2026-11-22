using RPGFramework.Core.Store;
using RPGFramework.Hashing;

namespace Test2D.PlayModeTests
{
    /// <summary>The party as the party use cases' tests read it, by the characters <see cref="UseCaseProject" /> names.</summary>
    internal static class UseCaseParty
    {
        internal static ulong First => Fnv1a64.Hash(UseCaseProject.FIRST_CHARACTER);

        internal static ulong Second => Fnv1a64.Hash(UseCaseProject.SECOND_CHARACTER);

        internal static ulong Unjoined => Fnv1a64.Hash(UseCaseProject.UNJOINED_CHARACTER);

        internal static int SlotOf(ulong character) => Store.FindSlot(character);

        internal static bool IsSlotEmpty(int slot) => Store.GetRecordInSlot(slot) < 0;

        internal static bool HasJoined(ulong character)
        {
            int record = Store.FindRecord(character);

            return record >= 0 && Store.HasJoined(record);
        }

        private static IPartyStore Store => UseCaseGame.Resolve<IPartyStore>();
    }
}
