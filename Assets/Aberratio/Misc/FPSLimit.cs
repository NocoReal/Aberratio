using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    public int target = 30;

    void Awake()
    {
        Application.targetFrameRate = target;
    }
}
