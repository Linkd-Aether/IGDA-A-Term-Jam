using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        
        hullModels = hullModelVariants[0];
        sailModels = sailModelVariants[1];

        UpdateShipSail();
    }

    // Updates ship model based on health and stored hull and sail models
    public void UpdateShipDamageModel(float health) {
        base.UpdateShipDamageModel(hullModels, sailModels, health);
        GlobalValues.sail.UpdateSailDisplay();
    }

    // Updates the ship speed and sail display based off globally set sail height
    public void UpdateShipSail(){
        sailModel.transform.localScale = new Vector2(1f, 1.1f - GlobalValues.sailHeight);
        speed = (1f - GlobalValues.sailHeight) * accelerationPower;
    }

    public Sprite GetCurrentSailSprite() {
        return sailModel.sprite;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Wave")
        {
            // fill boat with water dependent on speed
            float relativeSpd = (rb.velocity - Vector2.down * oceanForceMultiplier * oceanForceMultiplier).magnitude;
            GlobalValues.deck.SetFloodAmount(relativeSpd * Constants.waveFloodMultiplier);

            // play splash SE
            //!!!
        }
    }

    void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.tag == "Rock"){
            float impulse = Mathf.Clamp(Vector2.Dot(collider.contacts[0].normal, collider.relativeVelocity) * rb.mass, 0, 1);

            // Deal damage relative to impulse of collision, rock size, and multiplier
            float healthLoss = impulse * collider.transform.localScale.x * Constants.rockDmgMultiplier;
            GlobalValues.IncrementHealth(-healthLoss);

            // Leak rate increments relative to impulse of collision
            float leakage = impulse * collider.transform.localScale.x * Constants.rockLeakMultiplier;
            leakage = (GlobalValues.sailHeight + .25f) * leakage;
            GlobalValues.IncrementLeakRate(leakage);
            GlobalValues.deck.SetFloodAmount(leakage * 100);

            // screen shake
            //!!!
            // crash SE
            //!!!
        }
    }
}
