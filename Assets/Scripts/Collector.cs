using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Collectible collectible = collision.GetComponent<Collectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }
    }

}
