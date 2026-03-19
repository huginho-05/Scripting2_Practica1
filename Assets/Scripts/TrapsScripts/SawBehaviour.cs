using UnityEngine;

public class SawBehaviour : MonoBehaviour
{
    [Header("Saw Rotation")] 
    [SerializeField] float sawRotationSpeed;
    
    [Header("Saw Movement")] 
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direccionInicial;
    [SerializeField] private float timerFloor;
    private float timer;
    
    void Update()
    {
        //Saw rotation
        transform.Rotate(sawRotationSpeed * Time.deltaTime, 0, 0);
        
        //Saw movement
        timer += Time.deltaTime;
        transform.Translate(direccionInicial * speed * Time.deltaTime, Space.World);
            
        if (timer >= timerFloor)
        {
            direccionInicial *= -1;
            timer = 0;
        }
    }
}
