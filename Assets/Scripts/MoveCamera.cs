using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform CameraPosition;

    void LateUpdate()
    {
        transform.position = CameraPosition.position;
    }
}