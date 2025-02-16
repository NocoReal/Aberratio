using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorTogglePlayer : MonoBehaviour // this controls the player input
{
    [SerializeField] private InputActionReference Rbttn,Gbttn,Bbttn;
    private void Awake()
    {
        Rbttn.action.performed += RedF;
        Gbttn.action.performed += GreenF;
        Bbttn.action.performed += BlueF;
    }
    
    void RedF(InputAction.CallbackContext obj)
    {
        if (!PauseMenu.GameIsPaused)
        {
            ColorManager.instance.Red();
            Debug.Log("Red Button");
        }
    }
    void GreenF(InputAction.CallbackContext obj)
    {
        if (!PauseMenu.GameIsPaused)
        {
            ColorManager.instance.Green();
            Debug.Log("Green Button");
        }
    }
    void BlueF(InputAction.CallbackContext obj)
    {
        if (!PauseMenu.GameIsPaused)
        {
            ColorManager.instance.Blue();
            Debug.Log("Blue Button");
        }
    }
}
