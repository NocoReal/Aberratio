using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch2logic : MonoBehaviour
{
    public float waiterbtw;
    public void logicers()
    {
        StartCoroutine(ToggleColor());
        Debug.Log("hel");
    }
    public IEnumerator ToggleColor()
    {
        yield return new WaitForSeconds(waiterbtw);
        ColorManager.instance.Red();
        logicers();
    }
}
