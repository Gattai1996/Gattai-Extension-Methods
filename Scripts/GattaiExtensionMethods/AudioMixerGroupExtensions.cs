using UnityEngine.Audio;

namespace GattaiExtensionMethods
{
    public static class AudioMixerGroupExtensions
    {
        public static void SetVolume(this AudioMixerGroup audioMixerGroup, float value) => 
            audioMixerGroup.audioMixer.SetFloat("Volume", value);
    }
}