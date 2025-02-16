using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    public float godown;
    public GameObject activatedObject, ChangeColor;
    public bool Red, Green, Blue;
    public void ButtonActionThing()
    {   
        if (activatedObject.GetComponent<Door>() != null)
        {
            activatedObject.GetComponent<Door>().activateObj();
        }
        if (ChangeColor.GetComponent<WhatColorIsThis>() != null)
        {
            if(Red)
            {
                ColorManager.instance.Red();
            }
            if(Green)
            {
                ColorManager.instance.Green();

            }
            if (Blue)
            {
                ColorManager.instance.Blue();

            }
        }
    }
    public void GoDown()
    {
        ButtonActionThing();
        transform.position = new Vector3(transform.position.x, transform.position.y - godown, transform.position.z);
    }
    public void GoUp() 
    {
        ButtonActionThing();
        transform.position = new Vector3(transform.position.x, transform.position.y + godown, transform.position.z);
    }
}
