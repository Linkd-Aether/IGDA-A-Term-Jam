using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float waveSpeed = Constants.waveSpd;

    void Update()
    {
        if (Utils.DownwardMovement(this.gameObject, Constants.waveSpd)) Destroy(this.gameObject);
    }
}
