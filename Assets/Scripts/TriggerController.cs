using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<TriggerBase> triggerObjects = new List<TriggerBase>();

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (TriggerBase triggerable in triggerObjects)
            {
                triggerable.Trigger();
            }

            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (TriggerBase triggerable in triggerObjects)
            {
                triggerable.Trigger();
            }

            audioSource.Play();
        }
    }
}
