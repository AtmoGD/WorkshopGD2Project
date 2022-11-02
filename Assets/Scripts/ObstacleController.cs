using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private Transform Obstacle;
    [SerializeField] private float Speed;

    private void Update()
    {
        Obstacle.Rotate(Vector3.up * Speed * Time.deltaTime);
    }
}
