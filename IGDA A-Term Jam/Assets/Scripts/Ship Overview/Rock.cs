using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Rock : MonoBehaviour
{
    /*  Multiple types of rocks with different sprites/behavior
            false - Rock1 - single small rock - sprites from the small folder
            true - Rock2 - single large rock - sprites from the large folder */
    public bool rockTypeLarge = false;
    private float scaleRange = .4f;
    private float rockSpeed = .8f;

    static Sprite[] smallSprite = new Sprite[4];
    static Sprite[] largeSprite = new Sprite[2];
    private SpriteRenderer sprRenderer;

    void Start()
    {
        smallSprite[0] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Small/tile_49");
        smallSprite[1] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Small/tile_51");
        smallSprite[2] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Small/tile_65");
        smallSprite[3] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Small/tile_67");
        largeSprite[0] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Small/tile_67");
        largeSprite[1] = Resources.Load<Sprite>("Sprites/Objects/Rocks/Small/tile_67");

        InitializeRock();
    }

    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.x += rockSpeed * Time.deltaTime;
        pos.y -= rockSpeed * Time.deltaTime;
        this.transform.position = pos;

        if (pos.y < Constants.LOWER_BOUND - 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void InitializeRock()
    {
        sprRenderer = GetComponentInChildren<SpriteRenderer>();
        Sprite[] spriteOptions = rockTypeLarge ? largeSprite : smallSprite;
        sprRenderer.sprite = spriteOptions[(Random.Range(0, spriteOptions.Length - 1))];

        Vector3 pos = this.transform.position;
        pos.x = Random.Range(Constants.LEFT_BOUND, Constants.RIGHT_BOUND) - 5;
        pos.y = Constants.UPPER_BOUND + 2;
        this.transform.position = pos;

        Vector3 scaleVector = this.transform.localScale;
        float scale = Random.Range(scaleVector.x, scaleVector.x + scaleRange);
        scaleVector.x = scale;
        scaleVector.y = scale;
        this.transform.localScale = scaleVector;

        float rotation = Random.Range(0f, 360f);
        this.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
