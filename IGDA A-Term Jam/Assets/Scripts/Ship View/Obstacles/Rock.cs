using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    /*  Multiple types of rocks with different sprites/behavior
            false - Rock1 - single small rock - sprites from the small folder
            true - Rock2 - single large rock - sprites from the large folder */
    public bool rockTypeLarge = false;
    private float scaleRange = .4f;

    static Sprite[] smallSprite = new Sprite[4];
    static Sprite[] largeSprite = new Sprite[2];
    private SpriteRenderer sprRenderer;

    void Start()
    {
        smallSprite[0] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Small/tile_49");
        smallSprite[1] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Small/tile_51");
        smallSprite[2] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Small/tile_65");
        smallSprite[3] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Small/tile_67");
        largeSprite[0] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Large/tile_50");
        largeSprite[1] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Large/tile_66");

        SetSprite();
        SetRotation();
        SetScale();
    }

    // Sets the rock sprite from all those of appropriate size
    private void SetSprite()
    {
        sprRenderer = GetComponentInChildren<SpriteRenderer>();
        Sprite[] spriteOptions = rockTypeLarge ? largeSprite : smallSprite;
        sprRenderer.sprite = spriteOptions[(Random.Range(0, spriteOptions.Length - 1))];
    }

    // Sets rock rotation to random angle from 0 to 360
    private void SetRotation()
    {
        float rotation = Random.Range(0f, 360f);
        this.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // Sets rock rotation to random increase within scaleRange
    private void SetScale()
    {
        Vector3 scaleVector = this.transform.localScale;
        float scale = Random.Range(scaleVector.x, scaleVector.x + scaleRange);
        scaleVector.x = scale;
        scaleVector.y = scale;
        this.transform.localScale = scaleVector;
    }
}
