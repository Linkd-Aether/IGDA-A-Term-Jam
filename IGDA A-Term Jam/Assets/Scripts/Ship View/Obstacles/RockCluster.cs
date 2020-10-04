using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCluster : MonoBehaviour
{
    private float rockSpeed = Constants.rockSpd;
    public float checkRadius;

    void Start()
    {
        if (Constants.randomSetLocation) SetLocation();
    }

    void Update()
    {
        if (Utils.DownwardMovement(this.gameObject, Constants.rockSpd)) Destroy(this.gameObject);
    }

    // Sets rock spawn position above upper edge of screen
    private void SetLocation()
    {
        Vector3 pos = this.transform.position;
        pos.x = Random.Range(-4f, 4f);
        pos.y = 8;
        this.transform.position = pos;
        if (CheckSpace(pos) == false) Destroy(this.gameObject);
    }

    private bool CheckSpace(Vector2 spawnPos){
        Collider2D[] collisions = Physics2D.OverlapCircleAll(spawnPos, checkRadius*this.transform.localScale.x);
        return (collisions.Length == 0);
    }
}
