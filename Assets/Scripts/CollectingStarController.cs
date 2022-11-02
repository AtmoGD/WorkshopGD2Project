using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingStarController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TMPro.TMP_Text scoreText;
    [SerializeField] private float DestroyDelay = 0.3f;
    [SerializeField] private int CollectedStars = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Star"))
        {
            Destroy(other.gameObject, DestroyDelay);
            CollectedStars++;
            scoreText.text = CollectedStars.ToString();
            audioSource.Play();
        }
    }
}
