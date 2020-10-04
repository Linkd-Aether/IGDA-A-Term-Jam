using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{   
    private Vector2 steeringPoint;

    private bool openShot = false;
    private float timeLoading = 0f;
    private bool cannonLoaded = true;
    private static float maxLoadTime = 10f;

    private float health = 100f; // 100f to 0f
    private float rotationSpeed = .7f;
    private float approachRange = 4f; // Range within player ship enemy has to be before attempting to line up a shot
    private float fireRange = 2.5f; // Range within player enemy ship when the enemy will attempt to shoot

    new void Start()
    {
        base.Start();

        GenerateShipFeatures();
        UpdateShipDamageModel(health);
        if (Constants.randomSetLocation) SetLocation();

        speed = accelerationPower * .65f;
        InvokeRepeating("ChartCourse", 0f, 1f);
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        rb.AddRelativeForce(Vector2.down * speed);

        SteerToward(steeringPoint);
        CheckFireConditions();
        if (this.transform.position.y < Constants.DESPAWN_ZONE) Destroy(this);
    }

    public void TakeDamage(float damage){
        health -= damage;
        health = Mathf.Clamp(health, 0, 100);
        UpdateShipDamageModel(health);
    }

    // Updates ship model based on health and stored hull and sail models
    public void UpdateShipDamageModel(float health) {
        base.UpdateShipDamageModel(hullModels, sailModels, health);
    }

    // Called on ship death animation complete
    new public void ShipDeath(){
        Destroy(this.gameObject);
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
        pos.x = Random.Range(-3f, 3f);
        pos.y = 8;
        ClearSpace(pos);
        this.transform.position = pos;
    }

    // Clear all rock obstacles from enemy ship spawn
    private void ClearSpace(Vector2 spawnPos)
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(spawnPos, 1.5f);
        foreach(Collider2D collider in collisions)
        {
            if (collider.gameObject.tag == "Rock") Destroy(collider.gameObject);
        }
    }

    private void ChartCourse()
    {
        // Look ahead to see if the course to the player is clear
        Vector2 playerPos = GlobalValues.ship.transform.position;
        RaycastHit2D hit = Physics2D.Linecast(this.transform.position, playerPos, 9);

        if (hit.collider != null)
        {
            Vector2 colliderPos = hit.collider.transform.position;
            Vector2 colliderDir = (colliderPos - (Vector2) this.transform.position).normalized;
            if (hit.collider.gameObject.tag == "Rock")
            {
                // looks unit left in either direction normal to the direction between enemy ship and rock
                steeringPoint = NormalPoints(colliderPos, colliderDir, .2f);
                openShot = false;
                return;
            }
            else if (hit.collider.gameObject.tag == "PlayerShip" && hit.distance < approachRange)
            {
                steeringPoint = NormalPoints(colliderPos, colliderDir, fireRange);
                openShot = true;
                return;
            }
        } 
        openShot = false;
        steeringPoint = playerPos;
    }

    private void SteerToward(Vector2 point)
    {
        float angle = GenerateAngle(this.transform.position, point);
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.SetRotation(Quaternion.Slerp(transform.rotation, q, Time.fixedDeltaTime * rotationSpeed));
    }

    private Vector2 NormalPoints(Vector2 point, Vector2 dir, float firstCheck){
        float unitCheck = firstCheck;
        do {
            Vector2 point1 = new Vector2(point.x - unitCheck * dir.y, point.y + unitCheck * dir.x);
            Vector2 point2 = new Vector2(point.x + unitCheck * dir.y, point.y - unitCheck * dir.x);
            Vector2[] points = ((point-point1).magnitude < (point-point2).magnitude) ? new Vector2[] {point1, point2} :  new Vector2[] {point2, point1};

            if (IsOpen(points[0])){
                return points[0];
            }
            else if (IsOpen(points[1])){
                return points[1];
            }
            else unitCheck += .2f;
        } while (true);
    }

    private bool IsOpen(Vector2 point){
        Collider2D collider = Physics2D.OverlapCircle(point, .3f, 9);
        return (collider == null); 
    }

    private float GenerateAngle(Vector2 origin, Vector2 newPoint)
    {
        Vector2 vectorToPoint = newPoint - origin;
        return Mathf.Atan2(vectorToPoint.y, vectorToPoint.x) * Mathf.Rad2Deg + 90;
    }

    private void CheckFireConditions()
    {
        if (openShot && cannonLoaded) cannonLoaded = !ShotCannon();
        timeLoading += Time.fixedDeltaTime;
        if (timeLoading >= maxLoadTime){
            timeLoading = 0;
            cannonLoaded = true;
        }
    }

    // return bool true if any of the ship's cannons line up with player and can hit
    private bool ShotCannon(){
        foreach(ShipCannon cannon in cannons){
            RaycastHit2D hit = Physics2D.Raycast(cannon.spawnLocation.position, cannon.transform.right);
            if (hit != false){
                if (hit.collider.gameObject.tag == "PlayerShip"){
                    cannon.SpawnCannonBall();
                    return true;
                }
            }
        }
        return false;
    }
}
