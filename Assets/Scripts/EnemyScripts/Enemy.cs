using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    [Header("Distancias")]
    public float attackDistance = 2f;

    [Header("Ataque")]
    public float attackCooldown = 1.5f;
    public int damage = 10;

    private float lastAttackTime;

    [Header("Animator")]
    public Animator animator;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Si está lejos → perseguir
        if (distance > attackDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            animator.SetBool("isAttacking", false);
        }
        // Si está cerca → atacar
        else
        {
            agent.isStopped = true;

            // Mirar al jugador
            transform.LookAt(player);

            animator.SetBool("isAttacking", true);

            Attack();
        }
    }

    void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            // Intentar hacer daño al jugador
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.ReceiveDamage(damage);
            }
        }
    }
}
