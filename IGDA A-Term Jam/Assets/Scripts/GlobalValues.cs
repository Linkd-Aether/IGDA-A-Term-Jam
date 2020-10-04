using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValues
{
    public static bool boatDestroyed = false;
    public static bool gameOver = false;

    public static PlayerShip ship = GameObject.FindGameObjectWithTag("PlayerShip").GetComponent<PlayerShip>();
    public static Sail sail = GameObject.FindGameObjectWithTag("Sail").GetComponent<Sail>();
    public static BailingWater deck = GameObject.FindGameObjectWithTag("Bucket").GetComponent<BailingWater>();
    public static ShipCannon currentCannon = ship.cannons[0];

    public static float health = 100f; // Health between 0 (dead) and 100 (no damage)
    public static float waterLevel = 50f; // Water between 0 (no water) and 100 (flooded)
    public static float sailHeight = 0f; // Sail height between 0 (fully lowered) and 1 (fully raised)
    public static float leakRate = 0f; // Rate at which water floods the below decks per second between 0 (no leak) and 10 (heavy leak)

    // Sets ship health and updates ship damage model (value 0 - 100 here 0 is worst condition and 100 is best)
    public static void SetHealth(int value) {
        health = Mathf.Clamp(value, 0, 100);
        ship.UpdateShipDamageModel(health);
    }

    // Increments ship health by given increment and updates ship damage model
    public static void IncrementHealth(float increment) {
        health = Mathf.Clamp(health += increment, 0, 100);
        ship.UpdateShipDamageModel(health);
    }

    // Sets the water level of ship
    public static void SetWaterLevel(float value) {
        waterLevel = Mathf.Clamp(value, 0f, 100f);
    }

    // Increments the water level of the ship
    public static void IncrementWaterLevel(float increment) {
        waterLevel = Mathf.Clamp(waterLevel += increment, 0,100);
        deck.UpdateWaterDisplay();
    }

    // Sets the ships sail height based on given value (range 0 - 1) where 0 is fully lowered and 1 is fully raised, updates sail displays
    public static void SetSailHeight(float value) {
        sailHeight = Mathf.Clamp(value, 0f, 1f);
        sail.UpdateSailDisplay();
        ship.UpdateShipSail();
    }

    // Increments the ships sail height based on given value, updates saild displays
    public static void IncrementSailHeight(float increment) {
        sailHeight += increment;
        sailHeight = Mathf.Clamp(sailHeight, 0, 1);
        sail.UpdateSailDisplay();
        ship.UpdateShipSail();
    }

    // Increments the ships sail height based on given value, updates saild displays
    public static void IncrementLeakRate(float increment) {
        leakRate += increment;
        leakRate = Mathf.Clamp(leakRate, 0, 10f);
    }

    // Sets the cannon number
    public static void SetActiveCannon(int cannonNumber){
        currentCannon = ship.cannons[cannonNumber];
    }
}
