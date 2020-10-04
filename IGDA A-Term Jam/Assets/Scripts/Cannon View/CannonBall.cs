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
            StartCoroutine(Disappear());
            // !!! Splash Sound effect, cannonball drops into water without hitting anything (maybe do it partly through cannonball hitting water)
        }
    }

    public void SetDirection(Vector2 dir){
        this.direction = dir;
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "PlayerShip"){
            // player hit by a cannonball
            GlobalValues.IncrementHealth(-damage);
            GlobalValues.IncrementLeakRate(damage / 10);
        } else if (collider.gameObject.tag == "EnemyShip"){
            // enemy ship hit by a cannonball
            EnemyShip hitShip = collider.gameObject.GetComponent<EnemyShip>();
            hitShip.TakeDamage(4*damage);
        }
        // !!! Explosion Sound Effect + Animation Trigger
        Destroy(this.gameObject);
    }

        // Called when ship health = 0
    public IEnumerator Disappear(){
        float elapsedTime = 0;
        float waitTime = .5f;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Color color = sprite.color; 
        
        while (elapsedTime < waitTime)
        {
            float lerp = Mathf.Lerp(1, 0, (elapsedTime / waitTime));
            color.a = lerp;
            sprite.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }  
        Destroy(this.gameObject);
        yield return null;
    }
}
