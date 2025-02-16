using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public TextMeshProUGUI SensDisplay;
    public Slider SensSlider;
    float xSens, ySens;
    [Tooltip("Default is 1; (Code sens is 10f * this)")]
    public float sensSettings, multiplyer;
    public Transform Camera;
    float xRotation, yRotation;
    public bool canMove = true;
    Vector2 mouseCoord;
    [SerializeField] private InputActionReference Look;
    private void Awake()
    {
        Look.action.performed += ctx => mouseCoord = ctx.ReadValue<Vector2>();
        Look.action.canceled += ctx => mouseCoord = Vector2.zero;
        LoadSens();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        sensSettings = SensSlider.value * 0.1f;
        SensDisplay.text = sensSettings.ToString();//displays sens
        multiplyer = sensSettings * 10;

        xSens = 10 * sensSettings;
        ySens = xSens;
        
        //float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        //float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;

        yRotation += mouseCoord.x * Time.deltaTime * xSens;
        xRotation -= mouseCoord.y * Time.deltaTime * ySens;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);
        if (canMove)
        {
            Camera.rotation = Quaternion.Euler(xRotation, yRotation, 0);//normaly the camera rotates with the player, but i have to rotate it manually
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    public void SaveSens()
    {
        int sensValue = (int)multiplyer;
        PlayerPrefs.SetInt("SensValue", sensValue);
        LoadSens();
    }

    public void LoadSens()
    {
        int sensValue = PlayerPrefs.GetInt("SensValue");
        sensSettings = sensValue * 0.1f;
        SensSlider.value = sensValue;
    }
}
