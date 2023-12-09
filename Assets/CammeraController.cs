using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 1.0f;
    public float zoomSpeed = 1.0f;
    public float rotationSpeed = 5f;

    private float currentZoom = 10.0f;
    private Vector3 currentOffset = Vector3.zero;
    private float currentRotation = 0.0f;

    void Update()
    {
        // Handle mouse movement
        if (Input.GetMouseButton(0))
        {
            currentOffset.x += Input.GetAxis("Mouse X") * moveSpeed; // Negate this
            currentOffset.y -= Input.GetAxis("Mouse Y") * moveSpeed; // Negate this

            // Rotate the camera based on the mouse's horizontal movement
            currentRotation -= Input.GetAxis("Mouse X") * rotationSpeed; // Negate this
        }

        // Handle mouse zoom
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, 5.0f, 15.0f);
    }
    
    void LateUpdate()
    {
        // Apply position, zoom, and rotation
        Vector3 targetPosition = target.position + currentOffset;
        transform.position = targetPosition - new Vector3(0, 0, currentZoom);
        transform.RotateAround(target.position, Vector3.up, currentRotation);
        transform.LookAt(targetPosition);
    }
}