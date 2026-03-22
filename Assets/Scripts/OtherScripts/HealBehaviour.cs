using UnityEngine;

public class HealBehaviour : MonoBehaviour
{
    [Header("Movement and rotation")]
    public float floatingSpeed;
    public float floatingHeight;
    public float rotationSpeed;

    [Header("Health")]
    public int healthAmount;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatingSpeed) * floatingHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.AddHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
