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
using PhysicsEntities;


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
        [SerializeField] float _Timer;
        [Header("Events")]
        [SerializeField] UnityEvent _hitEvent;
        [SerializeField] UnityEvent _healEvent;
        [SerializeField] UnityEvent _deathEvent;
        //PRIVATE
        AudioManager _audioManager;
        string _sceneName;
        //PUBLIC
        public static PlayerHealth Instance;
        public float MaxScale { get => _maxScale; set => _maxScale = value; }
        #endregion
        #region Default Informations
        void Reset()
        {
            _minScale = 0.2f;
            _maxScale = 2;
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
            _sceneName = SceneManager.GetActiveScene().name;
            _player.ScaleLife = new Vector3(1, 1, 1);
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
            //Debug.Log($"Heal = {scaleLife}");
            _player.ScaleLife -= scaleLife;
            Rigidbody rb = _playerGameObject.GetComponent<Rigidbody>();
            rb.mass -= scaleLife.x;
            _hitEvent.Invoke();
            _audioManager?.PlayerTakeDamage();

            if (_player.ScaleLife.x < _minScale &&
                _player.ScaleLife.y < _minScale &&
                _player.ScaleLife.z < _minScale)
            {
                HandlePlayerDeath(_audioManager.PlayerSmallDeath);
                Jump jump = _playerGameObject.GetComponentInChildren<Jump>();
                jump.enabled = false;
                _player.ScaleLife = new Vector3(0.2f, 0.2f, 0.2f);

                Debug.Log($"Jump Script = {jump.enabled}");
                Debug.Log("Player is dead");

                StartCoroutine(PlayerDeathCoroutine());

                _deathEvent.Invoke();
            }
        }

        public void HealScaleLife(Vector3 healAmount)
        {
            //Debug.Log($"Heal = {healAmount}");
            _player.ScaleLife += healAmount;
            Rigidbody rb = _playerGameObject.GetComponent<Rigidbody>();
            rb.mass += healAmount.x;

            _healEvent.Invoke();
            _audioManager?.PlayerHeal();

            if (_player.ScaleLife.x > _maxScale &&
                _player.ScaleLife.y > _maxScale &&
                _player.ScaleLife.z > _maxScale)
            {
                HandlePlayerDeath(_audioManager.PlayerBigDeath);
                Jump jump = _playerGameObject.GetComponentInChildren<Jump>();
                jump.enabled = false;
                _player.ScaleLife = new Vector3(_maxScale, _maxScale, _maxScale);

                StartCoroutine(PlayerDeathCoroutine());

                _deathEvent.Invoke();
            }
        }

        private void HandlePlayerDeath(System.Action deathAudioCallback)
        {
            deathAudioCallback?.Invoke();
            StartCoroutine(PlayerDeathCoroutine());
        }

        IEnumerator PlayerDeathCoroutine()
        {
            yield return new WaitForSeconds(_Timer);
            SceneManager.LoadScene(_sceneName);
        }
        #endregion
    }
}