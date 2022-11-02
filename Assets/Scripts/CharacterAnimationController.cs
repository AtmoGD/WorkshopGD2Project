using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class CharacterAnimationController : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!animator || !rb) return;

        animator.SetFloat("Movement", rb.velocity.magnitude);
        animator.SetFloat("FallSpeed", Mathf.Abs(rb.velocity.y));
    }
}
