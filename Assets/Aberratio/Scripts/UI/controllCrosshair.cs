using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllCrosshair : MonoBehaviour
{
    public GameObject RedCH, GreenCH, BlueCH;
    private void Update()
    {
        if (ColorManager.instance.RedG == false)
        {
            RedCH.SetActive(true);
        }
        else
        {
            RedCH.SetActive(false);
        }
        if (ColorManager.instance.GreenG == false)
        {
            GreenCH.SetActive(true);
        }
        else
        {
            GreenCH.SetActive(false);
        }
        if (ColorManager.instance.BlueG == false)
        {
            BlueCH.SetActive(true);
        }
        else
        {
            BlueCH.SetActive(false);
        }
    }
}
