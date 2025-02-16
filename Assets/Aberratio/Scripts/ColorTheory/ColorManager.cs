using System.Collections;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [HideInInspector] public static ColorManager instance;
    [HideInInspector] public bool RedG, GreenG, BlueG, CDA; // EVERYTHING IS INVERSED IF ITS FALSE ITS ON, IF ITS TRUE ITS OFF; CDA stands for Can't Do All, as in you cant turn off all color.
    string lastColor;
    
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
                    StartCoroutine(wait1());
                }
            }
            if (RedG == true && GreenG == true && BlueG == true)
            {
                if (lastColor == "green")
                {
                    GreenG = false;
                    StartCoroutine(wait1());
                }
            }
            if (RedG == true && GreenG == true && BlueG == true)
            {
                if (lastColor == "blue")
                {
                    BlueG = false;
                    StartCoroutine(wait1());
                }
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
        lastColor="green";
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
        lastColor ="blue";
    }
    IEnumerator wait1()
    {
        CDA = true;
        yield return new WaitForSeconds(1);
        CDA = false;
    }
}
