using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    private float speed;
    private int hullHealth; //Value between 0 (dead) and 3 (full health)
    //private float wheelPosition; //value between -540 and +540   (allows for 3 full turns)
    private float orientation; //0 - 360 direction of ship
    private float sailHeight; //value between 0 (fully lowered) and 1 (fully raised)
    private float waterLevel; //value between 0 (no water) and 1 (sunk)
    private float steeringAmount; //value between -1 and 1 used for player input
    private float accelerationPower = 3f; //Ships accelertaion ability (higher means more rapid acceleration)
    private float steeringPower = 1f; //Ships turning ability (higher means capable of sharper turns)

    public List<Sprite> hullModels;
    public List<Sprite> sailModels;
    public SpriteRenderer hullModel;
    public SpriteRenderer sailModel;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        SetHealth(3); //Set health to full at start of game
        SetSailHeight(0); //Lower sails for full speed ahead;
    }


    //Update used for physics calculations as it is independent of frame rate
    void FixedUpdate() {
        SetSteeringAmount(-Input.GetAxis("Horizontal")); //Left and right player input
        SetSailHeight(Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1)); //up down player input

        orientation = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * orientation;

        rb.AddRelativeForce(Vector2.up * speed);

        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);

    }


    //Sets ship health and updates ship damage model (value 0 - 3 where 0 is worst condition and 3 is best)
    public void SetHealth(int value) {
        hullHealth = value;
        Mathf.Clamp(hullHealth, 0, 3);
        UpdateShipDamageModel();
    }

    //Increments ship health by given increment and updates ship damage model
    public void IncrementHealth(int increment) {
        hullHealth += increment;
        Mathf.Clamp(hullHealth, 0, 3);
        UpdateShipDamageModel();
    }


    //updates ship model based on health and given hull and sail models
    private void UpdateShipDamageModel() {
        hullModel.sprite = hullModels[hullHealth];
        sailModel.sprite = sailModels[hullHealth];
    }

    //Sets ships orientation
    public void SetOrientation(float value) {
        orientation = value;
        transform.rotation = new Quaternion(0f, 0f, orientation, 0f);
    }

    //Sets the ships sail height based on given value (range 0 - 1) where 0 is fully lowered and 1 is fully raised
    public void SetSailHeight(float value) {
        sailHeight = value;
        Mathf.Clamp(sailHeight, 0f, 1f);

        speed = (1f - sailHeight) * accelerationPower;
    }

    //Sets the water level of ship
    public void SetWaterLevel(float value) {
        waterLevel = value;
        Mathf.Clamp(waterLevel, 0f, 100f);
    }

    //Sets steeringAmount based on player input (value between -1 and 1)
    public void SetSteeringAmount(float amount) {
        steeringAmount = amount;
    }

}
