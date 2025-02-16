using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetUITransparency : MonoBehaviour
{
    public TextMeshProUGUI UI1, UI2;
    float transparency=1,transparency2 =0.5f;
    bool goOff = false,goOff2;
    private void Awake()
    {
        transparency2 = gameObject.GetComponent<Image>().color.a;
    }
    private void Start()
    {
        StartCoroutine(WaitBeforeDisappear());
    }
    private void FixedUpdate()
    {
        goOff = NewGameUIHide.instance.goOff1;
        if (goOff && goOff2)
        {
            startFade();
        }
    }
    public void startFade()
    {
        if(transparency > 0)
        {
            UI1.color = new Color(UI1.color.r, UI1.color.g, UI1.color.b,transparency);
            UI2.color = new Color(UI2.color.r, UI2.color.g, UI2.color.b, transparency);
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, transparency2); //sets even this game object
            transparency = transparency - 0.01f;
            transparency2 = transparency2 - 0.01f;
        }
    }
    IEnumerator WaitBeforeDisappear()
    {
        yield return new WaitForSeconds(5);
        goOff2 = true;
    }
}
