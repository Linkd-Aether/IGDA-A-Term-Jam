﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    private Rigidbody2D rb;
    private Rigidbody2D rbShip;

    private float orientation; //0 - 360 direction of ship
    private float steeringAmount; //value between -1 and 1 used for player input
    private float steeringPower = .6f; //Ships turning ability (higher means capable of sharper turns)
    private float wheelRotation;
    private float shipRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rbShip = GameObject.FindGameObjectWithTag("PlayerShip").GetComponent<Rigidbody2D>();
    }

    //Update used for physics calculations as it is independent of frame rate
    void FixedUpdate()
    {
        SetSteeringAmount(-Input.GetAxis("Horizontal")); // Left and right player input
        float steeringForce = steeringAmount * steeringPower;

        orientation = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        wheelRotation += steeringForce * orientation;
        rb.SetRotation(wheelRotation);

        shipRotation += steeringForce * rbShip.velocity.magnitude * 2f;
        rbShip.SetRotation(shipRotation);
        rbShip.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
    }

    //Sets steeringAmount based on player input (value between -1 and 1)
    public void SetSteeringAmount(float amount)
    {
        steeringAmount = amount;
    }
}
