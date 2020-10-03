using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BailingWater : MonoBehaviour
{
    public Transform waterTransform;

    public GameObject bucket;
    private Animator bucketAnimator;

    private float bailAmount = -15f;
    private float waterIncreaseRate = 1f; // increase water by 1 point every second

    // Start is called before the first frame update
    void Start()
    {
        bucketAnimator = bucket.GetComponent<Animator>();
    }

    void Update()
    {
        GlobalValues.IncrementWaterLevel(waterIncreaseRate * Time.deltaTime);
        if (Input.GetAxis("Fire1") == 1 && bucketAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bucketAnimator.IsInTransition(0)) { //Checks Mouse click
            BailWater();
        }
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

}
