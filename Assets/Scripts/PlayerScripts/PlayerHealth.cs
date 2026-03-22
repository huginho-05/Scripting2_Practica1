using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] private int playerMaxLife;
    [SerializeField] private int playerCurrentLife;
    
    private Vector3 initialPosition;

    private Rigidbody rb;

    void Start()
    {
        playerCurrentLife = playerMaxLife;
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }
    
    public void ReceiveDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage, 1);
        playerCurrentLife -= damageTaken;
        if (playerCurrentLife <= 0)
        {
            rb.position = initialPosition;
            playerCurrentLife = playerMaxLife;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            ReceiveDamage(25); 
        }
    }
  
}
