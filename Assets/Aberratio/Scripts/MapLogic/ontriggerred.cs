using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ontriggerred : MonoBehaviour
{
    public bool door, cube1, logicerch2, map, ch3logicDo;
    public GameObject activatedObject, cube,logicch2,logicch3;
    private void OnTriggerEnter(Collider other)
    {
        if (!door)
        {
            ColorManager.instance.Red();
            GameObject.Destroy(gameObject);
        }
        else
        {
            activatedObject.GetComponent<Door>().activateObj();
            GameObject.Destroy(gameObject);
        }
        if(logicerch2)
        {
            logicch2.GetComponent<ch2logic>().logicers();
            Debug.Log("hel1");
            GameObject.Destroy(gameObject);
        }
        if (ch3logicDo)
        {
            logicch3.GetComponent<ch3logic>().logicers();
            GameObject.Destroy(gameObject);
        }
        if (map)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
