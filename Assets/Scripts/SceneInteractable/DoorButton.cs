using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public int neededWeight = 2;
    public GameObject wirePath;
    public GameObject ButtonTable;

    private int currentWeight;
    private GameObject[] Tables;
    private List<GameObject> tables = new List<GameObject>(5);

    private int WeightSum = 0;
    private bool isPressed = false;
    private bool triggeredDoor = false;
    private Animator animator;

    public delegate void Pressing(bool isPressed);
    public event Pressing ButtonPress;

    private void Start()
    {
        foreach (Transform t in ButtonTable.transform)
        {
            tables.Add(t.gameObject);
        }
        animator = GetComponent<Animator>();

        currentWeight = neededWeight;
        SetTable(neededWeight);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            WeightSum += other.GetComponent<CubeInterface>().Weight;
        }

        currentWeight = neededWeight - WeightSum;
        if (currentWeight > 0)
        {
            SetTable(currentWeight);
            GetComponent<AudioSource>().Play();
        }
        else
        {
            SetTable(0);
            wirePath.GetComponent<LineRenderer>().enabled = true;
            wirePath.GetComponent<AnimatedLineRender>().increasing = true;
            if (!triggeredDoor)
            {
                ButtonPress(true);
                triggeredDoor = true;
            }

            GetComponent<AudioSource>().Play();
        }
        // Debug.Log(WeightSum);
    }
    private void OnTriggerStay(Collider other)
    {
        //wirePath.GetComponent<LineRenderer>().enabled = true;
        //wirePath.GetComponent<AnimatedLineRender>().increasing = true;
        //Debug.Log("Button pressed");
        //if (other.tag == "Character" && !isPressed)
        //{
        //	isPressed = true;
        //	ButtonPress(true);
        //	animator.SetBool("Press", true);
        //}

        if (!isPressed && other.tag == "Character")
        {
            isPressed = true;
            animator.SetBool("Press", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //wirePath.GetComponent<LineRenderer>().enabled = false;
        //wirePath.GetComponent<AnimatedLineRender>().increasing = false;
        if (other.tag == "Character")
        {
            WeightSum -= other.GetComponent<CubeInterface>().Weight;
            //isPressed = false;
            //ButtonPress(false);
            //animator.SetBool("Press", false);
        }
        currentWeight = neededWeight - WeightSum;

        if (WeightSum <= 0)
        {
            isPressed = false;
            animator.SetBool("Press", false);
            GetComponent<AudioSource>().Play();
        }

        if (currentWeight > 0)
        {
            SetTable(currentWeight);
            wirePath.GetComponent<LineRenderer>().enabled = false;
            wirePath.GetComponent<AnimatedLineRender>().increasing = false;
            if (triggeredDoor)
            {
                triggeredDoor = false;
                ButtonPress(false);
            }
        }
    }


    private void SetTable(int num)
    {
        CleanTables();
        tables[num].SetActive(true);
    }

    private void CleanTables()
    {
        foreach (GameObject g in tables)
        {
            g.SetActive(false);
        }
    }
}
