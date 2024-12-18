using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Header("References")]
    public Transform targetObject; 

    [Header("Smooth Settings")]
    public float positionSmoothSpeed = 5f; 
    public float rotationSmoothSpeed = 5f; 

    private Transform flashlightTransform;

    [SerializeField]AudioClip flashLightOn;
    [SerializeField]AudioClip flashLightOff;
    AudioSource audioSource;
    private void Start()
    {
        flashlightTransform = transform;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && enabled == false)
        {
            gameObject.GetComponent<Light>().enabled = !gameObject.GetComponent<Light>().enabled;
            audioSource.clip = flashLightOn;
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.Q) && enabled == true)
        {
            gameObject.GetComponent<Light>().enabled = !gameObject.GetComponent<Light>().enabled;
            audioSource.clip = flashLightOff;
            audioSource.Play();
        }

        flashlightTransform.position = Vector3.Lerp(
            flashlightTransform.position,
            targetObject.position,
            positionSmoothSpeed * Time.deltaTime
        );

        flashlightTransform.rotation = Quaternion.Slerp(
            flashlightTransform.rotation,
            targetObject.rotation,
            rotationSmoothSpeed * Time.deltaTime
        );
    }
}
