using UnityEngine;
using UnityEngine.AI;

public class PlayerDragger : MonoBehaviour
{
public void PlayerDrag(Transform transform)
    {
        if (TryGetComponent<NavMeshAgent>(out var agent))
        {
            agent.enabled = true;
            agent.SetDestination(transform.position);
        }
    }
}
