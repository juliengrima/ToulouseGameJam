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
        //INSPECTOR        [Header("Jump Information")]
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _forwardForce = 5f;
        //PRIVATE
        private InputsManager _inputsManager;
        private Grounded _grounded;
        private Rigidbody _rb;
        //PUBLIC
        #endregion
        #region Default Informations
        void Reset()
        {
        
        }
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
    
        void Awake()
        {
        
        }
        void Start()
        {
            _inputsManager = InputsManager.Instance;
            _grounded = Grounded.Instance;
            _rb = GetComponentInParent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_inputsManager.GetClick() && _grounded.IsGrounded == true)
            {
                PerformJump();
            }
        }
        #endregion
        #region Methods
        private void PerformJump()
        {
            // S'assurer que le Rigidbody est disponible
            if (_rb == null) return;

            // Réinitialiser la vitesse avant d'appliquer la force
            _rb.linearVelocity = Vector3.zero;

            // Appliquer une force vers le haut et dans l'axe Z
            //Vector3 jumpDirection = new Vector3(0, _jumpForce, _forwardForce);
            Vector3 jumpDirection = transform.forward * _forwardForce + Vector3.up * _jumpForce;
            _rb.AddForce(jumpDirection, ForceMode.Impulse);
        }
        #endregion
    }
}