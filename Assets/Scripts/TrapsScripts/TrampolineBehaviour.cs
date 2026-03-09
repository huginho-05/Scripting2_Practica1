using System;
using UnityEngine;

public class TrampolineBehaviour : MonoBehaviour
{
    [SerializeField] private float fuerzaSalto; // La fuerza con la que se lanza el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>(); // Obtener el Rigidbody2D del jugador
            
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0); // Limpiar cualquier velocidad previa en el eje Y
            
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse); // Aplicar el impulso hacia arriba
            
            
        }
    }
}
