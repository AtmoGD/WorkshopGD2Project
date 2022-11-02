using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        if (!target) return;

        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);

        transform.LookAt(target);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

}
