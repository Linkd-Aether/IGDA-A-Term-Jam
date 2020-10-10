using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    void OnButtonPress(){
        StartCoroutine("ResetGame");
    }

    IEnumerator ResetGame(){
        yield return new WaitForSeconds(.5f);
        GlobalValues.GameReset();
    }
}
