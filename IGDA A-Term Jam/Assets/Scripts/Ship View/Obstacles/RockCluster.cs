using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCluster : MonoBehaviour
{
    private float rockSpeed = Constants.rockSpd;

    void Start()
    {
        SetLocation();
    }

    void Update()
    {
        if (Utils.DiagonalMovement(this.gameObject, Constants.rockSpd)) Destroy(this.gameObject);
    }

    // Sets rock spawn position along y = x + 10 line (lines up with movement to cross screen)
    private void SetLocation()
    {
        Vector3 pos = this.transform.position;
        pos.x = Random.Range(-8, 0);
        pos.y = pos.x + 10;
        this.transform.position = pos;
    }
}
