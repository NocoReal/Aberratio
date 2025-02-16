using UnityEngine;

public class RemoteController : MonoBehaviour
{
    public static RemoteController instance;
    public bool Red, Green, Blue;
    private void Awake()
    {
        instance = this;
    }
    public void None()
    {
        Red = false; Green = false; Blue = false;
    }
    public void RedToggle()
    {
        if(Red)
        {
            Red = false;
        }
        else
        {
            Red = true;
        }
    }
    public void GreenToggle()
    {
        if (Green)
        {
            Green = false;
        }
        else
        {
            Green = true;
        }
    }
    public void BlueToggle()
    {
        if (Blue)
        {
            Blue = false;
        }
        else
        {
            Blue = true;
        }
    }
}
