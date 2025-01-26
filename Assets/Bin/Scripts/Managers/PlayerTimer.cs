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
    public class PlayerTimer : MonoBehaviour
    {
        #region Champs
        //INSTPECTOR
        [SerializeField] private bool _startAutomatically = true; // Si le chrono commence au lancement du jeu
                                                                  //PRIVATE
        private float _elapsedTime;
        private bool _isRunning;
        //PUBLIC
        public static PlayerTimer Instance;
        public float ElapsedTime
        {
            get => _elapsedTime;
            private set => _elapsedTime = Mathf.Max(0, value); // Assure un temps positif
        }
        public bool IsRunning { get => _isRunning; set => _isRunning = value; }
        #endregion
        #region Default Informations
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        private void Awake()
        {
            if (Instance == null)
            {
                //Debug.Log("InputManager is single");
                Instance = this;
            }
            else
            {
                Debug.Log("PlayerTimer already exist");
                Destroy(this);
            }
        }

        private void Start()
        {
            ResetChrono();
            _isRunning = true;
            if (_startAutomatically)
            {
                StartChrono(); // Commence automatiquement si configuré
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (_isRunning)
            {
                _elapsedTime += Time.deltaTime; // Augmente le temps écoulé
            }
            //Debug.Log($"temp = {_elapsedTime}");
        }
        #endregion
        #region Methods
        void StartChrono()
        {
            _isRunning = true;
        }

        public void StopChrono()
        {
            _isRunning = false;
        }

        public void ResetChrono()
        {
            _elapsedTime = 0;
        }
        #endregion
    }
}