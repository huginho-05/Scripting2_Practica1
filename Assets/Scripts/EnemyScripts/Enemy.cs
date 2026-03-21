using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform player;
    
    [Header ("Attack ehaviour")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask whatIsDamagable;
    
    private Animator anim;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        agent.SetDestination(player.position);
        
        //Para saber cuando un  agent llega a su destino
        if (DestinationReached())
        {
            FaceToTarget();
            
            anim.SetBool("isAttacking", true);
            agent.isStopped = true;
        }
    }

    private void FaceToTarget()
    {
        Vector3 targetDirection = (player.transform.position - transform.position);
        targetDirection.y = 0f;
        Quaternion rotationToTarget = Quaternion.LookRotation(targetDirection);
        transform.rotation = rotationToTarget;
    }

    private void DoDamage()
    {
        Collider[] attackResults = Physics.OverlapSphere(attackPoint.position, attackRadius, whatIsDamagable);

        foreach (Collider attackResult in attackResults)
        {
            
        }
    }

    private void OnAttackFinished()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            anim.SetBool("isAttacking", false);
            agent.isStopped = false;
        }
    }

    private bool DestinationReached()
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }
}
