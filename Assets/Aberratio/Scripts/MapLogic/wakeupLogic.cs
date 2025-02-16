using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wakeupLogic : MonoBehaviour
{
    Animator animator;
    public float startWait;
    public GameObject Player, wakeups, animatorObj, capsule; // wakeups hold the sound
    public Transform PlayerCamera;
    AudioSource wakeUpSound;
    bool startMovingCam = false;
    Quaternion startRotation = Quaternion.identity;
    Vector3 startPosition;
    public GameObject activatedObject;
    

    public Transform campos;

    void Start()
    {
        activatedObject.GetComponent<Door>().activateObj();
        capsule.SetActive(false);
        animator = animatorObj.GetComponent<Animator>();
        startRotation = PlayerCamera.transform.rotation ; startPosition = PlayerCamera.transform.position;
        PlayerCamera.transform.position = campos.transform.position;//set location
        PlayerCamera.transform.rotation = campos.transform.rotation * new Quaternion(1, 1, 180, 1);//set rotation
        Player.GetComponent<PlayerMovement>().canMove = false;
        Player.GetComponent<MouseLook>().canMove = false;
        wakeUpSound = wakeups.GetComponent<AudioSource>();
        Player.GetComponent<ColorTogglePlayer>().hasRemote = false;
        StartCoroutine(initialWait());
    }
    void FixedUpdate()
    {
        if (startMovingCam)
        {
            
            PlayerCamera.transform.position = campos.transform.position;//set location
            PlayerCamera.transform.rotation = campos.transform.rotation * new Quaternion(1,1,180,1);//set rotation
        }
    }
    IEnumerator initialWait()
    {
        yield return new WaitForSeconds(startWait);
        initiate();
    }
    IEnumerator SetCamBack()
    {
        
        yield return new WaitForSeconds(4.458f);
        startMovingCam = false;
        capsule.SetActive(true);
        Player.GetComponent<PlayerMovement>().canMove = true;
        Player.GetComponent<MouseLook>().canMove = true;
        PlayerCamera.transform.position = startPosition;
        PlayerCamera.transform.rotation = startRotation;
        yield return new WaitForSeconds(1f);
        NewGameUIHide.instance.start = true;Debug.Log("sad");
        yield return new WaitForSeconds(4f);
        StartCoroutine(toggleWait());
        wakeUpSound.Play();
        
    }
    IEnumerator toggleWait()
    {
        yield return new WaitForSeconds(16.35f);
        ColorManager.instance.Red();
    }
    void initiate()
    {
        StartCoroutine(SetCamBack());
        
         // toggle color after time
        startMovingCam = true;
        animator.SetTrigger("Start");
    }
}
