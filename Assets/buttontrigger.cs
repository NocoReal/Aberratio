using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttontrigger : MonoBehaviour
{
    public GameObject button;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            button.GetComponent<ButtonAction>().GoDown();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            button.GetComponent<ButtonAction>().GoUp();
        }
    }
}
