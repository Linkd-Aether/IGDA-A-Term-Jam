using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{

    public Rigidbody2D rb;

    private float orientation; //0 - 360 direction of ship
    private float steeringAmount; //value between -1 and 1 used for player input
    private float steeringPower = 1f; //Ships turning ability (higher means capable of sharper turns)
    private float rotation;

    public float dispRot;


    // Start is called before the first frame update
    void Start()
    {

    }

    //Update used for physics calculations as it is independent of frame rate
    void FixedUpdate()
    {
        SetSteeringAmount(-Input.GetAxis("Horizontal")); //Left and right player input
        //rotation += steeringAmount * steeringPower;
        //dispRot = rotation;
        orientation = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rotation = rb.rotation + steeringAmount * steeringPower * orientation;

        print(rb.rotation);

        rb.SetRotation(rotation);

    }

    //Sets steeringAmount based on player input (value between -1 and 1)
    public void SetSteeringAmount(float amount)
    {
        steeringAmount = amount;
    }

}
