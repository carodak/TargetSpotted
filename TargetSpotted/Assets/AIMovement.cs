using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMovement : MonoBehaviour
{
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;

    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        // Update destination if the target moves one unit
        if (Vector3.Distance(destination, new Vector3(-16.5f, 11.1f, -9.5f)) > 1.0f)
        {
            destination = new Vector3(-16.5f, 11.1f, -9.5f);
            agent.destination = destination;
        }
    }
}
