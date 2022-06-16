using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject cameraFocus;
    private Vector3 distanceOffsetVector;
    public float distanceOffsetFloat;

    void Start()
    {
        distanceOffsetVector = new Vector3(0, 0, distanceOffsetFloat);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraFocus.transform.position + cameraFocus.transform.forward + distanceOffsetVector;
        transform.LookAt(cameraFocus.transform);
    }
}
