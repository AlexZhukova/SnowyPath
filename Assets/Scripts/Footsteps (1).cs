using StarterAssets;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Footsteps : MonoBehaviour
{
    [Tooltip("PlayerInput requires two Starter Asset componenets: StarterAssetInputs & PlayerInput")]
    public InputOptions inputOptions;
    [SerializeField][Tooltip("ONLY needed if you use inputOptions/KeyInput")]
    KeyInputOptions keyInputOptions;
    [Tooltip("Layers included in the raycast detecting floor. It's good idea to remove \"Player\" in here if you're getting self-hits.")]
    public LayerMask layerMask; // = LayerMask.GetMask("Player");

    StarterAssetsInputs starterAssetsInputs;
    PlayerInput playerInput;

    [Space(8)]

    [SerializeField][Tooltip("Change this to change the pace. If you want it longer, but this value doesn't help anymore, remove the check '.isPlaying'.")]
    float walkStepDurationMax = 0.6f;
    [SerializeField][Tooltip("Change this to change the pace. If you want it longer, but this value doesn't help anymore, remove the check '.isPlaying'.")] 
    float runStepDurationMax = 0.4f;
    float stepTimer;

    [Space(8)]
    [SerializeField] AudioSource footstepAudioSource;
    [Space(8)]

    [Tooltip("This is how many meters down it'll raycast to try find a walkable surface. Don't make it too much so you won't hear footsteps when in the air.")]
    public float surfaceDetectionRange = 0.5f;


    [Space(8)]
    public WalkableSurfaceMaterial currentWalkableSurfaceMaterial;
    [Space(16)]
    public List<WalkableSurfaceAudio> surfaceAudios;
    int currentAudioIndex;



    void Awake()
    {
        switch (inputOptions)
        {
            case InputOptions.PlayerInput:
                starterAssetsInputs = GetComponentInChildren<StarterAssetsInputs>();
                if (starterAssetsInputs == null) Debug.LogError("ERROR: couldn't find 'StarterAssetInputs' -component");

                playerInput = GetComponentInChildren<PlayerInput>();
                if (playerInput == null) Debug.LogError("ERROR: couldn't find 'PlayerInput' -component");
                break;

            case InputOptions.KeyInput:

                break;

        }
        // Warning if you haven't done the setup
        if (surfaceAudios == null || surfaceAudios.Count == 0)
        {
            Debug.LogWarning("You are trying to use 'Footsteps', but no audio is set on its 'surfaceAudios' -list elements.");
        }
    }

    void Update()
    {
        stepTimer += Time.deltaTime;

        if (
            /* take this row out if you want to enforce the step durations */footstepAudioSource.isPlaying == false || 
            (IsSprinting() && stepTimer >= runStepDurationMax) || 
            (IsSprinting() == false && stepTimer >= walkStepDurationMax))
        {
            stepTimer = 0;
        }
        else return; // stepTimer cooldown, do nothing more


        // If not moving, do nothing more
        if (IsMoving() == false) { return; } 


        // Raycast to see surface
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, surfaceDetectionRange, layerMask))
        {
            // Try find a FootstepsSurface from the collider below
            if (hit.collider.TryGetComponent<FootstepsSurface>(out FootstepsSurface footstepsSurface))
            {
                foreach (var item in surfaceAudios)
                {
                    if (item.walkableSurfaceMaterial == footstepsSurface.walkableSurfaceMaterial)
                    {
                        // Surface found, try play a footstep
                        item.TryPlayRandomStep(footstepAudioSource, IsSprinting());
                        return;
                    }
                }
                Debug.LogWarning("Walking on " + footstepsSurface.walkableSurfaceMaterial + " but couldn't find audio set up for it on 'surfaceAudios'.");
                return;
            }
        }
    }

    bool IsMoving()
    {
        switch (inputOptions)
        {
            case InputOptions.PlayerInput:
                return (starterAssetsInputs.move.sqrMagnitude > 0.1f);

            case InputOptions.KeyInput:
                return keyInputOptions.IsMoving();
        }
        return false;
    }
    bool IsSprinting()
    {
        switch (inputOptions)
        {
            case InputOptions.PlayerInput:
                return starterAssetsInputs.sprint;

            case InputOptions.KeyInput:
                return keyInputOptions.IsRunning();
        }
        return false;
    }


    public enum InputOptions
    {
        PlayerInput,
        KeyInput
    }
}

public enum WalkableSurfaceMaterial
{
    Carpet,
    Concrete,
    Grass,
    Gravel,
    Leaf,
    Metal,
    Sand,
    Snow,
    Water,
    Wood,

}
[Serializable]
public class WalkableSurfaceAudio
{
    public WalkableSurfaceMaterial walkableSurfaceMaterial;
    public List<AudioClip> audioClipsWalk;
    public List<AudioClip> audioClipsRun;

    public void TryPlayRandomStep(AudioSource audioSource, bool run = false)
    {
        // Start a new clip
        if (run) audioSource.clip = audioClipsRun[UnityEngine.Random.Range(0, audioClipsRun.Count)];
        else audioSource.clip = audioClipsWalk[UnityEngine.Random.Range(0, audioClipsWalk.Count)];
        audioSource.Play();
        Debug.Log(" Step! ");

    }
}

[Serializable]
public class KeyInputOptions
{
    [SerializeField] List<KeyCode> moveKeys = new List<KeyCode> { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    [SerializeField] KeyCode runKey = KeyCode.LeftShift;

    public bool IsMoving()
    {
        foreach (var key in moveKeys)
        {
            if (Input.GetKey(key)) return true;
        }
        return false;
    }
    public bool IsRunning()
    {
        return Input.GetKey(runKey);
    }
}