using UnityEngine;
using UnityEngine.AI;

public class PlayerDragger : MonoBehaviour
{
public void PlayerDrag(Transform nottransform)
    {
        if (TryGetComponent<NavMeshAgent>(out var agent))
        {
            agent.enabled = true;
            agent.SetDestination(nottransform.position);
        }
    }
}
