using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    public bool CanMove { get; set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        CanMove = true;
    }

    private void Update()
    {
        if (!CanMove) return;

        Vector3 direction = GetInputDirection();

        if (direction == Vector3.zero) return;

        Move(direction);
        Rotate(direction);
    }

    private Vector3 GetInputDirection()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        return direction;
    }

    private void Move(Vector3 direction)
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity.x = direction.x * speed;
        newVelocity.z = direction.z * speed;
        rb.velocity = newVelocity;
    }

    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, newRotation, rotationSpeed * Time.deltaTime));
        }
    }
}
