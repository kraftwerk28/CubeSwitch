using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
	public bool shouldAllBePressed = false;
	public GameObject[] Buttons;
	private int pressCount = 0;

	private Animator animator;
	private NavMeshObstacle navMeshObstacle;
	private bool isOpened = false;
	
	void Start()
	{
		navMeshObstacle = GetComponent<NavMeshObstacle>();
		animator = GetComponent<Animator>();
		foreach (GameObject b in Buttons)
		{
			b.GetComponent<Button>().ButtonPress += Open;
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
		Debug.Log("Door: " + pressCount);
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
	}
	void DoClose()
	{
		navMeshObstacle.enabled = true;
		animator.SetBool("Open", false);
		GetComponents<AudioSource>()[1].Play();
	}
}
