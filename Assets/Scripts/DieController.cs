using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController), typeof(JumpController))]
public class DieController : MonoBehaviour
{
    Rigidbody rb;
    MovementController movementController;
    JumpController jumpController;

    [SerializeField] private AudioSource checkpointSound;
    [SerializeField] private AudioSource deathSpikesSound;
    [SerializeField] private AudioSource deathWaterSound;

    [SerializeField] private FollowCharacter followCharacter;
    [SerializeField] private float upForce = 30f;
    [SerializeField] private float noiseMax = 10f;
    [SerializeField] private float respawnTime = 3f;

    Vector3 checkpointPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementController = GetComponent<MovementController>();
        jumpController = GetComponent<JumpController>();

        checkpointPosition = transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            Vector3 force = new Vector3(Random.Range(-noiseMax, noiseMax), upForce, Random.Range(-noiseMax, noiseMax));
            Die(force);
            deathSpikesSound.Play();
        }

        if (other.gameObject.CompareTag("Checkpoint") && other.transform.position != checkpointPosition)
        {
            checkpointPosition = other.transform.position;
            checkpointSound.Play();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            Die(Vector3.zero);
            deathWaterSound.Play();
        }
    }

    private void Die(Vector3 force)
    {
        movementController.CanMove = false;
        jumpController.CanJump = false;

        followCharacter.SetTarget(null);

        rb.AddForce(force, ForceMode.Impulse);

        StartCoroutine(Respawn());
    }

    public void UpdateCheckpoint(Vector3 newCheckpointPosition)
    {
        checkpointPosition = newCheckpointPosition;
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);

        movementController.CanMove = true;
        jumpController.CanJump = true;

        rb.position = checkpointPosition;

        followCharacter.SetTarget(transform);
    }
}
