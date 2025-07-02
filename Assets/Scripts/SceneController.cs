using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

// SceneController.cs
// This script manages scene loading and quitting the game.
public class SceneController : MonoBehaviour
{

    // Singleton instance of SceneController
    // Ensures that only one instance of SceneController exists in the scene.
     public static SceneController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // Prevents this object from being destroyed when loading a new scene.
        }
        else
        {
            Destroy(this.gameObject); 
        }
    }

    //<summary>
    // Loads a scene by name if it exists in the build settings.
    // If the scene does not exist, it logs an error message.
    //</summary>
    // <param name="sceneName">The name of the scene to load.</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    //<summary>
    // Quits the game application.  
    //</summary>
    public void QuitGame()
    {
        Application.Quit();
    }



}
