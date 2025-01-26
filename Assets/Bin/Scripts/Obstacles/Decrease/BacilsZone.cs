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
        bool _inZone;
        //PUBLIC
        #endregion
        #region Default Informations
        void Reset()
        {
            _timer = 5;
            _damages = 0.05f;
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
            _inZone = false;
        }

        // Update is called once per frame
        #endregion
        #region Methods
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //Debug.Log("On trigger enter");
                _inZone = true;
                StartCoroutine(HitCoroutine());
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //Debug.Log("On trigger exit");
                _inZone = false;
                StopCoroutine(HitCoroutine());
            }
        }
        #endregion
        #region Coroutines
        IEnumerator HitCoroutine()
        {
            while (_inZone)
            {
                PlayerHealth.Instance.TakeDamage(_scaleLife);
                yield return new WaitForSeconds(_timer);
            }
               
        }
        #endregion
    }
}