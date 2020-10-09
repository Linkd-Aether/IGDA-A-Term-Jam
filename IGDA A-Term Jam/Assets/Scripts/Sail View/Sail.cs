using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Sail : View
{
    [SerializeField] public float sailHeightIncrement = 0.01f;
    public SpriteRenderer sailSprite;
    public Transform sailTransform;
    public AudioSource sound;

    private int soundTimer;
    private bool stopSound;

    private void Update() {
        if (input != 0){
            GlobalValues.IncrementSailHeight(input * sailHeightIncrement);
        }

        if (soundTimer == 0 && Mathf.Abs(input) > .75)
        {
            soundTimer++;
            sound.time = .12f;
            sound.Play();
        }

        if (soundTimer > 0) soundTimer++;
        if (soundTimer >= 60) soundTimer = 0;

    }

    public void UpdateSailDisplay() {
        sailTransform.localScale = new Vector2(9f, 9*(1.1f - GlobalValues.sailHeight));
        sailSprite.sprite = GlobalValues.ship.GetCurrentSailSprite();
    }
}
