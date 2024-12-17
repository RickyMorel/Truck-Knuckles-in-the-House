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

    private void Start()
    {
        flashlightTransform = transform;

        if (targetObject == null)
        {
            Debug.LogError("Target Object is not assigned. Please assign a target object for the flashlight to follow.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<Light>().enabled = !gameObject.GetComponent<Light>().enabled;
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
