using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField]
    public GameObject trackingTarget;

    [SerializeField]
    float xOffset;

    [SerializeField]
    float yOffset;

    [SerializeField]
    protected float followSpeed;

    [SerializeField]
    protected bool isXLocked = false;

    [SerializeField]
    protected bool isYLocked = false;


   
    void Update()
    {
        float xTarget = trackingTarget.transform.position.x + xOffset;
        float yTarget = trackingTarget.transform.position.y + yOffset;

        float xNew = transform.position.x;
        if (!isXLocked)
        {
            xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        }

        float yNew = transform.position.y;
        if (!isYLocked)
        {
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
        }    
        
        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }
}
