using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace Options
{
    public class AudioSettingsManager : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        // Reference to your Audio Mixer
        [SerializeField] AudioMixer _audioMixer;

        // UI Sliders for controlling volumes
        [SerializeField] Slider _masterVolumeSlider;
        [SerializeField] Slider _musicVolumeSlider;
        [SerializeField] Slider _sfxVolumeSlider;

        // Keys to store volume levels in PlayerPrefs
        const string _MasterVolumeKey = "MasterVolume";
        const string _MusicVolumeKey = "MusicVolume";
        const string _SFXVolumeKey = "SFXVolume";
        //PRIVATE
        //PUBLIC
        #endregion
        #region Default Informations
        #endregion
        #region Unity LifeCycle
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // Load the saved volume levels
            LoadVolumeSettings();

            // Assign the event listeners to the sliders
            _masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
            _musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
            _sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        }

        // Update is called once per frame

        //LateUpdate is called every frame, just after the Update method.
        //It is often used for anything that depends on another update, 
              //typically cameras or objects that track other objects. If you want 
              //to be sure that the script reacts after all other calculations of an image, LateUpdate is useful.


        //FixedUpdate is called at fixed time intervals, regardless of the game's frame rate.
        //It is mainly used for everything related to physics. Updates to physical objects, 
              //like rigidbodies, should be done at a constant frequency for stability reasons.

        #endregion
        #region Methods
        // Set the master volume and save the value
        public void SetMasterVolume(float volume)
        {
            if (volume <= 0.001f)
            {
                _audioMixer.SetFloat("MasterVolume", -80f);  // Silence complet
            }
            else
            {
                _audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
            }

            //_audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20); // Logarithmic scale for human hearing
            PlayerPrefs.SetFloat(_MasterVolumeKey, volume);
            PlayerPrefs.Save();
        }

        // Set the music volume and save the value
        public void SetMusicVolume(float volume)
        {
            if (volume <= 0.001f)
            {
                _audioMixer.SetFloat("MusicVolume", -80f);  // Silence complet
            }
            else
            {
                _audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
            }

            //_audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat(_MusicVolumeKey, volume);
            PlayerPrefs.Save();
        }

        // Set the SFX volume and save the value
        public void SetSFXVolume(float volume)
        {
            if (volume <= 0.001f)
            {
                _audioMixer.SetFloat("SFXVolume", -80f);  // Silence complet
            }
            else
            {
                _audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
            }

            //_audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat(_SFXVolumeKey, volume);
            PlayerPrefs.Save();
        }

        // Load the saved volume levels from PlayerPrefs
        private void LoadVolumeSettings()
        {
            // Check if PlayerPrefs has saved data for each volume level, otherwise set default to 1 (100%)
            float savedMasterVolume = PlayerPrefs.HasKey(_MasterVolumeKey) ? PlayerPrefs.GetFloat(_MasterVolumeKey) : 1f;
            float savedMusicVolume = PlayerPrefs.HasKey(_MusicVolumeKey) ? PlayerPrefs.GetFloat(_MusicVolumeKey) : 1f;
            float savedSFXVolume = PlayerPrefs.HasKey(_SFXVolumeKey) ? PlayerPrefs.GetFloat(_SFXVolumeKey) : 1f;

            // Apply the loaded volume levels
            _masterVolumeSlider.value = savedMasterVolume;
            _musicVolumeSlider.value = savedMusicVolume;
            _sfxVolumeSlider.value = savedSFXVolume;

            // Apply these volumes to the Audio Mixer
            _audioMixer.SetFloat("MasterVolume", Mathf.Log10(savedMasterVolume) * 20);
            _audioMixer.SetFloat("MusicVolume", Mathf.Log10(savedMusicVolume) * 20);
            _audioMixer.SetFloat("SFXVolume", Mathf.Log10(savedSFXVolume) * 20);
        }
        #endregion
    }
}
