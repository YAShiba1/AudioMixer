using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private const string MasterVolumeParameter = "MasterVolume";
    private const string MusicVolumeParameter = "MusicVolume";
    private const string ButtonsVolumeParameter = "ButtonsVolume";

    public void ToggleMasterVolume()
    {
        float maximumDbOfVolume = 0f;
        float minimumDbOfVolume = -80f;

        bool result = _mixer.audioMixer.GetFloat(MasterVolumeParameter, out float value);

        if (result == true && value != 0)
        {
            _mixer.audioMixer.SetFloat(MasterVolumeParameter, maximumDbOfVolume);
        }
        else
        {
            _mixer.audioMixer.SetFloat(MasterVolumeParameter, minimumDbOfVolume);
        }
    }

    public void ChangeButtonsVolume(float volume)
    {
        ChangeVolume(ButtonsVolumeParameter, volume);
    }
    
    public void ChangeMusicVolume(float volume)
    {
        ChangeVolume(MusicVolumeParameter, volume);
    }

    private void ChangeVolume(string nameOfMixer, float volume)
    {
        float dbVolumeStep = 20;

        _mixer.audioMixer.SetFloat(nameOfMixer, Mathf.Log10(volume) * dbVolumeStep);
    }
}
