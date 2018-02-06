using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlowButton : MonoBehaviour
{
    private Animator animator;

    public delegate void bPress();
    public event bPress OnPress;
    public UnityEvent OnClick;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseEnter()
    {
        animator.SetTrigger("Highlight");
        // animator.SetBool("Highlight", true);
        GetComponents<AudioSource>()[0].Play();
    }

    void OnMouseExit()
    {
        animator.SetTrigger("Normal");
        // animator.SetBool("Highlight", false);
    }

    void OnMouseDown()
    {
        animator.SetTrigger("Press");
        // animator.SetBool("Press", true);
        if (OnPress != null)
            OnPress();
        OnClick.Invoke();
        GetComponents<AudioSource>()[1].Play();
    }

    void OnMouseUp()
    {
        animator.SetTrigger("Highlight");
        // animator.SetBool("Press", false);
    }
}
