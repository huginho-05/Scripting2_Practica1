using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] private int playerMaxLife;
    [SerializeField] private int playerCurrentLife;
    
    private Vector3 initialPosition;

    void Start()
    {
        playerCurrentLife = playerMaxLife;
        initialPosition = transform.position;
    }
    
    public void ReceiveDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage, 1);
        playerCurrentLife -= damageTaken;
        if (playerCurrentLife <= 0)
        {
            transform.position = initialPosition;
            playerCurrentLife = playerMaxLife;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            ReceiveDamage(100); 
        }
    }
  
}
