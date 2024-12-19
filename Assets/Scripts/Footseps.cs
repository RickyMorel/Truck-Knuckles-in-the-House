using System.Security.Cryptography;
using UnityEngine;

public class Footseps : MonoBehaviour
{
    public AudioClip[] footstepSound;
    public float stepDistance = 1f; 
    private Vector3 originalPosition; 
    private AudioSource audioSource; 

    void Start()
    {

        originalPosition = transform.position;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false; 
    }

    void Update()
    {
        float distanceMoved = Vector3.Distance(originalPosition, transform.position);

        if (distanceMoved >= stepDistance)
        {
            PlayFootstepSound();
            originalPosition = transform.position;
        }
    }

    void PlayFootstepSound()
    {
        if (audioSource != null && footstepSound != null)
        {
            int RandomNumber = Random.Range(0, footstepSound.Length);
            audioSource.clip = footstepSound[RandomNumber];
            audioSource.Play(); 

        }
    }

}
