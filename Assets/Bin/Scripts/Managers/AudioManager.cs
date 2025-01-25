using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        #region Champs
        //INSTPECTOR
        [SerializeField] AudioSource _audioSource;
        [SerializeField] List<AudioClip> _audioClips = new List<AudioClip>();
        //PRIVATE
        //PUBLIC
        public static AudioManager Instance;
        #endregion
        #region Default Informations
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        void Awake()
        {
            if (Instance == null)
            {
                //Debug.Log("InputManager is single");
                Instance = this;
            }
            else
            {
                Debug.Log("AudioManager already exist");
                Destroy(this);
            }
        }
        // Update is called once per frame
        #endregion
        #region Methods
        public void PlayerTakeDamage()
        {

            _audioSource.PlayOneShot(_audioClips[0]);
        }

        public void PlayerHeal()
        {
            _audioSource.PlayOneShot(_audioClips[1]);
        }

        public void PlayerSmallDeath()
        {
            _audioSource.PlayOneShot(_audioClips[2]);
        }

        public void PlayerBigDeath()
        {
            _audioSource.PlayOneShot(_audioClips[3]);
        }
        #endregion
    }
}