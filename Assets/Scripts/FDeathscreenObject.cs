using UnityEngine;

public class FDeathscreenObject : MonoBehaviour
{
    public static FDeathscreenObject Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
}
