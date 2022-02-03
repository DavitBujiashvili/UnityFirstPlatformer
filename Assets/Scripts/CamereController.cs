using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereController : MonoBehaviour
{
    public Transform target;
    private Vector3 velocity =Vector3.zero;

    public Vector3 offset;

    public float damping=0.4f;
    
     void FixedUpdate ()
    {
        Vector3 desiredPosition = target.position + new Vector3(target.position.y+5,-target.position.y,target.position.z-1);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition,ref velocity, damping);
        transform.position = smoothedPosition;
    }
    
}
