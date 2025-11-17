using BNG;
using UnityEngine;
using UnityEngine.AI;

public class TriggerDeathHelper : MonoBehaviour
{
public void TriggerDeath()
    {
        PlayerObject.Instance.GetComponent<PlayerTeleport>().enabled = false;
        PlayerObject.Instance.GetComponent<BNGPlayerController>().enabled = false;
        PlayerObject.Instance.GetComponent <CharacterController>().enabled = false;
        PlayerObject.Instance.GetComponent <NavMeshAgent>().enabled = true;
        SnowyObject.Instance.gameObject.SetActive(false);
        LynxwalkerObject.Instance.gameObject.SetActive(false);
    }
}
