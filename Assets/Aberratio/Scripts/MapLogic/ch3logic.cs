using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch3logic : MonoBehaviour
{
    public float waiterbtw;
    public GameObject activatedObject,activatedObj2,deleteRemote;
    int doaction;
    public void logicers()
    {
        if(doaction == 0) { StartCoroutine(ToggleDoor()); }
        if(doaction == 1)
        {
            deleteRemote.gameObject.SetActive(false);
            ColorTogglePlayer.instance.hasRemote = true;
            activatedObj2.GetComponent<Door>().activateObj();
            NewGameUIHide.instance.start = true;
        }
        Debug.Log("hel");
    }
    public IEnumerator ToggleDoor()
    {
        //play audio
        yield return new WaitForSeconds(waiterbtw);
        activatedObject.GetComponent<Door>().activateObj();
        doaction = 1;
    }
}
