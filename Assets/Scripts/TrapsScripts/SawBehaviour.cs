using UnityEngine;

public class SawBehaviour : MonoBehaviour
{
    [Header("Saw Rotation")] 
    [SerializeField] float sawSpeed_X;
    [SerializeField] float sawSpeed_Y;
    [SerializeField] float sawSpeed_Z;
    
    [Header("Saw Movement")] 
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direccionInicial;
    [SerializeField] private float timerFloor;
    private float timer;
    
    void Update()
    {
        //Saw rotation
        transform.Rotate(sawSpeed_X, sawSpeed_Y,sawSpeed_Z);
        
        //Saw movement
        timer += Time.deltaTime;
        transform.Translate(direccionInicial * speed * Time.deltaTime);
            
        if (timer >= timerFloor)
        {
            direccionInicial *= -1;
            timer = 0;
        }
    }
}
