using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Rigidbody Rb;
    [SerializeField] private Vector3 Direction = Vector2.zero;
    [SerializeField] private float Speed = 0.0f;
    [SerializeField] private float Distance = 0.0f;
    [SerializeField] private float Delay = 2.0f;

    private Vector3 StartPosition = Vector3.zero;
    private Vector3 EndPosition = Vector3.zero;
    private Vector3 TargetPosition = Vector3.zero;
    private float CurrentDelay = 0.0f;

    private void Start()
    {
        StartPosition = transform.position;
        EndPosition = StartPosition + Direction * Distance;
        TargetPosition = EndPosition;
    }

    private void Update()
    {
        if (CurrentDelay > 0.0f)
        {
            CurrentDelay -= Time.deltaTime;
            return;
        }

        Rb.MovePosition(Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.fixedDeltaTime));

        if (Vector3.Distance(transform.position, TargetPosition) < 0.1f)
        {
            Rb.MovePosition(TargetPosition);
            TargetPosition = TargetPosition == StartPosition ? EndPosition : StartPosition;
            CurrentDelay = Delay;
        }
    }
}
