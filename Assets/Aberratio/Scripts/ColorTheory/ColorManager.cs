using System.Collections;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public GameObject Player;
    [HideInInspector] public static ColorManager instance;
    [HideInInspector] public bool RedG, GreenG, BlueG, CDA; // EVERYTHING IS INVERSED IF ITS FALSE ITS ON, IF ITS TRUE ITS OFF; CDA stands for Can't Do All, as in you cant turn off all color.
    string lastColor;
    bool succeded;
    
   private void Awake()
    {
        instance = this; 
    }
    private void Update()
    {
        if(lastColor != null)
        {
            if(RedG == true && GreenG == true && BlueG == true)
            {
                if(lastColor == "red") 
                {
                    RedG = false;
                    Player.GetComponent<ColorTogglePlayer>().FailPlay();
                    succeded = false;
                }
            }
            if (RedG == true && GreenG == true && BlueG == true)
            {
                if (lastColor == "green")
                {
                    GreenG = false;
                    Player.GetComponent<ColorTogglePlayer>().FailPlay();
                    succeded = false;
                }
            }
            if (RedG == true && GreenG == true && BlueG == true)
            {
                if (lastColor == "blue")
                {
                    BlueG = false;
                    Player.GetComponent<ColorTogglePlayer>().FailPlay();
                    succeded = false;
                }
            }
            if (succeded)
            {
                ControlGlobalVolume.instance.RunColorToggle();
                Player.GetComponent<ColorTogglePlayer>().SucceedPlay();
                succeded = false;
            }
            lastColor = null;
        }
    }

    public void Red()
    {
        if (RedG == true)
        {
            RedG = false;
        }
        else
        {
            RedG = true;
        }
        succeded = true;
        lastColor = "red";
    }
    public void Green()
    {
        if (GreenG == true)
        {
            GreenG = false;
        }
        else
        {
            GreenG = true;
        }
        succeded = true;
        lastColor ="green";
    }
    public void Blue()
    {
        if (BlueG == true)
        {
            BlueG = false;
        }
        else
        {
            BlueG = true;
        }
        succeded = true;
        lastColor ="blue";
    }
}
