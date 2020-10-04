using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTrack : MonoBehaviour
{
    public float goalTime;
    public SpriteRenderer map;

    private float currTime;
    private Sprite[] mapSprites;

    // Start is called before the first frame update
    void Start()
    {
        currTime = 0;

        mapSprites = new Sprite[18]
        {
            Resources.Load<Sprite>("Sprites/UI/Map/wtx0"), // Base map sprite
            Resources.Load<Sprite>("Sprites/UI/Map/wtx1"), // Incremental progress in map
            Resources.Load<Sprite>("Sprites/UI/Map/wtx2"), //  |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx3"), //  |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx4"), //  |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx5"), //  |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx6"), //  |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx7"), //  |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx8"), //  |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx9"), //  |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx10"), // |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx11"), // |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx12"), // |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx13"), // |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx14"), // |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx15"), // |
            Resources.Load<Sprite>("Sprites/UI/Map/wtx16"), //\ /
            Resources.Load<Sprite>("Sprites/UI/Map/wtx17") // Finished map sprites
        };
    }

    // Fixed update is called once per frame
    void Update()
    {
        currTime++;
        map.sprite = mapSprites[(int)Mathf.Clamp(Mathf.Floor(currTime / goalTime * 18), 0, 17)];
        if (currTime >= goalTime) End();
    }

    void End()
    {
        SceneManager.LoadScene("Win");
    }
}
