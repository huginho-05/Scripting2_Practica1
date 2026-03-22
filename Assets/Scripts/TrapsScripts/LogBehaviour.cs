using UnityEngine;

public class LogBehaviour : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed = 5f;

    [Header("Rotación")]
    [SerializeField] private float rotationSpeed = 300f;
    [SerializeField] private Vector3 rotationAxis = Vector3.right;

    [Header("Vida")]
    [SerializeField] private float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Movimiento hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Rotación tipo rodar
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
