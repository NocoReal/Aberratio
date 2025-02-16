using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI SensDisplay;
    public Scrollbar SensSlider;
    public float sensSettings;
    void Awake()
    {
        LoadSens();
    }
    private void Update()
    {
        sensSettings = SensSlider.value * 2f;
        SensDisplay.text = sensSettings.ToString();
    }

    public void SaveSens()
    {
        float sensValue = sensSettings;
        PlayerPrefs.SetFloat("SensValue", sensValue);
        // Debug.Log(sensValue + " Save");
        LoadSens();
    }

    public void LoadSens()
    {
        float sensValue = PlayerPrefs.GetFloat("SensValue");
        sensSettings = sensValue;
        SensSlider.value = sensSettings * 0.5f;
        // Debug.Log(sensValue + " Load");
    }
}
