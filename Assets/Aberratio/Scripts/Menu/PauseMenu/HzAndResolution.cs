using TMPro;
using UnityEngine;

public class HzAndResolution : MonoBehaviour
{
    public TMP_Dropdown ResDD;
    // 0 is 60hz | 720p; 1 is 120hz | 1080p; 2 is 144hz | 1440p.
    private void Awake()
    {
        Load();
    }
    public void ChangeResolution()
    {
        if(ResDD.value == 0) // 720p
        {
            Screen.SetResolution(1280, 720, true);
        }
        else if(ResDD.value == 1) //1080p
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (ResDD.value == 2) //1440p
        {
            Screen.SetResolution(2560, 1440, true);
        }
    }
    public void Save()
    {
        int ResValue = ResDD.value;
        PlayerPrefs.SetInt("Res", ResValue);
        Load();
    }

    public void Load()
    {
        int ResValue = PlayerPrefs.GetInt("Res");
        ResDD.value = ResValue;
        ChangeResolution();
    }
}
