using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloseLogs : MonoBehaviour
{
    public GameObject Menu;
    int closeLog = 0;
    private void Awake()
    {
        Load();
        if (closeLog == 1)
        {
            gameObject.SetActive(false);
            Menu.SetActive(true);
        }
    }
    public void toggleOn()
    {
        closeLog = 1;
        PlayerPrefs.SetInt("LogClose", closeLog);
        Load();
    }
    void Load()
    {
        closeLog = PlayerPrefs.GetInt("LogClose");
    }
}
