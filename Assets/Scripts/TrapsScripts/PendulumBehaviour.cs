using UnityEngine;

public class PendulumBehaviour : MonoBehaviour
{
    [SerializeField] private float swingSpeed; 
    [SerializeField] private float maxAngle;  
    
    private Quaternion startRotation; 

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
