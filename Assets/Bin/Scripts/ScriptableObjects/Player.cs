using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player")]
public class Player : ScriptableObject
{
    //INSPECTOR
    [SerializeField] float _life;
    [SerializeField] float _bounceForce;
    [SerializeField] float _scale;
    [SerializeField] float _temperature;
    //PRIVATE
    //PUBLIC
    public float Life { get => _life; set => _life = value; }
    public float BounceForce { get => _bounceForce; set => _bounceForce = value; }
    public float Scale { get => _scale; set => _scale = value; }
    public float Temperature { get => _temperature; set => _temperature = value; }
}
