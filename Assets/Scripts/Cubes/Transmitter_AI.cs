using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Transmitter_AI : MonoBehaviour, CubeInterface
{

    public NavMeshAgent agent { get; set; }
    public int Weight { get; set; }
    public GameObject TeleportationPrefab;
    private NavMeshPath Path;

    private bool isSelected = false;
    private int defAgentID;

    void Start()
    {
        Weight = 1;
        Path = new NavMeshPath();
        agent = GetComponent<NavMeshAgent>();
        defAgentID = agent.agentTypeID;
    }

    void Update()
    {
        //if (isSelected)
        //{
        //	TransmitSwitch.SetActive(true);
        //}

        //if (Input.GetKeyDown(KeyCode.Space) && isSelected)
        //{
        //	Instantiate(TeleportationPrefab, transform);
        //	Instantiate(TeleportationPrefab, GameObject.Find("Jumper").transform);
        //	Teleport(GameObject.Find("Jumper"));
        //}
    }

    public void SetTarget(RaycastHit rayHit)
    {
        agent.agentTypeID = defAgentID;
        if (agent.CalculatePath(rayHit.point, Path))
            agent.destination = rayHit.point;
    }
    public void SetTarget(Vector3 dest)
    {
        agent.agentTypeID = defAgentID;
        if (agent.CalculatePath(dest, Path))
            agent.destination = dest;
    }

    public void Teleport(GameObject otherCube)
    {
        GetComponents<AudioSource>()[getRandom()].Play();

        Vector3 t = transform.position;
        //transform.position = otherCube.transform.position;
        //SetTarget(otherCube.transform.position);
        Instantiate(TeleportationPrefab, transform);
        Instantiate(TeleportationPrefab, otherCube.transform);
        agent.enabled = false;
        otherCube.GetComponent<CubeInterface>().agent.enabled = false;
        agent.Warp(otherCube.transform.position + Vector3.up);
        agent.agentTypeID = otherCube.GetComponent<CubeInterface>().agent.agentTypeID;

        //otherCube.transform.position = t;
        //otherCube.GetComponent<CubeInterface>().SetTarget(t);
        otherCube.GetComponent<CubeInterface>().agent.Warp(t + Vector3.up);

        StartCoroutine(EndTeleportation(otherCube));
    }

    IEnumerator EndTeleportation(GameObject otherCube)
    {
        yield return new WaitForSeconds(0.5f);
        agent.enabled = true;
        otherCube.GetComponent<CubeInterface>().agent.enabled = true;
    }

    public void Selection(bool enable)
    {

        GetComponent<Light>().enabled = enable;
        isSelected = enable;
    }
    private int getRandom()
    {
        return Random.Range(0, 2);
    }
}
