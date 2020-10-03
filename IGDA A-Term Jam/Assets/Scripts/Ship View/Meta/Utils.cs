using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    // DownwardMovement moves a GameObject Down for one frame at the given speed
    // returns true if the position of the moved obj is below the specified DESPAWN_ZONE
    public static bool DownwardMovement(GameObject obj, float speed)
    {
        Vector3 pos = obj.transform.position;
        pos.y -= speed * Time.deltaTime;
        obj.transform.position = pos;

        return (pos.y < Constants.DESPAWN_ZONE);
    }
}
