using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
        
    [SerializeField] private Vector3 initialDirection;
        
    [SerializeField] private float timerSpikes;
        
    private Vector3 actualDirection;
    
    private float timer;
        
    void Start()
    {
        actualDirection = initialDirection;
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(actualDirection * speed * Time.deltaTime);
            
        if (timer >= timerSpikes)
        {
            actualDirection *= -1;
            timer = 0;
        }
    }
}
