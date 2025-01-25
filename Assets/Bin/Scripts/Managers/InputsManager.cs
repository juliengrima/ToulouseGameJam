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
    public class InputsManager : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        //PRIVATES
        static InputsManager _instance;
        InputSystem_Actions _playerInputs;
        int _pref;
        //PUBLICS
        // ReadOnly Static Input Manager
        public static InputsManager Instance;
        #endregion
        #region Default Informations
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
                Debug.Log("InputsManager already exist");
                Destroy(this);
            }

            _playerInputs = new InputSystem_Actions();
        }
        void Start()
        {
            //Call PlayerPref to InputAction and Override mouse Look Vector2.y true or false
            //_pref = PlayerPrefs.GetInt("Inverted");
            //if (_pref == 1)
            //{
            //    _playerInputs.Player.Look.ApplyBindingOverride(new InputBinding { overrideProcessors = "invertVector2(invertX=false,invertY=false)" });
            //}
            //else
            //{
            //    _playerInputs.Player.Look.ApplyBindingOverride(new InputBinding { overrideProcessors = "invertVector2(invertX=false,invertY=true)" });
            //}
        }
        #endregion
        #region PlayerInputs
        private void OnEnable()
        {
            _playerInputs.Enable();
        }

        private void OnDisable()
        {
            _playerInputs.Disable();
        }
        #endregion
        #region MovementInput Methods
        public bool GetClick()
        {
            //return _playerInputs.Player.Jump.WasPressedThisFrame();
            return _playerInputs.Player.Jump.IsPressed();
        }

        //public bool ClickToMove()
        //{
        //    return _playerInputs.Player.ClickToMove.IsPressed();
        //}
        #endregion
        #region MouseInput Methods

        //public Vector2 GetPlayerAIM()
        //{
        //    return _playerInputs.Player.AIM.ReadValue<Vector2>();
        //}
        #endregion
        #region Actions Methods
        //public bool GetFire()
        //{
        //    bool isPressed = _playerInputs.Player.Fire.IsPressed();
        //    //Debug.Log("Fire isPressed: " + isPressed);
        //    return isPressed;
        //    //return _playerInputs.Player.Fire.WasPerformedThisFrame();
        //}
        #endregion
        #region Managers
        //public bool GetEscape()
        //{
        //    bool escape = _playerInputs.Player.MenuPause.WasPressedThisFrame();
        //    return escape;
        //}
        #endregion
    }
}