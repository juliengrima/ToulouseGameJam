using System.Collections;
using UnityEngine;
using Manager;

namespace EnvironmentObstacles
{
    public class BacilsZone : MonoBehaviour
    {
        #region Champs
        //INSTPECTOR
        [SerializeField] float _timer;
        [SerializeField] float _damages;
        //PRIVATE
        Vector3 _scaleLife;
        //PUBLIC
        #endregion
        #region Default Informations
        void Reset()
        {
            _damages = 0.1f;
        }
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
    
        void Awake()
        {
        
        }
        void Start()
        {
            _scaleLife = new Vector3(_damages, _damages, _damages);
        }

        // Update is called once per frame
        #endregion
        #region Methods
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("On trigger enter");
            if (other.CompareTag("Player"))
            {
                StartCoroutine(HitCoroutine());
            }
        }

        void OnTriggerExit(Collider other)
        {
            Debug.Log("On trigger exit");
            if (other.CompareTag("Player"))
            {
                StopCoroutine(HitCoroutine());
            }
        }
        #endregion
        #region Coroutines
        IEnumerator HitCoroutine()
        {
            yield return new WaitForSeconds(_timer);
            PlayerHealth.Instance.TakeDamage(_scaleLife);
            
        }
        #endregion
    }
}