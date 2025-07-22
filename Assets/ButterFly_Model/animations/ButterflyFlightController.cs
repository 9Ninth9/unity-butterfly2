using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyFlightController : MonoBehaviour
{
    public Transform topLeftWing;
    public Transform topRightWing;
    public Transform bottomLeftWing;
    public Transform bottomRightWing;

    public float flapSpeed = 5f;       // Speed of wing flapping
    public float flapAngle = 30f;      // Max flap rotation in degrees
    public float circleRadius = 2f;    // Radius of the flight circle
    public float flightSpeed = 1f;     // Speed of circular movement
    public float verticalFlapAmplitude = 0.1f; // How much the butterfly rises and falls with each flap

    private float angleAroundCircle = 0f;
    private float startTime;

    private Vector3 centerPosition;

    void Start()
    {
        startTime = Time.time;
        centerPosition = transform.position; // Store the initial position as center of flight circle
    }

    void Update()
    {
        // Flap the wings
        float flap = Mathf.Sin((Time.time - startTime) * flapSpeed);
        float wingRotation = flap * flapAngle;

        if (topLeftWing != null)
            topLeftWing.localRotation = Quaternion.Euler(0f, 0f, wingRotation);

        if (bottomLeftWing != null)
            bottomLeftWing.localRotation = Quaternion.Euler(0f, 0f, wingRotation);

        if (topRightWing != null)
            topRightWing.localRotation = Quaternion.Euler(0f, 0f, -wingRotation);

        if (bottomRightWing != null)
            bottomRightWing.localRotation = Quaternion.Euler(0f, 0f, -wingRotation);

        // Use wing position to influence vertical offset
        float verticalOffset = flap * verticalFlapAmplitude;

        // Circle around the original position
        angleAroundCircle += Time.deltaTime * flightSpeed;
        float x = Mathf.Cos(angleAroundCircle) * circleRadius;
        float z = Mathf.Sin(angleAroundCircle) * circleRadius;
        float y = verticalOffset;

        transform.position = centerPosition + new Vector3(x, y, z);

        transform.LookAt(centerPosition); // Optional: face toward center of circle
    }
}
