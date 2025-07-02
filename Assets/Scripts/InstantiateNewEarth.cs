using NUnit.Framework;
using UnityEngine;

// InstantiateNewEarth.cs
//<summary>
// This script instantiates a new GameObject in front of the main camera when a button is clicked.
// It also provides functionality to despawn the object and check if it is currently spawned.
// </summary>
public class InstantiateNewEarth : MonoBehaviour
{

    [SerializeField] private GameObject objectToInstantiate;
    [SerializeField] private Camera mainCamera;

    private GameObject spawnedObject;

    [Header("Instantiation Settings")]
    [Tooltip("Position in screen space where the object will be instantiated.")]
    public float distanceInFrontOfCamera = 2.0f;

    /// <summary>
    /// Initializes the main camera and checks for errors in the setup.
    /// </summary>
    void Start()
    {
        mainCamera = Camera.main;
        if (CheckForError()) return;

    }


    /// <summary>  
    /// Instantiates the object in front of the camera when the button is clicked.
    /// </summary>
    public void InstantiateOnButtonClick()
    {
        if (CheckForError() || IsObjectSpawned()) return;

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 worldPosition = mainCamera.transform.position + cameraForward * distanceInFrontOfCamera;
        spawnedObject = Instantiate(objectToInstantiate, worldPosition, Quaternion.identity); // Will maybe replaced with Object Pooling later
    }

    /// <summary>
    /// Destroys the currently spawned object if it exists.
    /// </summary>
    public void DespawnObject()
    {
        if (IsObjectSpawned())
        {
            Destroy(spawnedObject);
        }
        else
        {
            Debug.LogWarning("Attempted to destroy a null object.");
        }
    }

    /// <summary>
    /// Checks if an object is currently spawned.   
    /// /// </summary>
    /// <returns>True if an object is spawned, false otherwise.</returns>
    public bool IsObjectSpawned()
    {
        return spawnedObject != null;
    }

    /// <summary>
    /// Checks for errors in the setup, such as missing object or camera.
    /// </summary>
    private bool CheckForError()
    {
        if (objectToInstantiate == null)
        {
            Debug.LogError("Object to instantiate is not assigned.");
            return true;
        }
        if (mainCamera == null)
        {
            Debug.LogError("Main camera is not assigned.");
            return true;
        }
        return false;
    }


}
