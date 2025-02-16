using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeResolution : MonoBehaviour
{
    public RenderTexture rt;
    private void Start()
    {
        rt.width = Screen.width;
        rt.height = Screen.height;
    }
    public void ResetResolution()
    {
        rt.width = Screen.width;
        rt.height = Screen.height;
    }
}
