using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    private float speed;
    private float hullHealth; //Value between 0 (dead) and 100 (full health)
    //private float wheelPosition; //value between -540 and +540   (allows for 3 full turns)
    private float orientation; //0 - 360 direction of ship
    private float sailHeight; //value between 0 (fully lowered) and 1 (fully raised)
    private float waterLevel; //value between 0 (no water) and 1 (sunk)
    private float steeringAmount; //value between -1 and 1 used for player input
    private float accelerationPower = 0.5f; //Ships acceleration ability (higher means more rapid acceleration)
    private float steeringPower = 1f; //Ships turning ability (higher means capable of sharper turns)
    private float oceanForceMultiplier = 0.4f; //accelerationPower is multiplied by this constant to give a continuous downward force 
                                                      //applied by the ocean's minor waves on the ship
    private float waveForceMultiplier = 0.5f; //dictates force of larger waves pushing ship down

    private static Sprite[] hullModels;
    private static Sprite[] sailModels;
    public SpriteRenderer hullModel;
    public SpriteRenderer sailModel;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        hullModels = new Sprite[4]
        {
            Resources.Load<Sprite>("Sprites/Objects/Ship Parts/Hulls/hullLarge (1)"), // no damage
            Resources.Load<Sprite>("Sprites/Objects/Ship Parts/Hulls/hullLarge (2)"), // partly damaged
            Resources.Load<Sprite>("Sprites/Objects/Ship Parts/Hulls/hullLarge (3)"), // mostly damaged
            Resources.Load<Sprite>("Sprites/Objects/Ship Parts/Hulls/hullLarge (4)") // destroyed
        };
        sailModels = new Sprite[4]
        {
            Resources.Load<Sprite>("Assets/Resources/Sprites/Objects/Ship Parts/Sails/sailLarge (2)"), // no damage
            Resources.Load<Sprite>("Assets/Resources/Sprites/Objects/Ship Parts/Sails/sailLarge (8)"), // partly damaged
            Resources.Load<Sprite>("Assets/Resources/Sprites/Objects/Ship Parts/Sails/sailLarge (14)"), // mostly damaged
            Resources.Load<Sprite>("Assets/Resources/Sprites/Objects/Ship Parts/Sails/sailLarge (20)") // destroyed
        };

        SetHealth(100); //Set health to full at start of game
        SetSailHeight(0); //Lower sails for full speed ahead
    }


    // Update used for physics calculations as it is independent of frame rate
    void FixedUpdate() {
        SetSteeringAmount(-Input.GetAxis("Horizontal")); //Left and right player input

        orientation = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * orientation;

        rb.AddRelativeForce(Vector2.up * speed);

        rb.AddForce(new Vector2(0f, -accelerationPower*oceanForceMultiplier)); //Constant force applied by waves

        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
    }


    // Sets ship health and updates ship damage model (value 0 - 100 here 0 is worst condition and 100 is best)
    public void SetHealth(int value) {
        hullHealth = Mathf.Clamp(value, 0, 100);
        UpdateShipDamageModel();
    }

    // Increments ship health by given increment and updates ship damage model
    public void IncrementHealth(int increment) {
        hullHealth = Mathf.Clamp(hullHealth += increment, 0, 100);
        UpdateShipDamageModel();
    }

    // Updates ship model based on health and stored hull and sail models
    private void UpdateShipDamageModel() {
        if (hullHealth >= 80) {
            hullModel.sprite = hullModels[0];
            sailModel.sprite = sailModels[0];
        } else if (hullHealth >= 60) {
            hullModel.sprite = hullModels[0];
            sailModel.sprite = sailModels[1];
        } else if (hullHealth >= 40) {
            hullModel.sprite = hullModels[1];
            sailModel.sprite = sailModels[1];
        } else if (hullHealth >= 20) {
            hullModel.sprite = hullModels[1];
            sailModel.sprite = sailModels[2];
        } else if (hullHealth >= 0) {
            hullModel.sprite = hullModels[2];
            sailModel.sprite = sailModels[2];
        } else {
            hullModel.sprite = hullModels[3];
            sailModel.sprite = sailModels[3];
        }
    }

    //Sets ships orientation
    public void SetOrientation(float value) {
        orientation = value;
        transform.rotation = new Quaternion(0f, 0f, orientation, 0f);
    }

    //Sets the ships sail height based on given value (range 0 - 1) where 0 is fully lowered and 1 is fully raised
    public void SetSailHeight(float value) {
        sailHeight = Mathf.Clamp(value, 0f, 1f);

        sailModel.transform.localScale = new Vector2(1f, 1.1f - sailHeight);

        speed = (1f - sailHeight) * accelerationPower;
    }

    //Sets the water level of ship
    public void SetWaterLevel(float value) {
        waterLevel = Mathf.Clamp(value, 0f, 100f);
    }

    //Sets steeringAmount based on player input (value between -1 and 1)
    public void SetSteeringAmount(float amount) {
        steeringAmount = amount;
    }

    public Sprite GetCurrentSailSprite() {
        return sailModel.sprite;
    }

    void OnTriggerStay2D(Collider2D collider){
        if (collider.gameObject.tag == "Wave")
        {
            // Hit a large wave, apply a large force downward
            rb.AddRelativeForce(Vector2.down * waveForceMultiplier);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Wave")
        {
            //fill boat with water dependent on speed
            // play splash SE
        } else if (collider.gameObject.tag == "Rock")
        {
            // screen shake
            // damage relative to speed of the boat when crash occurs
            // boat fills with water
            // crash SE
        }
    }
}
