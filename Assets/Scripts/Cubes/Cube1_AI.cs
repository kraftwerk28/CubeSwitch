using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cube1_AI : MonoBehaviour, CubeInterface
{
	public NavMeshAgent agent { get; set; }
	public int Weight { get; set; }
	private NavMeshPath Path;

	void Start()
	{
		Weight = 2;
		Path = new NavMeshPath();
		agent = GetComponent<NavMeshAgent>();
	}
	
	void Update()
	{
		
	}

	public void SetTarget(RaycastHit rayHit)
	{
		if (agent.CalculatePath(rayHit.point, Path))
			agent.destination = rayHit.point;
	}
	public void SetTarget(Vector3 dest)
	{
		if (agent.CalculatePath(dest, Path))
			agent.destination = dest;
	}
	public void Selection(bool enable)
	{
		GetComponent<Light>().enabled = enable;
	}
}
