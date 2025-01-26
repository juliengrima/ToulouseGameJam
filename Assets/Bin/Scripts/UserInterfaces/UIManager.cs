using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Entities;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        #region Champs
        //INSTPECTOR
        [Header("Player Informations")]
        [SerializeField] Player _player;
        [Header("Bars Informations")]
        [SerializeField] Image _healthbar;
        [SerializeField] Image _powerbar;
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
            UpdateHealthBar();
            UpdatePowerBar();
        }
        #endregion
        #region Methods
        public void UpdateHealthBar()
        {
            if (_healthbar != null)
            {
                // Mise à jour de la barre de vie en fonction de la santé actuelle
                float targetFillAmount = _player.ScaleLife.x / PlayerHealth.Instance.MaxScale;
                _healthbar.fillAmount = targetFillAmount;

                // Mise à jour des textes de santé
                //_currentHealthText.text = Mathf.CeilToInt(_scriptablePlayer.CurrentHealth).ToString();
                //_maxHealthText.text = Mathf.CeilToInt(_scriptablePlayer.MaxHealth).ToString();
            }
        }

        public void UpdatePowerBar()
        {
            if (_healthbar != null)
            {
                // Mise à jour de la barre de vie en fonction de la santé actuelle
                float targetFillAmount = Jump.Instance.CurrentChargeTime / Jump.Instance.ChargeRate;
                _powerbar.fillAmount = targetFillAmount;

                // Mise à jour des textes de santé
                //_currentHealthText.text = Mathf.CeilToInt(_scriptablePlayer.CurrentHealth).ToString();
                //_maxHealthText.text = Mathf.CeilToInt(_scriptablePlayer.MaxHealth).ToString();
            }
        }
        #endregion
    }
}