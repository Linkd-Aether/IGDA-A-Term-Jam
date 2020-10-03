using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Sail : MonoBehaviour
{
    private GameObject shipObject;
    private Ship ship;
    private float sailHeight = 0;
    [SerializeField] public float sailHeightIncrement = 0.01f;
    public SpriteRenderer sailSprite;
    public Transform sailTransform;

    // Start is called before the first frame update
    void Start()
    {
        shipObject = GameObject.FindGameObjectWithTag("PlayerShip");
        ship = shipObject.GetComponent<Ship>();
    }

    private void FixedUpdate() {
        IncrementSailHeight(Input.GetAxis("Vertical") * sailHeightIncrement);
        
        ship.SetSailHeight(sailHeight); //up down player input
    }

    private void SetSailHeight(float value) {
        sailHeight = value;
        UpdateSailDisplay();
    }

    private void IncrementSailHeight(float increment) {
        sailHeight += increment;
        sailHeight = Mathf.Clamp(sailHeight, 0, 1);
        Debug.Log(sailHeight);
        UpdateSailDisplay();
    }

    private void UpdateSailDisplay() {
        sailTransform.localScale = new Vector2(9f, 9*(1.1f - sailHeight));
        sailSprite.sprite = ship.GetCurrentSailSprite();
    }

    
}
