using UnityEngine;

public class WhatColorIsThis : MonoBehaviour // this controls if the object should be shown or not
{
    
    bool RedB,BlueB,GreenB,transparent;
    private bool RedP, GreenP, BlueP, RedC, GreenC,BlueC;
    int colorNrP = 0, colorNrG = 0;
    MeshRenderer mR;
    Collider col;
    Rigidbody rb;
    Renderer rndr;
    Material mat;
    Color colorOG;
    private void Awake()
    {
        rndr = GetComponent<Renderer>();// this is needed to get the material color
        mat = rndr.material;
        colorOG = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a); // this gets the material color and sets the bools automaticaly
    }
    private void Start()
    {
        if (colorOG.r > 0.5f)
        {
            RedB = true;
        }
        else
        {
            RedB = false;
        }
        if (colorOG.g > 0.5f)
        {
            GreenB = true;
        }
        else
        {
            GreenB = false;
        }
        if (colorOG.b > 0.5f)
        {
            BlueB = true;
        }
        else
        {
            BlueB = false;
        }

        if (RedB)
            ++colorNrP;
        if (GreenB)
            ++colorNrP;
        if (BlueB)
            ++colorNrP;

        mR = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>(); // so the object stops in place
    }
    void FixedUpdate()
    {
        manageColor();
    }
    void manageColor()
    {
        RedP = ColorManager.instance.RedG;
        GreenP = ColorManager.instance.GreenG; // gets the color from the manager
        BlueP = ColorManager.instance.BlueG;
        if (RedB)// nush da merge
        {
            if (RedC != RedP)
            {
                if (RedP == false)
                    --colorNrG;
                if (RedP == true)
                    ++colorNrG;
            }
            RedC = RedP;
        }
        if (GreenB)
        {
            if (GreenC != GreenP)
            {
                if (GreenP == false)
                    --colorNrG;
                if (GreenP == true)
                    ++colorNrG;
            }
            GreenC = GreenP;
        }
        if (BlueB)
        {
            if (BlueC != BlueP)
            {
                if (BlueP == false)
                    --colorNrG;
                if (BlueP == true)
                    ++colorNrG;
            }
            BlueC = BlueP;
        }
        if (mat.color.a == 1 && !transparent)
        {
            if (colorNrG == colorNrP)
            {
                mR.enabled = false;
                col.enabled = false;
                if (rb != null)
                {
                    rb.useGravity = false;
                    rb.isKinematic = true;
                }
            }
            else
            {
                mR.enabled = true;
                col.enabled = true;
                if (rb != null)
                {
                    rb.useGravity = true;
                    rb.isKinematic = false;
                }
            }
        }
        else if (mat.color.a != 1 || transparent)
        {
            transparent = true;
            if (colorNrG == colorNrP)
            {
                col.enabled = true;
                mat.color = new Color(0, 0, 0, 1);
            }
            else
            {
                col.enabled = false;
                mat.color = new Color(colorOG.r,colorOG.g,colorOG.b,colorOG.a);
            }
        }
    }
}
