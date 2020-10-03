using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BailingWater : MonoBehaviour
{
    private GameObject shipObject;
    private Ship ship;
    public Transform waterTransform;
    private float waterLevel = 0f;
    public GameObject bucket;
    private Animator bucketAnimator;
    private float bailAmount = -0.07f;
    private float waterIncreaseRate = 0.0002f;

    // Start is called before the first frame update
    void Start()
    {
        waterLevel = 0f;
        bucketAnimator = bucket.GetComponent<Animator>();
        shipObject = GameObject.FindGameObjectWithTag("PlayerShip");
        ship = shipObject.GetComponent<Ship>();
    }

    void FixedUpdate()
    {

        IncrementWaterLevel(waterIncreaseRate);
        if (Input.GetAxis("Fire1") == 1 && bucketAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bucketAnimator.IsInTransition(0)) { //Checks Mouse click
            BailWater();
        }
    }

    private void BailWater() {
        bucketAnimator.Play(0);
        IncrementWaterLevel(bailAmount);
    }

    private void IncrementWaterLevel(float increment) {
        waterLevel = Mathf.Clamp(waterLevel += increment, 0, 1);
        waterTransform.localScale = new Vector2(1f, waterLevel);
        ship.SetWaterLevel(waterLevel);
    }

}
