using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Entities;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace EnvironmentObstacles
{
    public class openDoor : MonoBehaviour
    {
        #region Champs
        //INSTPECTOR
        [Header("Informations")]
        [SerializeField] float _timer;
        [SerializeField] string _menuName;
        [Header("Audio")]
        [SerializeField] AudioClip _audioClip;
        [SerializeField] AudioSource _audioSource;
        //PRIVATE
        //PUBLIC
        #endregion
        #region Default Informations
        void Reset()
        {
            _timer = 2;
            _menuName = "Menu";
        }
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        // Update is called once per frame
        #endregion
        #region Methods
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(OpenDoorCoroutine());
                _audioSource.PlayOneShot(_audioClip);
                Jump jump = other.GetComponentInChildren<Jump>();
                jump.enabled = false;
            }
        }
        #endregion
        #region Coroutines
        IEnumerator OpenDoorCoroutine()
        {
            yield return new WaitForSeconds(_timer);
            SceneManager.LoadScene(_menuName);
        }
        #endregion
    }
}