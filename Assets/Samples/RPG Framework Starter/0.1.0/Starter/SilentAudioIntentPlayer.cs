using System.Threading.Tasks;
using RPGFramework.Core.Audio;

namespace StarterSample
{
    /// <summary>Plays no sound for anything the menus or the field ask for, until the game gives them sounds.</summary>
    internal sealed class SilentAudioIntentPlayer : IAudioIntentPlayer
    {
        Task IAudioIntentPlayer.PlayAsync(AudioIntent intent, AudioContext context)
        {
            return Task.CompletedTask;
        }
    }
}
