using UnityEngine;
using System.Collections;

public class ClosingWallBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;              
    [SerializeField] private float collisionThreshold; 
    [SerializeField] private float waitTimeAtCollision; 
    [SerializeField] private float waitTimeAtStartPosition; 
    
    private Transform spikes; 
    private Transform wall; 

    private Vector3 initialWallPosition; 
    private Vector3 initialSpikesPosition; 

    void Start()
    {
        spikes = transform; 
        wall = transform.GetChild(0);  
        
        initialWallPosition = wall.position;
        initialSpikesPosition = spikes.position;
        
        StartCoroutine(MoveTrapCycle());
    }

    IEnumerator MoveTrapCycle()
    {
        while (true)
        {
            //Mover ambos objetos hacia el centro
            yield return StartCoroutine(MoveTowardCollision());

            //Esperar unos segundos tras encontrarse
            yield return new WaitForSeconds(waitTimeAtCollision);

            //Vuelta a sus posiciones originales
            yield return StartCoroutine(MoveBackToOriginalPositions());

            //Esperar unos segundos antes de comenzar el próximo ciclo
            yield return new WaitForSeconds(waitTimeAtStartPosition);
        }
    }

    IEnumerator MoveTowardCollision()
    {
        while (Vector3.Distance(spikes.position, wall.position) > collisionThreshold)
        {
            spikes.position = Vector3.MoveTowards(spikes.position, wall.position, speed * Time.deltaTime);
            wall.position = Vector3.MoveTowards(wall.position, spikes.position, speed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator MoveBackToOriginalPositions()
    {
        while (Vector3.Distance(spikes.position, initialSpikesPosition) > collisionThreshold)
        {
            spikes.position = Vector3.MoveTowards(spikes.position, initialSpikesPosition, speed * Time.deltaTime);
            wall.position = Vector3.MoveTowards(wall.position, initialWallPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
