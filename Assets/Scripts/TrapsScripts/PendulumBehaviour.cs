using UnityEngine;

public class PendulumBehaviour : MonoBehaviour
{
    [SerializeField] private float swingSpeed = 2f; //Velocidad de oscilación
    [SerializeField] private float maxAngle = 45f;  //Ángulo máximo de oscilación (grados)
    
    private Quaternion startRotation; //Rotación inicial del objeto

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        // Calcular el ángulo de oscilación usando el tiempo con una función seno
        float angle = Mathf.Sin(Time.time * swingSpeed) * maxAngle;

        // Crear una nueva rotación basada en el ángulo calculado
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, 0, angle);
        
        transform.rotation = targetRotation;
    }
    
}
