﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonView : MonoBehaviour
{
    private static KeyCode[] switchKeys = new KeyCode[4] {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4};
    public GameObject cannonSwitchUI;
    private ShipCannon[] cannonsUI;
    private int activeCannon; 
    private Color greyOut = new Color(128/255f,128/255f,128/255f,1); 
    private Color highlight = new Color(1,1,100/255f,1);

    public SpriteRenderer cannonSprite;
    public SpriteRenderer ballSprite;

    private static Sprite[] cannonSprites;
    private bool cannonReady;
    private bool cannonLit;
    private bool QTESatisfied;
    private int animInt;

    public ParticleSystem successParticle;
    public ParticleSystem failParticle;

    public GameObject ballButton;
    public GameObject lightButton;
    public GameObject fireButton;

    // Start is called before the first frame update
    void Start()
    {
        ballButton.SetActive(true);
        lightButton.SetActive(false);
        fireButton.SetActive(false);

        cannonLit = false;
        QTESatisfied = false;

        cannonSprites = new Sprite[9]
        {
            Resources.Load<Sprite>("Sprites/Objects/Cannon/cannon"), // Base cannon sprite
            Resources.Load<Sprite>("Sprites/Objects/Cannon/cannonfire1"), // Cannon firing sprite 1
            Resources.Load<Sprite>("Sprites/Objects/Cannon/cannonfire2"), // Cannon firing sprite 2
            Resources.Load<Sprite>("Sprites/Objects/Cannon/cannonfire3"), // Cannon firing sprite 3
            Resources.Load<Sprite>("Sprites/Objects/Cannon/cannonfire4"), // Cannon firing sprite 4
            Resources.Load<Sprite>("Sprites/Objects/Cannon/cannonfire5"), // Cannon firing sprite 5
            Resources.Load<Sprite>("Sprites/Objects/Cannon/cannonexplo1"), // Cannon explosion sprite 1
            Resources.Load<Sprite>("Sprites/Objects/Cannon/cannonexplo2"), // Cannon explosion sprite 2
            Resources.Load<Sprite>("Sprites/Objects/Cannon/cannonblank") // Cannon failed explosion
        };

        cannonsUI = cannonSwitchUI.GetComponentsInChildren<ShipCannon>();
        Recolor(cannonsUI[0].GetComponent<SpriteRenderer>(), highlight);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < switchKeys.Length; i++){
            if (Input.GetKeyDown(switchKeys[i])) CannonSwitch(i);
        }

        if (!cannonReady && Input.GetKeyDown(KeyCode.Z)) {
            cannonReady = true;
            ballButton.SetActive(false);
            lightButton.SetActive(true);
        }

        if (cannonReady) {

            ballSprite.color = new Color(255, 255, 255, 0);

            if (!cannonLit && Input.GetKeyDown(KeyCode.X)) {
                cannonLit = true;
                lightButton.SetActive(false);
            }
            if (cannonLit)
            {
                animInt++;
                if (animInt < 24)
                {
                    cannonSprite.sprite = cannonSprites[1];
                }
                else if (animInt < 48)
                {
                    cannonSprite.sprite = cannonSprites[2];
                }
                else if (animInt < 72)
                {
                    cannonSprite.sprite = cannonSprites[3];
                }
                else if (animInt < 96)
                {
                    fireButton.SetActive(true);
                    cannonSprite.sprite = cannonSprites[4];
                    if (Input.GetKeyDown(KeyCode.C)) QTESatisfied = true;
                }
                else if (animInt < 120)
                {
                    cannonSprite.sprite = cannonSprites[5];

                    fireButton.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        QTESatisfied = true;
                    }
                }
                else if (animInt == 120 && QTESatisfied)
                {
                    fireBall();
                    successParticle.Play();
                }
                else if (animInt == 120)
                {
                    fireButton.SetActive(false);
                    if (QTESatisfied)
                    {
                        fireBall();
                        successParticle.Play();
                    }
                    else { 
                        failParticle.Play();
                        cannonSprite.sprite = cannonSprites[8];
                    }
                }
                else if (animInt < 144 && QTESatisfied)
                {
                    cannonSprite.sprite = cannonSprites[6];
                }
                else if (animInt < 168 && QTESatisfied)
                {
                    cannonSprite.sprite = cannonSprites[7];
                }
                else if (animInt < 168)
                {
                    fireButton.SetActive(false);
                }
                else {
                    animInt = 0;
                    cannonSprite.sprite = cannonSprites[0];
                    cannonReady = false;
                    QTESatisfied = false;
                    cannonLit = false;
                    fireButton.SetActive(false);
                    ballButton.SetActive(true);
                }

            }
        }
        else
        {
            ballSprite.color = new Color(255, 255, 255, 255);
        }
    }

    private void CannonSwitch(int cannonNumber){
        if (cannonNumber != activeCannon){
            Recolor(cannonsUI[activeCannon].GetComponent<SpriteRenderer>(), greyOut);
            Recolor(cannonsUI[cannonNumber].GetComponent<SpriteRenderer>(), highlight);

            activeCannon = cannonNumber;
            GlobalValues.SetActiveCannon(cannonNumber);
        }
    }

    void fireBall()
    {
        GlobalValues.currentCannon.SpawnCannonBall();
    }

    private void Recolor(SpriteRenderer sprite, Color color){
        sprite.color = color;
    }
}