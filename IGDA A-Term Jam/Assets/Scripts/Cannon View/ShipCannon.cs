using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCannon : MonoBehaviour
{
    private static GameObject cannonball;
    public Transform spawnLocation; //this.transform.right is Cannon direction
    public int cannonNumber;

    void Start(){
        cannonball = Resources.Load<GameObject>("Prefabs/Cannon/CannonBall");
    }

    public void SpawnCannonBall(){
        GameObject spawned = Instantiate<GameObject>(cannonball, this.transform.position, Quaternion.Euler(Vector2.zero));
        spawned.GetComponent<CannonBall>().SetDirection(this.transform.right);
        Physics2D.IgnoreCollision(spawned.GetComponent<Collider2D>(), this.GetComponentInParent<CapsuleCollider2D>());
    }
}
