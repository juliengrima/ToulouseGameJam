using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace EnvironmentObstacles
{
    public class AirFlow : MonoBehaviour
    {
        #region Champs
        //INSTPECTOR
        [Header("Air Flow Settings")]
        [SerializeField] private float _force = 10f; // La force de propulsion
        //PRIVATE
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
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        #endregion
        #region Methods
        void OnTriggerEnter(Collider other)
        {
            // Vérifie si l'objet entrant est le joueur
            if (other.CompareTag("Player"))
            {
                // Récupère le Rigidbody du joueur
                Rigidbody playerRb = other.GetComponent<Rigidbody>();

                if (playerRb != null)
                {
                    // Applique une force dans l'axe Z local du trigger
                    Vector3 forceDirection = transform.forward * _force;
                    playerRb.AddForce(forceDirection, ForceMode.Impulse);

                    Debug.Log("Player propelled in AirFlow with force: " + forceDirection);
                }
                else
                {
                    Debug.LogWarning("No Rigidbody found on the Player!");
                }
            }
        }
        #endregion
    }
}