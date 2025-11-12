using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Transform Destination;
    public Transform player;


    public void TeleportPlayer()
    {

        {
            player.transform.position = Destination.transform.position;
        }
    }
}
