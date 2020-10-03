using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{

    public Rigidbody2D rb;

    private float orientation; //0 - 360 direction of ship
    private float rotation;
    private float steeringAmount; //value between -1 and 1 used for player input
    private float steeringPower = 1f; //Ships turning ability (higher means capable of sharper turns)
    private float wheelRotation;
    private float shipRotation;
    private Transform bgLeft;
    private Transform bgCenter;
    private Transform bgRight;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        bgLeft = transform.parent.Find("oceanSect1");
        bgCenter = transform.parent.Find("oceanSect2");
        bgRight = transform.parent.Find("oceanSect3");
    }

    //Update used for physics calculations as it is independent of frame rate
    void FixedUpdate()
    {
        SetSteeringAmount(-Input.GetAxis("Horizontal")); //Left and right player input
        orientation = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rotation = rb.rotation + steeringAmount * steeringPower * orientation;


        rb.SetRotation(rotation);

        moveBG(bgLeft);
        moveBG(bgCenter);
        moveBG(bgRight);
    }

    void moveBG(Transform bg)
    {
        bg.localPosition = new Vector3(bg.localPosition.x + steeringAmount / 20, 0);
        if(bg.localPosition.x > 7.2) bg.localPosition = new Vector3((float)(bg.localPosition.x - 14.4), 0);
        if (bg.localPosition.x < -7.2) bg.localPosition = new Vector3((float)(bg.localPosition.x + 14.4), 0);
    }

    //Sets steeringAmount based on player input (value between -1 and 1)
    public void SetSteeringAmount(float amount)
    {
        steeringAmount = amount;
    }

}
