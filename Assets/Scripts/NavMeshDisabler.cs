using UnityEngine;
using UnityEngine.AI;

public class NavMeshDisabler : MonoBehaviour
{
    public void DisableNavMesh()
    {
        PlayerObject.Instance.GetComponent<NavMeshAgent>().enabled = false;
    }
}
