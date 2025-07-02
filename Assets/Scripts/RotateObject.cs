using UnityEngine;

// RotateObject.cs
// <summary>
// This script rotates a GameObject around a specified axis at a defined speed.
// </summary>
public class RotateObject : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // z. B. (0,1,0) für Y-Achse
    public float rotationSpeed = 45f;         // Grad pro Sekunde

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}