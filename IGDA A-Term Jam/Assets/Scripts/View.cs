using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    protected float input = 0f;
    protected bool[] numberedValues = new bool[4]{false,false,false,false};
    protected bool boolInput = false;

    public void HandleValue(float argument){
        input = argument;
    }
    public void HandleNumberedValue(float argument){
        if (argument == 0) numberedValues = new bool[4]{false, false, false, false};
        else numberedValues[(int)argument-1] = true;
    }
    public void HandleValue(bool argument){
        boolInput = argument;
    }
}
