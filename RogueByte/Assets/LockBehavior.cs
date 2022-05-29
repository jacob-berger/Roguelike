using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBehavior : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    [SerializeField]
    string tag;

    private Transform previousTarget;
    private CameraMovement cameraMovement;
    private bool isLocked = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = camera.GetComponent<CameraMovement>();    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == tag && !isLocked)
        {
            isLocked = true;
            PushTarget(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == tag && isLocked)
        {
            isLocked = false;
            PopTarget();
        }
    }

    private void PushTarget(Transform newTarget)
    {
        previousTarget = cameraMovement.TrackingTarget;
        cameraMovement.TrackingTarget = newTarget;
    }

    private void PopTarget()
    {
        cameraMovement.TrackingTarget = previousTarget;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
