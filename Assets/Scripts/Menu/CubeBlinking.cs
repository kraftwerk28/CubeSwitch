using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBlinking : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Blink", 0, 0.5f);
    }

    void Blink()
    {
        if (Random.Range(0, 3) == 0)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetTrigger("Blink");
        }
    }
}
