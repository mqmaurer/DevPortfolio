using UnityEngine;

// GravitySource.cs
// <summary>
// This script applies a gravitational force to objects within a certain radius.
// </summary>
public class GravitySource : MonoBehaviour
{
    [Header("Gravity Settings")]
    [Tooltip("Strength of the gravitational force applied to objects.")]
    public float gravityStrength = 30f;
    [Tooltip("Radius within which the gravitational force is applied.")]
    public float eventHorizonRadius = 2f; 

    /// <summary>
    /// Applies gravitational force to all rigidbodies within the event horizon radius.
    /// </summary>
    void FixedUpdate()
    {
        Rigidbody[] bodies = FindObjectsByType<Rigidbody>(FindObjectsSortMode.None); // Find all rigidbodies in the scene

        foreach (var body in bodies)
        {   
            if (body == null || body.gameObject == this.gameObject || body.transform.IsChildOf(transform))
                continue;

            //Calculate the direction and distance from the gravity source to the body
            Vector3 direction = transform.position - body.position;
            float distance = direction.magnitude;

            if (distance < eventHorizonRadius)
            {
                Destroy(body.gameObject); // Destroy the body if it is within the event horizon radius
                continue;
            }

            // Apply gravitational force if the body is outside the event horizon radius
            if (distance > 0)
            {
                Vector3 force = direction.normalized * (gravityStrength / (distance * distance));
                body.AddForce(force);
            }
        }
    }
    

}


