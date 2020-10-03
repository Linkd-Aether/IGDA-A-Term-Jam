using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float waveSpeed = 1.2f;

    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.x += waveSpeed * Time.deltaTime;
        pos.y -= waveSpeed * Time.deltaTime;
        this.transform.position = pos;

        if (pos.y < 2 * Constants.LOWER_BOUND)
        {
            Destroy(this.gameObject);
        }
    }
}
