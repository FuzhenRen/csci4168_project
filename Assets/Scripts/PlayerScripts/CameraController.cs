/*
    the player's cam controller that can get set the cam offset and follow the player by setting each scene's Main cam to this script and
    attatch it on to the camPosition to play's cube.
*/
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0.5f, -0.1f); // offset of cam and player
    private Transform player; // Get palyer

    public float mouseSensitivity = 2f;
    private float pitch; // vertical
    private float yaw; // horizontal
    private void Start()
    {
        // initial angle
        yaw = transform.eulerAngles.y; // current angle
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            // Get mouse input
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, -40f, 85f); // Limitation of turing angles of player

            // Turning the cam
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
            transform.rotation = rotation;

            // update cam
            Vector3 desiredPosition = player.position + rotation * offset; 
            transform.position = desiredPosition;
        }
    }

    // find and follow the player
    public void SetPlayer(Transform newPlayer)
    {
        player = newPlayer;
    }
}
