using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyWingFlap : MonoBehaviour
{
    public Transform topLeftWing;
    public Transform topRightWing;
    public Transform bottomLeftWing;
    public Transform bottomRightWing;
    public float flapSpeed = 5f;      // How fast the wings flap
    public float flapAngle = 30f;     // Maximum angle from rest position

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float angle = Mathf.Sin((Time.time - startTime) * flapSpeed) * flapAngle;

        if (topLeftWing != null)
            topLeftWing.localRotation = Quaternion.Euler(0f, 0f, angle);

        if (bottomLeftWing != null)
            bottomLeftWing.localRotation = Quaternion.Euler(0f, 0f, angle);

        if (topRightWing != null)
            topRightWing.localRotation = Quaternion.Euler(0f, 0f, -angle);

        if (bottomRightWing != null)
            bottomRightWing.localRotation = Quaternion.Euler(0f, 0f, -angle);
    }
}

