using UnityEngine;

public class MovingFloorBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
        
    [SerializeField] private Vector3 initialDirection;
        
    [SerializeField] private float timerFloor;
        
    private Vector3 actualDirection;
    
    private float timer;
        
    void Start()
    {
        actualDirection = initialDirection;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(actualDirection * speed * Time.deltaTime);
            
        if (timer >= timerFloor)
        {
            actualDirection *= -1;
            timer = 0;
        }
    }
}
