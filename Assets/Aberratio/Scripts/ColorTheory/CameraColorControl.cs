using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorControl : MonoBehaviour
{
    private bool RedP, GreenP, BlueP;
    public Material mat;

    void FixedUpdate()
    {
        manageColor();
    }
    void manageColor()
    {
        RedP = ColorManager.instance.RedG;
        GreenP = ColorManager.instance.GreenG;
        BlueP = ColorManager.instance.BlueG;
        if (RedP == true)
        {
            mat.SetInt("_Red", 0);
        }
        else
        {
            mat.SetInt("_Red", 1);
        }
        if (GreenP == true)
        {
            mat.SetInt("_Green", 0);
        }
        else
        {
            mat.SetInt("_Green", 1);
        }
        if (BlueP == true)
        {
            mat.SetInt("_Blue", 0);
        }
        else
        {
            mat.SetInt("_Blue", 1);
        }
    }
}
