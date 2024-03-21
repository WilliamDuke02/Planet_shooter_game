using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform center; // The center of the orbit (in your case, the sun)
    public float speed = 6.0f; // The speed of the orbit (6 degrees per second)

    private Vector3 relativeDistance;
    public bool isMoving = false; // Add this line

    void Start()
    {
        // Calculate the initial relative distance of the planet to the center
        relativeDistance = transform.position - center.position;
    }

    void Update()
    {
        if (isMoving) // Add this line
        {
            // Calculate the angle the planet has moved based on the speed
            float angle = speed * Time.deltaTime;

            // Rotate the relative distance vector by the angle around the y-axis
            relativeDistance = Quaternion.Euler(0, angle, 0) * relativeDistance;

            // Update the position of the planet
            transform.position = center.position + relativeDistance;
        }
    }

    public void StartMoving() // Add this method
    {
        isMoving = true;
    Invoke("StopMoving", 10); // This will call StopMoving after 10 seconds
    }

    public void StopMoving() // Add this method
    {
        isMoving = false;
    }
}
