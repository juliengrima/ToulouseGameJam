using System;
using UnityEngine;
using Manager;

namespace Entities
{
    public class Look : MonoBehaviour
    {
        #region Champs
        [Header("Player GameObject")]
        [SerializeField] private GameObject _playerObject;
        [SerializeField] private float _smoothRotation = 0.1f;
 
        private Camera _mainCamera;
        #endregion

        #region Unity LifeCycle
        private void Start()
        {
            _mainCamera = Camera.main;
            if (_mainCamera == null)
            {
                Debug.LogError("Main Camera not found! Ensure your camera is tagged as 'MainCamera'.");
            }
        }

        private void Update()
        {
            RotateTowardsMouse();
        }
        #endregion

        #region Methods
        private void RotateTowardsMouse()
        {
            // Obtenir la position de la souris en pixels (écran)
            Vector3 mousePosition = Input.mousePosition;

            // Convertir la position de la souris en coordonnées du monde
            Ray ray = _mainCamera.ScreenPointToRay(mousePosition);

            // Définir un plan horizontal sur lequel la souris se projette (ici le plan XZ)
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            if (groundPlane.Raycast(ray, out float distance))
            {
                // Calculer la position de la souris sur le plan
                Vector3 worldMousePosition = ray.GetPoint(distance);

                // Calculer la direction entre le joueur et la position de la souris
                Vector3 direction = (worldMousePosition - _playerObject.transform.position).normalized;

                // Ne considérer que la direction sur le plan XZ (ignorer Y)
                direction.y = 0;

                if (direction != Vector3.zero)
                {
                    // Calculer la rotation cible
                    Quaternion targetRotation = Quaternion.LookRotation(direction);

                    // Appliquer une rotation fluide
                    _playerObject.transform.rotation = Quaternion.Slerp(
                        _playerObject.transform.rotation,
                        targetRotation,
                        Time.deltaTime / _smoothRotation
                    );
                }
            }
        }
        #endregion
    }
}