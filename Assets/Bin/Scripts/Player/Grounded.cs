using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace PhysicsEntities
{
    public class Grounded : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Character_Fields")]
        [SerializeField] float _rayDistance;
        [Header("Layers Informations")]
        [SerializeField] LayerMask _layers;
        //PRIVATE
        Vector3 _rayStart;
        bool _isGrounded;
        //PUBLIC
        public static Grounded Instance;
        public bool IsGrounded { get => _isGrounded; }
        public float RayDistance { get => _rayDistance; set => _rayDistance = value; }
        #endregion
        #region Default Informations
        void Reset()
        {
            _rayDistance = 0.3f;
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
                Debug.Log("Grounded already exist");
                Destroy(this);
            }
        }
        void Start()
        {
            _isGrounded = false;  
        }

        // Update is called once per frame
        void Update()
        {
            _rayStart = transform.position;

            //Make Ray DownWard
            if (Physics.Raycast(_rayStart, Vector3.down, out RaycastHit hit, _rayDistance, _layers))
            {
                // Ray is Green
                _isGrounded = true;
                Debug.DrawRay(_rayStart, Vector3.down * _rayDistance, Color.green);
            }
            else
            {
                // Ray is Red
                _isGrounded = false;
                Debug.DrawRay(_rayStart, Vector3.down * _rayDistance, Color.red);
            }
        }
        #endregion
        #region Methods
        void FixedUpdate()
        {
        
        }
        void LateUpdate()
        {
        
        }
        #endregion
    }
}