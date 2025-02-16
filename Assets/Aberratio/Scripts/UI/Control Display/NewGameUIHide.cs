using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameUIHide : MonoBehaviour
{
    public static NewGameUIHide instance;
    public GameObject ngUI;
    public GameObject UI1, UI2;
    public bool goOff1 = false,start;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (start)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                UI1.SetActive(true);
                goOff1 = true;
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                UI2.SetActive(true);
                goOff1 = true;
            }
            StartCoroutine(WaitBeforeDisappear());
        }
    }
    IEnumerator WaitBeforeDisappear() 
    {
        yield return new WaitForSeconds(10);
        ngUI.SetActive(false);
    }
}
