using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private float GroundCheckDistance = 0.1f;
    [SerializeField] private float jumpForce;
    [SerializeField] private AudioSource jumpSound;

    bool IsOnGround
    {
        get
        {
            return Physics.Raycast(GroundCheck.position, Vector3.down, GroundCheckDistance, GroundMask);
        }
    }

    public bool CanJump { get; set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        CanJump = true;
    }

    private void Update()
    {
        if (!CanJump) return;

        if (Input.GetButtonDown("Jump") && IsOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpSound.Play();
        }
    }
}
