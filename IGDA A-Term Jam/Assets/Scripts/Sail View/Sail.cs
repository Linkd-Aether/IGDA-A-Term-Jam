using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Sail : MonoBehaviour
{
    private Ship ship;
    
    private float sailHeight = 0;
    [SerializeField] public float sailHeightIncrement = 0.01f;
    public SpriteRenderer sailSprite;
    public Transform sailTransform;

    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("PlayerShip").GetComponent<Ship>();
    }

    private void Update() {
        float input = Input.GetAxisRaw("Vertical");

        if (input != 0){
            IncrementSailHeight(input * sailHeightIncrement);
            ship.SetSailHeight(sailHeight);
        }
    }

    private void IncrementSailHeight(float increment) {
        sailHeight += increment;
        sailHeight = Mathf.Clamp(sailHeight, 0, 1);
        UpdateSailDisplay();
    }

    private void UpdateSailDisplay() {
        sailTransform.localScale = new Vector2(9f, 9*(1.1f - sailHeight));
        sailSprite.sprite = ship.GetCurrentSailSprite();
    }

    
}
