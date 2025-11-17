using UnityEngine;

/// <summary>
/// Calling PlayerObject.Instance will return the player's GameObject Transform.
/// Use this with EnemyAi or other scripts that need to reference the player.
/// </summary>
public class PlayerObject : MonoBehaviour
{
    // Singleton instance, access by: PlayerObject.Instance
    public static PlayerObject Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
}
