using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jumper_AI : MonoBehaviour, CubeInterface
{
    public ParticleSystem JumpTr;
    public float JumpVelocity = 1.8f;
    public float simulTime = 0.5f;
    public NavMeshAgent agent { get; set; }
    public int Weight { get; set; }
    private NavMeshPath Path;
    private Animator animator;
    private Vector3 currentRot;

    void Start()
    {
        Weight = 1;
        currentRot = transform.eulerAngles;
        JumpTr.Stop();
        animator = GetComponent<Animator>();
        Path = new NavMeshPath();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agent.velocity.y > JumpVelocity)
        {
            StartCoroutine(JumpTrail());
            animator.SetBool("Jump", true);
        }
        else
            animator.SetBool("Jump", false);

        if (agent.velocity.y < -JumpVelocity)
        {
            StartCoroutine(JumpTrail());
            animator.SetBool("Down", true);
        }
        else
            animator.SetBool("Down", false);

        Vector3 r = agent.velocity;
        transform.eulerAngles = currentRot + new Vector3(r.z, 0, -r.x) * 3;
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

    IEnumerator JumpTrail()
    {
        JumpTr.Play();
        yield return new WaitForSeconds(simulTime);
        JumpTr.Stop();
    }
    public void Selection(bool enable)
    {
        GetComponent<Light>().enabled = enable;
    }
}
