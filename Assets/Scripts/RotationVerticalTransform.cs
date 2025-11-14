using UnityEngine;

public class RotationVerticalTransform : MonoBehaviour
{
    public Vector3 rotationDirection = Vector3.up * 20f;
    public Vector3 InitialPosition;
    public float amplitude;
    public float frequency;
    public bool isMoving;
    private void Awake()
    {
         InitialPosition = transform.position;
    }
    void Update()
    {
        if (isMoving == true)
        {
            transform.Rotate(rotationDirection * Time.deltaTime);
           float newY = InitialPosition.y + Mathf.Sin(Time.time * frequency)*amplitude;
            transform.position= new Vector3(transform.position.x, newY, transform.position.z);
        }
        
    }
}
