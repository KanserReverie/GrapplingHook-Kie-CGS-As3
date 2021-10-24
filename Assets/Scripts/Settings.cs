using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Settings : MonoBehaviour
{
    public GameObject optionsButton;
    public GameObject optionsMenu;
    public TMP_Dropdown ddAntiAlias;

    [SerializeField] private PostProcessLayer camPostProcessing;
    private void Start()
    {
        optionsMenu.SetActive(false);
        optionsButton.SetActive(true);
    }

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

    public void ResumeGame()
    {
        Time.timeScale = 1;
        optionsButton.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
