using UnityEngine;

public class SnowyObject : MonoBehaviour
{
    public static SnowyObject Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
}
