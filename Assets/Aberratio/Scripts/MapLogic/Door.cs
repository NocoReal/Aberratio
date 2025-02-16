using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator1, animator2;
    public GameObject doorRight,doorLeft;
    public bool startOpen = false;
    bool al, toggle;
    private void Start()
    {
        animator1 = doorRight.GetComponent<Animator>();
        animator2 = doorLeft.GetComponent<Animator>();
        if (startOpen)
        {
            activateObj();
        }
    }
    private void Update()
    {
        if(toggle && al)
        {
            OpenDoor();
        }
        else if(!toggle && al) 
        { 
            CloseDoor();
        }
    }
    public void activateObj()
    {
        if (toggle)
        {
            toggle = false;
            al = true;
        }
        else
        {
            toggle = true;
            al = true;
        }
    }
    public void OpenDoor()
    {
        animator1.SetTrigger("Open");
        animator2.SetTrigger("Open");
        al = false;
    }
    public void CloseDoor()
    {
        animator1.SetTrigger("Close");
        animator2.SetTrigger("Close");
        al = false;
    }
}
