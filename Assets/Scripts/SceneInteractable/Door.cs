using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    public bool shouldAllBePressed = false;
    public GameObject[] Buttons;
    private int pressCount = 0;

    private CameraNavigation _camera;
    private Animator animator;
    private NavMeshObstacle navMeshObstacle;
    private bool isOpened = false;

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraNavigation>();
        navMeshObstacle = GetComponent<NavMeshObstacle>();
        animator = GetComponent<Animator>();
        if (Buttons.Length > 0)
            foreach (GameObject b in Buttons)
            {
                b.GetComponent<DoorButton>().ButtonPress += Open;
            }
    }

    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //	navMeshObstacle.enabled = animator.GetBool("Open");
        //	animator.SetBool("Open", !animator.GetBool("Open"));
        //}

    }
    void Open(bool i)
    {
        if (i)
            pressCount++;
        else
            pressCount--;
        // Debug.Log("Door: " + pressCount);
        if (shouldAllBePressed)
        {
            if (pressCount >= Buttons.Length)
            {
                if (!isOpened)
                {
                    isOpened = true;
                    DoOpen();
                }
            }
            else
            {
                if (isOpened)
                {
                    isOpened = false;
                    DoClose();
                }
            }

        }
        else
        {
            if (pressCount > 0)
            {
                if (!isOpened)
                {
                    isOpened = true;
                    DoOpen();
                }
            }
            else
            {
                if (isOpened)
                {
                    isOpened = false;
                    DoClose();
                }
            }
        }
        //Debug.Log(pressCount);
    }

    void DoOpen()
    {
        navMeshObstacle.enabled = false;
        animator.SetBool("Open", true);
        GetComponents<AudioSource>()[0].Play();
        StartCoroutine(DoTargetCamera());
    }
    void DoClose()
    {
        navMeshObstacle.enabled = true;
        animator.SetBool("Open", false);
        GetComponents<AudioSource>()[1].Play();
        StartCoroutine(DoTargetCamera());
    }

    IEnumerator DoTargetCamera()
    {
        Transform old = _camera.Target;
        _camera.ChangeTarget(transform);
        yield return new WaitForSeconds(1);
        _camera.ChangeTarget(old);
    }
}
