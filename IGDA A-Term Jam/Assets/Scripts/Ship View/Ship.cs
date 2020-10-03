using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    private float speed;

    private float accelerationPower = 0.5f; // Ships acceleration ability (higher means more rapid acceleration)
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
            Resources.Load<Sprite>("Sprites/Objects/Ship Parts/Sails/sailLarge (8)"), // no damage
            Resources.Load<Sprite>("Sprites/Objects/Ship Parts/Sails/sailLarge (2)"), // partly damaged
            Resources.Load<Sprite>("Sprites/Objects/Ship Parts/Sails/sailLarge (14)"), // mostly damaged
            Resources.Load<Sprite>("Sprites/Objects/Ship Parts/Sails/sailLarge (20)") // destroyed
        };

        UpdateShipSail();
    }

    // Update used for physics calculations as it is independent of frame rate
    void FixedUpdate() {
        //rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude;

        rb.AddRelativeForce(Vector2.up * speed * (1 - GlobalValues.waterLevel / 100));

        rb.AddForce(new Vector2(0f, -accelerationPower*oceanForceMultiplier)); //Constant force applied by waves
    }

    // Updates ship model based on health and stored hull and sail models
    public void UpdateShipDamageModel(float health) {
        if (health >= 80) {
            hullModel.sprite = hullModels[0];
            sailModel.sprite = sailModels[0];
        } else if (health >= 60) {
            hullModel.sprite = hullModels[0];
            sailModel.sprite = sailModels[1];
        } else if (health >= 40) {
            hullModel.sprite = hullModels[1];
            sailModel.sprite = sailModels[1];
        } else if (health >= 20) {
            hullModel.sprite = hullModels[1];
            sailModel.sprite = sailModels[2];
        } else if (health >= 0) {
            hullModel.sprite = hullModels[2];
            sailModel.sprite = sailModels[2];
        } else {
            hullModel.sprite = hullModels[3];
            sailModel.sprite = sailModels[3];
        }
    }

    // Updates the ship speed and sail display based off globally set sail height
    public void UpdateShipSail(){
        sailModel.transform.localScale = new Vector2(1f, 1.1f - GlobalValues.sailHeight);
        speed = (1f - GlobalValues.sailHeight) * accelerationPower;
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
