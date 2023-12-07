using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CamController : MonoBehaviour
{

    public float sensitivity = 5f;
    public float minYAngle = -20f;
    public float maxYAngle = 80f;

    private float currentX = 0f;
    private float currentY = 0f;
    private float upwardAdjustment = 1.0f; 

    private Transform parentTransform;
    public LayerMask collisionLayers; // Layers to check for collision

    private Vector3 offset = new Vector3(4, 4, 4);

    void Start()
    {
        parentTransform = transform.parent;
        transform.localPosition = offset; // Set initial position as the offset
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY += Input.GetAxis("Mouse Y") * sensitivity;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    }

    void LateUpdate()
    {
        parentTransform.localRotation = Quaternion.Euler(currentY, currentX, 0);
       
        Vector3 desiredCameraPos = parentTransform.TransformPoint(offset);
        RaycastHit hit;

        if (Physics.Linecast(parentTransform.position, desiredCameraPos, out hit))
        {

            if (!hit.collider.CompareTag("Terrain")) 
            {
                Vector3 collisionPoint = hit.point;
                collisionPoint += transform.up * upwardAdjustment; // Adjusting the camera position upwards
                transform.position = collisionPoint;
            }
            else
            {
                transform.position = desiredCameraPos;
            }
        }
        else
        {
            transform.position = desiredCameraPos;
        }

        transform.LookAt(parentTransform.position);
    }
}

