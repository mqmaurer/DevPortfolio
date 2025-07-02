using UnityEngine;
using UnityEngine.Pool;  // Namespace  ObjectPool


// InstantiateNewEarthWithObjectPool.cs
// <summary>
// This script instantiates a new GameObject in front of the main camera using an object pool.
// It provides functionality to instantiate the object on a button click and despawn it.
// </summary>
// <remarks>
// Alternative version for InstantiateNewEarth.cs that uses an Object Pool for better performance.
public class InstantiateNewEarthWithObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectToInstantiate;
    [SerializeField] private Camera mainCamera;

    private ObjectPool<GameObject> pool;
    private GameObject spawnedObject;

    [Header("Instantiation Settings")]
    [Tooltip("Position in screen space where the object will be instantiated.")]
    public float distanceInFrontOfCamera = 2.0f;

    void Start()
    {
        mainCamera = Camera.main;
        if (CheckForError()) return;

        // creates Pool with create, activate, deactivate, destroy functions
        pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(objectToInstantiate),
            actionOnGet: obj => obj.SetActive(true),
            actionOnRelease: obj =>
            {
                obj.SetActive(false);
                obj.transform.position = Vector3.zero; // Reset Position
                obj.transform.rotation = Quaternion.identity;
            },
            actionOnDestroy: obj => Destroy(obj),
            collectionCheck: false,
            defaultCapacity: 5,
            maxSize: 10);
    }

    /// <summary>
    /// Instantiates the object in front of the camera when the button is clicked.
    /// If an object is already spawned, it will be returned to the pool before instantiating a new one.
    /// </summary>
    public void InstantiateOnButtonClick()
    {
        if (CheckForError()) return;

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 worldPosition = mainCamera.transform.position + cameraForward * distanceInFrontOfCamera;

        // Wenn schon ein Objekt aktiv ist, gib es zurück in den Pool
        if (spawnedObject != null)
        {
            pool.Release(spawnedObject);
        }

        spawnedObject = pool.Get();
        spawnedObject.transform.position = worldPosition;
        spawnedObject.transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// Destroys the currently spawned object if it exists and returns it to the pool.  
    /// /// </summary>
    public void DespawnObject()
    {
        if (spawnedObject != null)
        {
            pool.Release(spawnedObject);
            spawnedObject = null;
        }
        else
        {
            Debug.LogWarning("Attempted to release a null object.");
        }
    }

    /// <summary>
    /// Checks if an object is currently spawned.
    /// </summary>
    /// <returns>True if an object is spawned, false otherwise.</returns>
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
