using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    public TextMeshProUGUI SensDisplay;
    public Scrollbar SensSlider;
    float sensitivityLocal = 1;
    public float sensitivityPublic = 1;

    void Update()
    {
        sensitivityLocal = SensSlider.value * 2f;
        SensDisplay.text = sensitivityLocal.ToString();
        sensitivityPublic = sensitivityLocal;
        //Debug.Log(sensitivityPublic);
    }
}
