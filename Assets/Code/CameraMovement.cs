using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 cameraOffset;

    [Range(0.01f,1.0f)]
    [SerializeField] private float smothFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //the player can be null when it die
        if (playerTransform != null) 
        {
            Vector3 newPos = playerTransform.position + cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, smothFactor);
        }
    }
}
