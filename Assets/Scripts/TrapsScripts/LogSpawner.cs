using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [Header("Prefab del tronco")]
    [SerializeField] private GameObject logPrefab;

    [Header("Spawn")]
    [SerializeField] private float spawnInterval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnLog();
            timer = 0f;
        }
    }

    void SpawnLog()
    {
        Instantiate(logPrefab, transform.position, transform.rotation);
    }
}
