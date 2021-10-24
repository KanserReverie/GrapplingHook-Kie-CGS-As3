using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// Setting for the Option Menu.
/// </summary>
public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private TMP_Dropdown ddAntiAlias;

    [SerializeField] private PostProcessLayer camPostProcessing;
    private void Start()
    {
        optionsMenu.SetActive(false);
        optionsButton.SetActive(true);
    }

    /// <summary>
    /// Open the options menu.
    /// </summary>
    public void OpenOptionsMenu()
    {
        Time.timeScale = 0;
        optionsMenu.SetActive(true);
        optionsButton.SetActive(false);
    }

    private void ButtonEvents()
    {
        ddAntiAlias.onValueChanged.AddListener(delegate { AntiAlias(ddAntiAlias.value);});
    }
    
    /// <summary>
    /// The Anti Alias Options.
    /// </summary>
    /// <param name="_index">The drop down selected.</param>
    public void AntiAlias(int _index)
    {
        // Project Settings Control
        if(_index == 2)
        {
            QualitySettings.antiAliasing = 2;
        }
        else if(_index == 3)
        {
            QualitySettings.antiAliasing = 4;
        }
        else if(_index == 4)
        {
            QualitySettings.antiAliasing = 8;
        }
        else
        {
            QualitySettings.antiAliasing = 0; // If none or FXAA, turn off MSAA
        }
        
        // Post Processing Layer Control.
        if(_index == 1)
        {
            camPostProcessing.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
        }
        else
        {
            camPostProcessing.antialiasingMode = PostProcessLayer.Antialiasing.None;
        }
        
        // Dropdown Control.
        ddAntiAlias.SetValueWithoutNotify(_index);
    }

    /// <summary>
    /// Close the options menu.
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1;
        optionsButton.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
