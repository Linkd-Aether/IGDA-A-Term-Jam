﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BailingWater : MonoBehaviour
{
    public Transform waterTransform;

    public GameObject bucket;
    private Animator bucketAnimator;

    private float bailAmount = -15f;
    private float floodAmount; // Amount of water to be progressively added after hitting a wave
    private float floodAmountPerSec = 10f; // Amount of floodAmount to be added each sec

    // Start is called before the first frame update
    void Start()
    {
        bucketAnimator = bucket.GetComponent<Animator>();
    }

    void Update()
    {
        float floodThisFrame = GlobalValues.leakRate * Time.deltaTime;
        if (floodAmount > 0)
        {
           floodThisFrame += PartialFlood();
        }

        GlobalValues.IncrementWaterLevel(floodThisFrame);
        if (Input.GetAxis("Fire1") == 1 && bucketAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 
            && !bucketAnimator.IsInTransition(0) && GlobalValues.waterLevel > 5f)
        {
            BailWater();
        }
        Debug.Log("floodAmount" + floodAmount);
        Debug.Log("WaterLevel" + GlobalValues.waterLevel);
    }

    private void BailWater() 
    {
        bucketAnimator.Play(0);
        GlobalValues.IncrementWaterLevel(bailAmount);
    }

    public void UpdateWaterDisplay()
    {
        waterTransform.localScale = new Vector2(1f, GlobalValues.waterLevel / 100);
    }

    public void SetFloodAmount(float value)
    {
        floodAmount = value;
    }

    public float PartialFlood()
    {
        float floodThisFrame = floodAmountPerSec * Time.deltaTime;
        floodAmount = Mathf.Clamp(floodAmount - floodThisFrame, 0, floodAmount);
        return floodThisFrame;
    }
}