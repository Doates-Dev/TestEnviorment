using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform Orientation;
    public Transform Player;

    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Camera looks up/down and left/right
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        // Player turns left/right
        Player.rotation = Quaternion.Euler(0, yRotation, 0);

        // Orientation turns with player
        Orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}