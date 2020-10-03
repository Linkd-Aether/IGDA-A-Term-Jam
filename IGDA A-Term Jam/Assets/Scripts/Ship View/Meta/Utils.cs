using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    // DiagonalMovement moves a GameObject diagonally for one frame at the given speed
    // returns true if the position of the moved obj is below the specified DESPAWN_ZONE
    public static bool DiagonalMovement(GameObject obj, float speed)
    {
        Vector3 pos = obj.transform.position;
        pos.x += speed * Time.deltaTime;
        pos.y -= speed * Time.deltaTime;
        obj.transform.position = pos;

        return (pos.y < Constants.DESPAWN_ZONE);
    }
}
