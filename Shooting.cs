using UnityEngine;

public class PlayerPlanet : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile that the player will shoot
    public float power = 10.0f; // The power of the shot

    void Update()
    {
        // Check if the player has pressed the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Create a new projectile
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Calculate the direction of the shot
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = transform.position.z - Camera.main.transform.position.z;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldMousePosition.y = 0; // Ensure the projectile stays at y=0
            Vector3 direction = (worldMousePosition - transform.position).normalized;
            direction.y = 0; // Ensure the direction is only in the x-z plane

            // Apply force to the projectile
            projectile.GetComponent<Rigidbody>().AddForce(direction * power, ForceMode.Impulse);
        }
    }
}
