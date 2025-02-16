using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public TextMeshProUGUI SensDisplay;
    public Scrollbar SensSlider;
    float xSens, ySens;
    [Tooltip("Default is 1; (Code sens is 10f * this)")]
    public float sensSettings;
    public Transform Camera;
    float xRotation, yRotation;
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
        sensSettings = SensSlider.value * 2f;
        SensDisplay.text = sensSettings.ToString();
        
        xSens = 10 * sensSettings;
        ySens = xSens;
        
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;

        yRotation += mouseCoord.x * Time.deltaTime * xSens;
        xRotation -= mouseCoord.y * Time.deltaTime * ySens;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        Camera.rotation = Quaternion.Euler(xRotation, yRotation, 0);//normaly the camera rotates with the player, but i have to rotate it manually
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void SaveSens()
    {
        float sensValue = sensSettings;
        PlayerPrefs.SetFloat("SensValue", sensValue);
        // Debug.Log(sensValue + "Save");
        LoadSens();
    }

    public void LoadSens()
    {
        float sensValue = PlayerPrefs.GetFloat("SensValue");
        sensSettings = sensValue;
        SensSlider.value = sensSettings * 0.5f;
        // Debug.Log(sensValue + "Load");
    }
}
