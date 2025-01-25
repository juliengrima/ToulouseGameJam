using UnityEngine;


public class BounceWithRigidbody : MonoBehaviour
{
    #region Champs
    //INSPECTOR
    [SerializeField] Player _player;
    //PRIVATE
    SphereCollider _sphereCollider;
    Rigidbody _rb;
    //PUBLIC
    public static BounceWithRigidbody Instance;
    #endregion
    #region Default Informations
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            //Debug.Log("LifeManaActions is single");
            Instance = this;
        }
        else
        {
            Debug.Log("BounceWithrigidbody already exist");
            Destroy(this);
        }

    }

    void Start()
    {
        _sphereCollider = GetComponentInParent<SphereCollider>();
        _rb = GetComponentInParent<Rigidbody>();
    }
    // Update is called once per frame
    private void Update()
    {
        BouncyCollider();
    }
    #endregion
    #region Methods
    void BouncyCollider()
    {
        //_sphereCollider.material.bounciness = _player.BounceForce;
        Debug.Log($"Veloicty = {_rb.linearVelocity}");
    }
    void IncreaseBouceForce(float force)
    {
        _player.BounceForce += force;

        _rb.linearVelocity = force * _rb.linearVelocity;
        //if (_player.BounceForce > 1f)
        //{
        //    _player.BounceForce = 1f;
        //}
    }

    void DecreaseBouceForce(float force)
    {
        _player.BounceForce -= force;
        _rb.linearVelocity = _rb.linearVelocity/force;
        //if (_player.BounceForce < 0.1f)

        //    _player.BounceForce = 0.1f ;
        //}
    }
    #endregion
}