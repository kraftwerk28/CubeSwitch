using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface CubeInterface
{
	int Weight { get; set; }
	NavMeshAgent agent { get; set; }
	void SetTarget(RaycastHit rayHit);
	void SetTarget(Vector3 dest);
	void Selection(bool enable);
}
