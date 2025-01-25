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
    public class PlayerHealth : MonoBehaviour
    {
        #region Champs
        //INSTPECTOR
        [Header("Player Settings")]
        [SerializeField] Player _player;
        [SerializeField] GameObject _playerGameObject;
        [Header("Health Settings")]
        [SerializeField] float _minScale;
        [SerializeField] float _maxScale;
        [Header("Respawn Settings")]
        [SerializeField] string _sceneName;
        [SerializeField] float _Timer;
        //PRIVATE
        AudioManager _audioManager;
        //PUBLIC
        public static PlayerHealth Instance;
        #endregion
        #region Default Informations
        void Reset()
        {
            _minScale = 0.2f;
            _maxScale = 2;
            _sceneName = "Lev1";
            _Timer = 3;
        }
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
                Debug.Log("PlayerHealth already exist");
                Destroy(this);
            }
        }
        void Start()
        {
            _audioManager = AudioManager.Instance;
            _playerGameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        // Update is called once per frame
        void Update()
        {
            _playerGameObject.transform.localScale = _player.ScaleLife;
        }
        #endregion
        #region Methods
        public void TakeDamage(Vector3 scaleLife)
        {
            _player.ScaleLife -= scaleLife;
            //_audioManager?.PlayerTakeDamage();

            if (_player.ScaleLife.x < _minScale &&
                _player.ScaleLife.y < _minScale &&
                _player.ScaleLife.z < _minScale)
            {
                //HandlePlayerDeath(_audioManager.PlayerSmallDeath);
            }

        }

        public void HealScaleLife(Vector3 healAmount)
        {
            _player.ScaleLife += healAmount;
            //_audioManager?.PlayerHeal();

            if (_player.ScaleLife.x > _maxScale &&
                _player.ScaleLife.y > _maxScale &&
                _player.ScaleLife.z > _maxScale)
            {
                //HandlePlayerDeath(_audioManager.PlayerBigDeath);
            }
        }

        //private void HandlePlayerDeath(System.Action deathAudioCallback)
        //{
        //    deathAudioCallback?.Invoke();
        //    StartCoroutine(PlayerDeathCoroutine());
        //}

        IEnumerator PlayerDeathCoroutine()
        {
            yield return new WaitForSeconds(_Timer);
            SceneManager.LoadScene(_sceneName);
        }
        #endregion
    }
}