using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI SensDisplay, FOVDisplay;
    public TMP_Dropdown ResDD;
    public Slider SensSlider, FOVSlider;
    public float sensSettings, multiplyer;
    void Awake()
    {
        Load();
    }
    public void ChangeResolution()
    {
        if (ResDD.value == 0) // 720p
        {
            Screen.SetResolution(1280, 720, true);
        }
        else if (ResDD.value == 1) //1080p
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (ResDD.value == 2) //1440p
        {
            Screen.SetResolution(2560, 1440, true);
        }
    }
    private void Update()
    {
        sensSettings = SensSlider.value * 0.1f;
        SensDisplay.text = sensSettings.ToString();//displays sens
        multiplyer = sensSettings * 10;
        FOVDisplay.text = FOVSlider.value.ToString() + "°";//displays fov
    }

    public void Save()
    {
        int sensValue = (int)multiplyer;
        PlayerPrefs.SetInt("SensValue", sensValue);
        int ResValue = ResDD.value;
        PlayerPrefs.SetInt("Res", ResValue);
        int FOVValue = (int)FOVSlider.value;
        PlayerPrefs.SetInt("FOV", FOVValue);
        Load();
    }

    public void Load()
    {
        int ResValue = PlayerPrefs.GetInt("Res");
        ResDD.value = ResValue;
        int sensValue = PlayerPrefs.GetInt("SensValue");
        sensSettings = sensValue * 0.1f;
        SensSlider.value = sensValue;
        int FOVValue = PlayerPrefs.GetInt("FOV");
        FOVSlider.value = FOVValue;
    }

}
