using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player")]
public class Player : ScriptableObject
{
    //INSPECTOR
    [SerializeField] Vector3 _scaleLife;
    [SerializeField] float _jumpForce;
    [SerializeField] float _baseForwardForce;
    [SerializeField] float _maxForwardForce;
    [SerializeField] float _temperature;
    //PRIVATE
    //PUBLIC
    public Vector3 ScaleLife { get => _scaleLife; set => _scaleLife = value; }
    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
    public float BaseForwardForce { get => _baseForwardForce; set => _baseForwardForce = value; }
    public float MaxForwardForce { get => _maxForwardForce; set => _maxForwardForce = value; }
    public float Temperature { get => _temperature; set => _temperature = value; }
}
