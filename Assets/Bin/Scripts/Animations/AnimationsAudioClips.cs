using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace AnimationsAudio
{
    public class AnimationsAudioClips : MonoBehaviour
    {
        #region Champs
        //INSTPECTOR
        [SerializeField] AudioSource _audioSource;
        [SerializeField] List<AudioClip> _clips = new List<AudioClip>();
        //PRIVATE
        //PUBLIC
        #endregion
        #region Default Informations
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        // Update is called once per frame
        #endregion
        #region Methods
        public void PlayerBounce()
        {
            _audioSource.PlayOneShot(_clips[0]);
        }
        #endregion
    }
}