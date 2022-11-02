using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : TriggerBase
{
    [SerializeField] private float Speed;
    [SerializeField] private Vector3 Direction;
    [SerializeField] private float Distance;

    private Vector3 targetPosition;
    bool isMoving = false;

    private void Start()
    {
        targetPosition = transform.position + Direction * Distance;
    }

    private void Update()
    {
        if (!isMoving) return;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Speed * Time.deltaTime);
    }


    public override void Trigger()
    {
        isMoving = true;
    }
}
