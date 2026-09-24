using UnityEngine;

public class CameraRay : MonoBehaviour
{
    public float rayDistance = 100f;

    void Update()
    {
        Camera cam = GetComponent<Camera>();

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.blue);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        }
    }
}