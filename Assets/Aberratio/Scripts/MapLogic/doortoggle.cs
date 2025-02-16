using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doortoggle : MonoBehaviour
{
    public GameObject activatedObject;
    public void ButtonActionThing()
    {
        activatedObject.GetComponent<Door>().activateObj();
    }
}
