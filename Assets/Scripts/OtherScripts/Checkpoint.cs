using UnityEngine;

public class Checkpoint : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth respawn = other.GetComponent<PlayerHealth>();

            if (respawn != null)
            {
                respawn.SetCheckpoint(transform.position);
            }
        }
    }
}
