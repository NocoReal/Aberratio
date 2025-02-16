using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFOV : MonoBehaviour
{
    Camera Camera;
    public TextMeshProUGUI FOVDisplay;
    public Slider FOVSlider;
    void Awake()
    {
        Camera = GetComponent<Camera>();
        Load();
    }
    private void Update()
    {
        FOVDisplay.text = FOVSlider.value.ToString() + "°";//displays sens
    }
    public void ChangeCameraFOV()
    {
        Camera.fieldOfView = FOVSlider.value;
    }
    public void Save()
    {
        int FOVValue = (int)FOVSlider.value;
        PlayerPrefs.SetInt("FOV", FOVValue);
        Load();
    }

    public void Load()
    {
        int FOVValue = PlayerPrefs.GetInt("FOV");
        FOVSlider.value = FOVValue;
        ChangeCameraFOV();
    }
}
