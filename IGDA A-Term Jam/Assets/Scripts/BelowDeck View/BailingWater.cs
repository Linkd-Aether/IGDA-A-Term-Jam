using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BailingWater : View
{
    public Transform waterTransform;

    //public GameObject bucket;
    private Animator bucketAnimator;

    private float bailAmount = 15f;
    private float floodAmount; // Amount of water to be progressively added after hitting a wave
    private float floodAmountPerSec = 10f; // Amount of floodAmount to be added each sec

    // Start is called before the first frame update
    void Start()
    {
        bucketAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float floodThisFrame = GlobalValues.leakRate * Time.deltaTime;
        if (floodAmount > 0)
        {
           floodThisFrame += PartialFlood();
        }

        GlobalValues.IncrementWaterLevel(floodThisFrame);

        if (boolInput && bucketAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 
            && !bucketAnimator.IsInTransition(0) && GlobalValues.waterLevel > 5f)
        {
            BailWater();
        } else {
            boolInput = false;
        }
    }

    private void BailWater() 
    {
        bucketAnimator.SetBool("Used", true);
        bucketAnimator.Play(0);
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

    private void LowerWater(){
        StartCoroutine("DecrementWaterLevel");
    }

    private IEnumerator DecrementWaterLevel(){
        float amountBailed = 0;
        while (bailAmount > amountBailed){
            Debug.Log("called");
            float bailThisCall = Mathf.Clamp(bailAmount * Time.deltaTime, 0, bailAmount - amountBailed);
            GlobalValues.IncrementWaterLevel(-bailThisCall);
            amountBailed +=  bailThisCall;
            yield return null;
        }
        yield return null;
    }
}