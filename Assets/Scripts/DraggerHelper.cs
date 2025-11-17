using UnityEngine;

public class DraggerHelper : MonoBehaviour
{
    public void Drag(Transform DragPoint)
    {
        PlayerObject.Instance.GetComponent<PlayerDragger>().PlayerDrag(DragPoint);
    }
}
