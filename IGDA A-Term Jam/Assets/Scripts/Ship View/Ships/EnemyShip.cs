using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{   
    private float health = 100f; // 100f to 0f

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        GenerateShipFeatures();
        UpdateShipDamageModel(health);
        //SetLocation();

        speed = accelerationPower;
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        rb.AddRelativeForce(transform.right * speed);
    }

    // Updates ship model based on health and stored hull and sail models
    public void UpdateShipDamageModel(float health) {
        base.UpdateShipDamageModel(hullModels, sailModels, health);
    }

    // Randomly select ship hull/sail
    private void GenerateShipFeatures()
    {
        hullModels = hullModelVariants[Random.Range(0,2)];
        
        int randomSail = Random.Range(0,5);
        if(randomSail == 1) randomSail = 5;
        sailModels = sailModelVariants[randomSail];
    }

    // Sets ship spawn position above upper edge of screen
    private void SetLocation()
    {
        Vector3 pos = this.transform.position;
        pos.x = Random.Range(-4, 4);
        pos.y = 7;
        this.transform.position = pos;
    }
}
