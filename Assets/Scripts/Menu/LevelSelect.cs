using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    bool isShowing = false;
    public void ToggleShow()
    {
        isShowing = !isShowing;
        if (isShowing)
        {
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(true);
            }
            GetComponent<MeshRenderer>().material.SetFloat("_MKGlowPower", 1);
        }
        else
        {
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(false);
            }
            GetComponent<MeshRenderer>().material.SetFloat("_MKGlowPower", 0);
        }
    }
}
