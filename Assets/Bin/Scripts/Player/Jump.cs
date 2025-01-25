using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Manager;
using PhysicsEntities;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace Entities
{
    public class Jump : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Player Informations")]
        [SerializeField] Player _player;
        [Header("Jump Charge")]
        [SerializeField] float _chargeRate;
        //PRIVATE
        private InputsManager _inputsManager;
        private Grounded _grounded;
        private Rigidbody _rb;
        float _jumpForce;
        float _baseForwardForce;
        float _maxForwardForce;
        private float _currentChargeTime;
        private bool _isCharging;
        //PUBLIC
        public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
        public float MaxForwardForce { get => _maxForwardForce; set => _maxForwardForce = value; }
        public float BaseForwardForce { get => _baseForwardForce; set => _baseForwardForce = value; }
        #endregion
        #region Default Informations
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        void Start()
        {
            _inputsManager = InputsManager.Instance;
            _grounded = Grounded.Instance;
            _rb = GetComponentInParent<Rigidbody>();

            _jumpForce = _player.JumpForce;
            _baseForwardForce = _player.BaseForwardForce;
            _maxForwardForce = _player.MaxForwardForce;
            _isCharging = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_inputsManager.GetClick() && _grounded.IsGrounded == true)
            {
                //Debug.Log("Player is charging");
                StartCharging();
            }
            else
            {
                if (_isCharging)
                {
                    //Debug.Log("Player is Jumping");
                    PerformJump();
                    ResetCharge();
                }
            }
        }
        #endregion
        #region Methods
        private void StartCharging()
        {
            _isCharging = true;
            _currentChargeTime += Time.deltaTime;
            //Debug.Log($"CurrentChargTime = {_currentChargeTime}");
        }

        private void PerformJump()
        {
            // S'assurer que le Rigidbody est disponible
            if (_rb == null) return;

            float forwardForce = Mathf.Clamp(_baseForwardForce + _currentChargeTime * _chargeRate, _baseForwardForce, _maxForwardForce);

            // Réinitialiser la vitesse avant d'appliquer la force
            _rb.linearVelocity = Vector3.zero;

            // Appliquer une force vers le haut et dans l'axe Z
            Vector3 jumpDirection = transform.forward * forwardForce + Vector3.up * _jumpForce;
            _rb.AddForce(jumpDirection, ForceMode.Impulse);
        }

        private void ResetCharge()
        {
            _isCharging = false;
            _currentChargeTime = 0f;
        }
        #endregion
    }
}