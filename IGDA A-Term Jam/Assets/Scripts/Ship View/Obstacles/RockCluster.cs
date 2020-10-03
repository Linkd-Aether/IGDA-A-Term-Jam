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
        if (Utils.DownwardMovement(this.gameObject, Constants.rockSpd)) Destroy(this.gameObject);
    }

    // Sets rock spawn position above upper edge of screen
    private void SetLocation()
    {
        Vector3 pos = this.transform.position;
        pos.x = Random.Range(-4, 4);
        pos.y = 7;
        this.transform.position = pos;
    }
}
