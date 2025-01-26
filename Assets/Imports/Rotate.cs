using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Vitesse de rotation en degrés par seconde
    public float rotationSpeed = 30f;

    void Update()
    {
        // Calculer la rotation
        float rotationAmount = rotationSpeed * Time.deltaTime;
        // Appliquer la rotation autour de l'axe X
        transform.Rotate(rotationAmount, 0, 0);
    }
}