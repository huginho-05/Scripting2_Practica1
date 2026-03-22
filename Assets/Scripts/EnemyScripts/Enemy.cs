using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    

    [Header("Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float attackDistance;

    private float lastAttackTime;
    
    [SerializeField] private Animator animator;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Si está lejos, perseguir
        if (distance > attackDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            animator.SetBool("isAttacking", false);
        }
        // Si está cerca, atacar
        else
        {
            agent.isStopped = true;
            
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
