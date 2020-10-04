using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    public float playerNumber;

    public void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }

    public void SetPosition(int moduleNumber){
        Vector2 location = Vector2.zero;

        switch(moduleNumber){
            case 0:
                location = new Vector2(4, -16f);
                break;
            case 1:
                location = new Vector2(4, -18.5f);
                break;
            case 2:
                location = new Vector2(4, -22.5f);
                break;
            case 3:
                location = new Vector2(-4, -23.6f);
                break;
        }

        this.transform.position = location;
    }
}
