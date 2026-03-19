using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] private int playerMaxLife;
    [SerializeField] private int playerCurrentLife;
    
    private Vector3 checkpointPosition;

    void Start()
    {
        playerCurrentLife = playerMaxLife;
        checkpointPosition = transform.position;
    }
    
    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpointPosition = newCheckpoint;
    }
    
    public void ReceiveDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage, 1);
        playerCurrentLife -= damageTaken;
        if (playerCurrentLife <= 0)
        {
            transform.position = checkpointPosition;
            playerCurrentLife = playerMaxLife;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Traps
        if (collision.gameObject.CompareTag("Trap"))
        {
            ReceiveDamage(25); 
        }
    }
    
    public int GetCurrentLife()
    {
        return playerCurrentLife;
    }

    public int GetMaxLife()
    {
        return playerMaxLife;
    }
}
