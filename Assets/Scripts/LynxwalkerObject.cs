using UnityEngine;

public class LynxwalkerObject : MonoBehaviour
{
   
    public static LynxwalkerObject Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
}
