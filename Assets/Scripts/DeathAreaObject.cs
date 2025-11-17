using UnityEngine;

public class DeathAreaObject : MonoBehaviour
{
    public static DeathAreaObject Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
}
