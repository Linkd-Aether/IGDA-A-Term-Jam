using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CannonBall : MonoBehaviour
{
    private static float shotForce = 75f;
    private static float timeToDisappear = 2f;
    private static float damage = 12f;

    private Rigidbody2D rb;
    private float timeSinceShot;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * shotForce);
    }

    void Update()
    {
        timeSinceShot += Time.deltaTime;
        if (timeSinceShot >= timeToDisappear) {
            Destroy(this.gameObject);
            // !!! Splash Sound effect, cannonball drops into water without hitting anything
        }
    }

    public void SetDirection(Vector2 dir){
        this.direction = dir;
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "PlayerShip"){
            // player hit by a cannonball
            Debug.Log("Player hit!");
            GlobalValues.IncrementHealth(-damage);
            GlobalValues.IncrementLeakRate(damage / 10);
        } else if (collider.gameObject.tag == "EnemyShip"){
            // enemy ship hit by a cannonball
            Debug.Log("Enemy hit!");
            EnemyShip hitShip = collider.gameObject.GetComponent<EnemyShip>();
            hitShip.TakeDamage(4*damage);
        }
        // !!! Explosion Sound Effect + Animation Trigger
        Destroy(this.gameObject);
    }
}
