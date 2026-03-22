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
        //Ángulo de oscilación
        float angle = Mathf.Sin(Time.time * swingSpeed) * maxAngle;

        //Nueva rotación basada en el ángulo calculado
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, 0, angle);
        
        transform.rotation = targetRotation;
    }
    
}
