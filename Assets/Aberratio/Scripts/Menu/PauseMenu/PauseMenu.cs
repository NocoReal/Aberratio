using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [HideInInspector] public bool IsInSettings = false;

    [SerializeField] private InputActionReference PauseKey;
    public GameObject HUD, PauseMenuObj, PauseMenuMain, SettingsMenu; //HUD holds the hud, pause obj holds the whole pause menu, menu main hold just the pause buttons, settings menu holds the settings
    private void Awake()
    {
        PauseKey.action.canceled += PauseGame;
    }
    private void Start()
    {
        Resume();
    }
    private void Update()
    {
        if (IsInSettings) 
        {
            PauseMenuMain.SetActive(false);
            SettingsMenu.SetActive(true);
        }
        else
        {
            PauseMenuMain.SetActive(true);
            SettingsMenu.SetActive(false);
        }

    }

    void PauseGame(InputAction.CallbackContext context)
    {
        if (GameIsPaused && !IsInSettings) 
        {
            Resume();
            IsInSettings = false;
        }
        else if(GameIsPaused && IsInSettings)
        {
            IsInSettings = false;
        }
        else if (!GameIsPaused) 
        {
            Pause();
            IsInSettings = false;
        }
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        HUD.SetActive(true);
        PauseMenuObj.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        HUD.SetActive(false);
        PauseMenuObj.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Settings()
    {
        if(IsInSettings == false) { IsInSettings = true; } else { IsInSettings = false; }
    }
    public void SaveSettingsCongfig()
    {

    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
