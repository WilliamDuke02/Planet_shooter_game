using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform sun; // The target object (in your case, the sun)
    public Vector3 offset = new Vector3(0, 40, 0); // The offset position of the camera (should be a positive y value)

    void Start()
    {
        // Set the camera's position to the target's position plus the offset.
        transform.position = sun.position + offset;
    }

    void Update()
    {
        // Always update the camera's position to follow the target.
        transform.position = sun.position + offset;

        // Make sure the camera is always looking at the target.
        transform.LookAt(sun);
    }
}
