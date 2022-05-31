using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    protected Transform trackingTarget;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xTarget = trackingTarget.position.x + xOffset;
        float yTarget = trackingTarget.position.y + yOffset;

        float xNew = transform.position.x;
        if (!isXLocked) {
            xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        }
        
        float yNew = transform.position.y;
        if (!isYLocked) {
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
        }

        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }

    public Transform TrackingTarget
    {
        get
        {
            return trackingTarget;
        }
        set
        {
            trackingTarget = value;
        }
    }
}
