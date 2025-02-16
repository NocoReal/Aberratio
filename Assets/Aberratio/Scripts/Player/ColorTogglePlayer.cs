using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorTogglePlayer : MonoBehaviour // this controls the player input
{
    public static ColorTogglePlayer instance;
    [SerializeField] private InputActionReference Scrolling,Toggle;
    public AudioSource Fail, Succed;
    public Transform Nob;
    public bool pickedUp, hasRemote;
    bool canShoot,canScroll;
    public GameObject remote;
    Vector2 Scroll;
    int Counter; // 0 is red; 1 is green; 2 is blue.
    private void Awake()
    { 
        instance = this;
        canShoot = true; canScroll = true;
        Toggle.action.performed += ToggleColor;
        Scrolling.action.performed += ctx => Scroll = ctx.ReadValue<Vector2>();
        Scrolling.action.canceled += ctx => Scroll = Vector2.zero;
    }
    private void Update()
    {
        if(hasRemote)
        {
            remote.SetActive(true);
        }
        else
        {
            remote.SetActive(false);
        }
        Scroller();
    }
    void Scroller()
    {
        if (Scroll.y > 0 && canScroll)
        {
            if (Counter != -1)
            {
                Nob.rotation = Nob.transform.rotation * Quaternion.Euler(0, 0, -37);
                --Counter;
                StartCoroutine(ToggleWaitScroll());
            }
            if(Counter < 0) 
            {
                Nob.rotation = Nob.transform.rotation * Quaternion.Euler(0, 0, 111);
                Counter = 2;
                StartCoroutine(ToggleWaitScroll2());
            }
        }
        if (Scroll.y < 0 && canScroll)
        {
            if (Counter != 3)
            {
                Nob.rotation = Nob.transform.rotation * Quaternion.Euler(0, 0, 37);
                ++Counter;
                StartCoroutine(ToggleWaitScroll());
            }
            if (Counter > 2)
            {
                Nob.rotation = Nob.transform.rotation * Quaternion.Euler(0, 0, -111);
                Counter = 0;
                StartCoroutine(ToggleWaitScroll2());
            }
        }
    }
    void ToggleColor(InputAction.CallbackContext context)
    {
        if (!PauseMenu.GameIsPaused && canShoot && !pickedUp && hasRemote)
        { 
            if (Counter == 0)
            {
                RedF();
            }
            else if(Counter == 1)
            {
                GreenF();
            }
            else
            {
                BlueF();
            }
            StartCoroutine(ToggleWait());
        }
    }
    void RedF()
    {
        if (RemoteController.instance.Red)
        {
            ColorManager.instance.Red();
        }
        else
        {
            Fail.Play();
        }
    }
    void GreenF()
    {
        if (RemoteController.instance.Green)
        {
            ColorManager.instance.Green();
        }
        else
        {
            Fail.Play();
        }
    }
    void BlueF()
    {
        if (RemoteController.instance.Blue)
        {
            ColorManager.instance.Blue();
        }
        else
        {
            Fail.Play();
        }
    }
    IEnumerator ToggleWait()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.34f);
        canShoot = true;
    }
    IEnumerator ToggleWaitScroll()
    {
        canScroll = false;
        yield return new WaitForSeconds(0.1f);
        canScroll = true;
    }
    IEnumerator ToggleWaitScroll2()
    {
        canScroll = false;
        yield return new WaitForSeconds(0.2f);
        canScroll = true;
    }
    public void SucceedPlay() 
    {
        Succed.Play();
    }
    public void FailPlay()
    {
        Fail.Play();
    }
}
