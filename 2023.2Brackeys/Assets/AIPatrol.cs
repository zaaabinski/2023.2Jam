using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
    public float detectionRange = 10f; // Range to detect the player
    public float patrolSpeed = 2f; // Speed while patrolling
    public float chaseSpeed = 5f; // Speed while chasing
    public float constantYPosition = 0.1f; // The constant Y position

    private NavMeshAgent navMeshAgent;
    private Transform player;

    private bool isChasing = false;
    private Vector3 patrolDestination;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        SetRandomPatrolDestination();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            StartChasing();
        }
        else if (isChasing)
        {
            // Player out of detection range, return to patrolling
            isChasing = false;
            SetRandomPatrolDestination();
        }

        if (!isChasing)
        {
            // Check if the agent reached its destination
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
            {
                SetRandomPatrolDestination();
            }
        }
        else
        {
            // Update the chase destination to the player's position
            navMeshAgent.SetDestination(player.position);
        }

        // Ensure the object maintains a constant Y position
        MaintainConstantYPosition();

        // Rotate the object to face its movement direction
        RotateToMovementDirection();
    }

    private void SetRandomPatrolDestination()
    {
        // Find a random point on the NavMesh
        patrolDestination = GetRandomNavMeshPosition();

        navMeshAgent.speed = patrolSpeed;
        navMeshAgent.destination = patrolDestination;
    }

    private Vector3 GetRandomNavMeshPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += transform.position;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, 10f, NavMesh.AllAreas);

        return navHit.position;
    }

    private void StartChasing()
    {
        isChasing = true;
        navMeshAgent.speed = chaseSpeed;
        navMeshAgent.destination = player.position;
    }

    private void RotateToMovementDirection()
    {
        // Calculate the direction to the destination
        Vector3 direction = navMeshAgent.velocity.normalized;

        if (direction != Vector3.zero)
        {
            // Calculate the rotation to face the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            // Add 90 degrees to the Y-axis rotation
            targetRotation *= Quaternion.Euler(0f, 90f, 0f);

            transform.rotation = targetRotation;
        }
    }


    private void MaintainConstantYPosition()
    {
        // Maintain a constant Y position
        transform.position = new Vector3(transform.position.x, constantYPosition, transform.position.z);
    }
}
