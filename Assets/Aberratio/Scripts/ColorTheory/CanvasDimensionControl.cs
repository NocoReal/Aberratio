using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasDimensionControl : MonoBehaviour
{
    public TextMeshProUGUI r,g,b,CDAText;
    float alpha;
    void Update()
    {
        if(ColorManager.instance.RedG == false)
        {
            r.gameObject.SetActive(true);
        }
        else
        {
            r.gameObject.SetActive(false);
        }
        if (ColorManager.instance.GreenG == false)
        {
            g.gameObject.SetActive(true);
        }
        else
        {
            g.gameObject.SetActive(false);
        }
        if (ColorManager.instance.BlueG == false)
        {
            b.gameObject.SetActive(true);
        }
        else
        {
            b.gameObject.SetActive(false);
        }
        if(ColorManager.instance.CDA == true)
        {
            CDAText.gameObject.SetActive(true);
        }
        else
        {
            CDAText.gameObject.SetActive(false);
        }
    }
}
