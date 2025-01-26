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
        [SerializeField] TMP_Text _text;
        [Header("Message")]
        [SerializeField] GameObject _message;
        [Header("Scene")]
        [SerializeField] string _menuName;
        //PRIVATE
        //PUBLIC
        public static UIManager Instance;
        #endregion
        #region Default Informations
        void Reset()
        {
            _menuName = "Menu";
        }
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
                Debug.Log("UIManager already exist");
                Destroy(this);
            }
        }
        // Update is called once per frame
        void Update()
        {
            UpdateHealthBar();
            UpdatePowerBar();
            Chrono();
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

        public void Chrono()
        {
            if (PlayerTimer.Instance.ElapsedTime == 0)
            {
                _text.text = "0";
            }

            TimeSpan _timeSpan = TimeSpan.FromSeconds(PlayerTimer.Instance.ElapsedTime);
            //String Format ("{0=Parametre:00=time}:{1:00}, Parametre_0", Parametre_1)
            _text.text = string.Format("{0:00}:{1:00}:{2:00}:{3:000}",
                                                            _timeSpan.Hours,
                                                            _timeSpan.Minutes,
                                                            _timeSpan.Seconds,
                                                            _timeSpan.Milliseconds);
        }
        #endregion
        #region EndLevel
        public void EnableWinmessage()
        {
            _message.SetActive(true);
        }

        public void ExitToMenu()
        {
            SceneManager.LoadScene(_menuName);
        }
        #endregion
    }
}