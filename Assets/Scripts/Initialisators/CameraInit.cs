using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<CameraNavigation>()._canvas = GameObject.Find("Canvas");
        Debug.Log("Setted!");
    }
}
