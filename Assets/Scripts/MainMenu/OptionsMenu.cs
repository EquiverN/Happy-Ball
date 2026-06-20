using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        // Carga el valor guardado, si no existe usa 1f por defecto
        float savedMusic = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSFX = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Asigna los valores a los sliders
        musicSlider.value = savedMusic;
        sfxSlider.value = savedSFX;

        // Aplica el volumen al AudioMixer
        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSFX);
    }

    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Max(volume, 0.0001f);

        audioMixer.SetFloat(
            "MusicVolume",
            Mathf.Log10(volume) * 20f
        );
        Debug.Log("Music: " + volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        volume = Mathf.Max(volume, 0.0001f);

        audioMixer.SetFloat(
            "SFXVolume",
            Mathf.Log10(volume) * 20f
        );
        Debug.Log("SFX: " + volume);

        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}