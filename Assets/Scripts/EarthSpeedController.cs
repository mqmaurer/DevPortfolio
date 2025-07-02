using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controls the rotation speed of Earth and Moon objects in the scene based on user input.
/// </summary>
public class EarthSpeedController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private TextMeshProUGUI speedValeueText;

    [Header("Rotation Settings")]
    [SerializeField] private float speed = 1.0f;

    private GameObject earth;
    private GameObject moon;
    private GameObject moonAnchor;

    private const string EarthTag = "Earth";
    private const string MoonTag = "Moon";
    private const string EarthSystemTag = "EarthSystem";

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Attempts to assign celestial objects.
    /// </summary>
    private void Awake()
    {
        AssignCelestialObjects();
    }

    /// <summary>
    /// Called once per frame to update rotation animation.
    /// </summary>
    private void Update()
    {
        HandleSpeedAnimation();
    }

    /// <summary>
    /// Called when the script is disabled or the GameObject is destroyed.
    /// Cleans up the EarthSystem GameObject.
    /// </summary>
    private void OnDisable()
    {
        GameObject earthSystem = GameObject.FindGameObjectWithTag(EarthSystemTag);
        if (earthSystem != null)
        {
            Destroy(earthSystem);
        }
    }

    /// <summary>
    /// Called when the speed slider value is changed.
    /// Updates the internal speed and the UI text.
    /// </summary>
    public void OnSliderChanged()
    {
        if (speedSlider == null)
        {
            Debug.LogWarning("UI Elements are not assigned.");
            return;
        }

        speed = speedSlider.value;
        UpdateSpeedValueText();
    }

    /// <summary>
    /// Updates the speed value text on the UI.
    /// </summary>
    private void UpdateSpeedValueText()
    {
        if (speedValeueText != null)
        {
            speedValeueText.text = speed.ToString("F0");
        }
    }

    /// <summary>
    /// Rotates the celestial objects based on the current speed.
    /// </summary>
    private void HandleSpeedAnimation()
    {
        if (!AssignCelestialObjects())
        {
            return;
        }

        earth.transform.Rotate(Vector3.forward, speed * 28 * Time.deltaTime);
        moon.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        moonAnchor.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }

    /// <summary>
    /// Attempts to find and assign celestial objects in the scene.
    /// </summary>
    /// <returns>True if all objects are found and assigned, false otherwise.</returns>
    private bool AssignCelestialObjects()
    {
        earth = GameObject.FindWithTag(EarthTag);

        var moons = GameObject.FindGameObjectsWithTag(MoonTag);
        if (moons.Length >= 2)
        {
            moonAnchor = moons[0];
            moon = moons[1];
        }

        if (earth == null || moon == null || moonAnchor == null)
        {
            ToggleUI(false);
            return false;
        }

        ToggleUI(true);
        return true;
    }

    /// <summary>
    /// Shows or hides the UI panel.
    /// </summary>
    /// <param name="state">True to show, false to hide.</param>
    private void ToggleUI(bool state)
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(state);
        }
    }
}




