using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public class SpriteVariants
    {
        public Sprite[] variants = new Sprite[4];

        public SpriteVariants(Sprite[] sprites)
        {
            variants = sprites;
        }
    }
    protected static SpriteVariants[] hullModelVariants; 
    protected static SpriteVariants[] sailModelVariants;
    protected SpriteVariants hullModels;
    protected SpriteVariants sailModels;

    public SpriteRenderer hullModel;
    public SpriteRenderer sailModel;

    public Rigidbody2D rb;

    protected float speed;
    protected float accelerationPower = 0.5f; // Ships acceleration ability (higher means more rapid acceleration)

    protected float oceanForceMultiplier = 0.4f; //accelerationPower is multiplied by this constant to give a continuous downward force 
                                                      //applied by the ocean's minor waves on the ship
    protected float waveForceMultiplier = 0.5f; //dictates force of larger waves pushing ship down

    // Start is called before the first frame update
    protected void Start()
    {
        hullModelVariants = LoadHullVariants();
        sailModelVariants = LoadSailVariants();
        hullModel = this.transform.Find("Hull").GetComponents<SpriteRenderer>()[0];
        sailModel = this.transform.Find("Sails").GetComponents<SpriteRenderer>()[0];
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update used for physics calculations as it is independent of frame rate
    protected void FixedUpdate() {
        rb.AddForce(new Vector2(0f, -accelerationPower*oceanForceMultiplier)); //Constant force applied by waves
    }

    // Updates ship model based on health and stored hull and sail models
    public void UpdateShipDamageModel(SpriteVariants hullModels, SpriteVariants sailModels, float health) {
        if (health >= 80) {
            hullModel.sprite = hullModels.variants[0];
            sailModel.sprite = sailModels.variants[1]; // undamaged
        } else if (health >= 60) {
            hullModel.sprite = hullModels.variants[0];
            sailModel.sprite = sailModels.variants[0]; // slightly damaged
        } else if (health >= 40) {
            hullModel.sprite = hullModels.variants[1];
            sailModel.sprite = sailModels.variants[0]; // slightly damaged
        } else if (health >= 20) {
            hullModel.sprite = hullModels.variants[1];
            sailModel.sprite = sailModels.variants[3]; // very damaged
        } else if (health >= 0) {
            hullModel.sprite = hullModels.variants[2];
            sailModel.sprite = sailModels.variants[3]; // very damaged
        } else {
            hullModel.sprite = hullModels.variants[3];
            sailModel.sprite = sailModels.variants[2]; // destroyed
        }
    }

    void OnTriggerStay2D(Collider2D collider){
        if (collider.gameObject.tag == "Wave")
        {
            // Hit a large wave, apply a large force downward
            rb.AddRelativeForce(Vector2.down * waveForceMultiplier);
        }
    }

    private static SpriteVariants[] LoadHullVariants(){
        hullModelVariants = new SpriteVariants[2];
        Sprite[] largeSprites = new Sprite[4];
        Sprite[] smallSprites = new Sprite[4];

        for(int spriteNumber = 0; spriteNumber < 4; spriteNumber++){
            largeSprites[spriteNumber] = Resources.Load<Sprite>
                ("Sprites/Objects/Ship Parts/Hulls/hullLarge ()".Insert(44, (spriteNumber + 1).ToString()));
            smallSprites[spriteNumber] = Resources.Load<Sprite>
                ("Sprites/Objects/Ship Parts/Hulls/hullSmall ()".Insert(44, (spriteNumber + 1).ToString()));
        }

        hullModelVariants[0] = new SpriteVariants(largeSprites);
        hullModelVariants[1] = new SpriteVariants(smallSprites);

        return hullModelVariants;
    }

    private static SpriteVariants[] LoadSailVariants(){
        sailModelVariants = new SpriteVariants[6];

        for(int variantNumber = 0; variantNumber < sailModelVariants.Length; variantNumber++){
            Sprite[] sprites = new Sprite[4];

            for(int spriteNumber = 0; spriteNumber < sprites.Length; spriteNumber++){
                sprites[spriteNumber] = Resources.Load<Sprite>
                    ("Sprites/Objects/Ship Parts/Sails/sailLarge ()"
                    .Insert(44, (6*spriteNumber + variantNumber + 1).ToString()));
            }
            sailModelVariants[variantNumber] = new SpriteVariants(sprites);
        }
        return sailModelVariants;
    }
}
