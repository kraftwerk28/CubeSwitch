using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
	public GameObject wirePath;
	public GameObject Server;
	private bool isPressed = false;
	private Animator animator;
	private int WeightSum = 0;

	//public delegate void Pressing(bool isPressed);
	//public event Pressing ButtonPress;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Character")
		{
			WeightSum += other.GetComponent<CubeInterface>().Weight;
		}
		if (WeightSum >= 4)
		{
			animator.SetTrigger("Accept");
			GetComponents<AudioSource>()[1].Play();
			StartCoroutine(Transmit());
		}

		
		if (!isPressed)
		{
			animator.SetBool("Press", true);
			GetComponents<AudioSource>()[0].Play();
		}
			

		
	}
	private void OnTriggerStay(Collider other)
	{
		//wirePath.GetComponent<LineRenderer>().enabled = true;
		//wirePath.GetComponent<AnimatedLineRender>().increasing = true;
		//Debug.Log("Button pressed");
		if (other.tag == "Character" && !isPressed)
		{
			isPressed = true;
			//ButtonPress(true);
			animator.SetBool("Press", true);
		}

	}
	private void OnTriggerExit(Collider other)
	{
		if (WeightSum < 4)
		{
			animator.SetBool("Press", false);
		}
			
		//wirePath.GetComponent<LineRenderer>().enabled = false;
		//wirePath.GetComponent<AnimatedLineRender>().increasing = false;
		if (other.tag == "Character")
		{
			WeightSum -= other.GetComponent<CubeInterface>().Weight;
			isPressed = false;
			//ButtonPress(false);
		}
	}

	IEnumerator Transmit()
	{
		yield return new WaitForSeconds(0.5f);
		Server.GetComponent<ServerTransmitter>().Transmit();
		wirePath.GetComponent<LineRenderer>().enabled = true;
		wirePath.GetComponent<AnimatedLineRender>().increasing = true;
	}
}
