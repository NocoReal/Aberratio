using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ControlGlobalVolume : MonoBehaviour
{
    public static ControlGlobalVolume instance;
    public Volume volume;
    float intensityChrm;
    bool goUp;
    ChromaticAberration chrm;
    private void Awake()
    {
        instance = this;
        volume.profile.TryGet<ChromaticAberration>(out chrm);
    }

    private void FixedUpdate()
    {
        if (goUp && intensityChrm != 1)
        {
            intensityChrm += 0.4f;
            if (intensityChrm >= 1.01)
                intensityChrm = 1;
            chrm.intensity.value = intensityChrm;
        }
        else if (!goUp && intensityChrm != 0)
        {
            intensityChrm -= 0.3f;
            if (intensityChrm <= -0.01)
                intensityChrm = 0;
            chrm.intensity.value = intensityChrm;
        }
    }
    public void RunColorToggle()
    {
        StartCoroutine(Runwaiter());
    }
    IEnumerator Runwaiter()
    {
        goUp = true;
        yield return new WaitForSeconds(0.15f);
        goUp = false;
    }
}
