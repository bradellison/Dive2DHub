using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seatop : MonoBehaviour
{
    public Vector3 initalPosition;
    public Vector3 endPosition;
    public int pointCount = 10;
    public LineRenderer line;

    private Vector3 secondPosition;
    private Vector3[] points;
    private float segmentWidth;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();

        line.positionCount = pointCount;

        // tell the linerenderer to use the local 
        // transform space for the point coorindates
        line.useWorldSpace = false;

        points = new Vector3[pointCount];
    }

    private void Update()
    {

        var dir = endPosition - initalPosition;
        // get the segmentWidth from distance to end position
        segmentWidth = Vector3.Distance(initalPosition, endPosition) / pointCount;
        // get the difference angle in the Z axis between the current transform.right
        // and the direction
        var angleDifference = Vector3.SignedAngle(transform.right, dir, Vector3.forward);
        // and rotate the linerenderer transform by that angle in the Z axis
        // so the result will be that it's transform.right
        // points now towards the clicked position
        transform.Rotate(Vector3.forward * angleDifference, Space.World);

        for (var i = 0; i < points.Length; ++i)
        {
            float x = segmentWidth * i;
            float y = Mathf.Sin(x * Time.time);
            points[i] = new Vector3(x, y, 0);
        }
        
        line.SetPositions(points);
    }
}