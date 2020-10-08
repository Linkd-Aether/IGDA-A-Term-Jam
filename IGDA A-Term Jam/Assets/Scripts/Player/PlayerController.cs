using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static PlayerManager manager;
    private static GameModule[] modules = PlayerManager.modules;

    private Crew crew;
    int moduleNumber = 0;
    // 0 = steering
    // 1 = cannon
    // 2 = sail
    // 3 = bucket

    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        // playerInput.user; user of this player instance
        print(playerInput.user.pairedDevices[0]);

        manager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        moduleNumber = RightAvailableModule(moduleNumber);
        modules[moduleNumber].playerControlled = true;
        crew = manager.AddPlayer(moduleNumber);
    }

    private int RightAvailableModule(int moduleNumber){
        int moduleCount = modules.Length;
        for(int i = 0; i < moduleCount; i++){
            int index = i + moduleNumber;
            if (index >= moduleCount) index -= moduleCount;
            if (!modules[index].playerControlled) return index;
        }
        return moduleNumber; // no open modules
    }

    private int LeftAvailableModule(int moduleNumber){
        int moduleCount = modules.Length;
        for(int i = moduleCount; i > 0; i--){
            int index = i + moduleNumber;
            if (index >= moduleCount) index -= moduleCount;
            if (!modules[index].playerControlled) return index;
        }
        return moduleNumber; // no open modules
    }

    // Left Joystick or WASD (2 Vector)
    private void OnMoveL(InputValue value){
        if (modules[moduleNumber].inputs.Contains("MoveL")){
            float val = -value.Get<Vector2>().x;
            // pass float input to steering script
            modules[moduleNumber].script.HandleValue(val);
        }
    }

    // Right Joystick or Arrow Keys (2 Vector)
    private void OnMoveR(InputValue value){
        if (modules[moduleNumber].inputs.Contains("MoveR")){
            float val = value.Get<Vector2>().y;
            // pass float value to sail script
            modules[moduleNumber].script.HandleValue(val);
        }
    }
    
    // Bumpers (1 Vector) or Q & E (1 Vector)
    private void OnShifting(InputValue value){
        int val = (int) Mathf.Sign(value.Get<float>());
        int newModule = moduleNumber;
        if (val == -1) newModule = LeftAvailableModule(moduleNumber);
        else if (val == 1) newModule = RightAvailableModule(moduleNumber);

        if (moduleNumber != newModule) {
            modules[moduleNumber].playerControlled = false;
            modules[moduleNumber].script.HandleNumberedValue(0);
            modules[moduleNumber].script.HandleValue(false);
            modules[moduleNumber].script.HandleValue(0);
            modules[newModule].playerControlled = true;
            moduleNumber = newModule;
            crew.SetPosition(moduleNumber);
        }

    }
    
    // Left Trigger or Click
    private void OnButtonL(InputValue value){
        if (modules[moduleNumber].inputs.Contains("ButtonL")){
            // pass click value to bucket script
            modules[moduleNumber].script.HandleValue(true);
        }
    }

    // East Button or Z
    private void OnButton1(InputValue value){
        if (modules[moduleNumber].inputs.Contains("Button1")){
            modules[moduleNumber].script.HandleNumberedValue(1);
        }
    }

    
    // South Button or X
    private void OnButton2(InputValue value){
        if (modules[moduleNumber].inputs.Contains("Button2")){
            modules[moduleNumber].script.HandleNumberedValue(2);
        }
    }

    
    // West Button or C
    private void OnButton3(InputValue value){
        if (modules[moduleNumber].inputs.Contains("Button3")){
            modules[moduleNumber].script.HandleNumberedValue(3);
        }
    }


    // D-Pad Buttons or Tab
    private void OnSelection(InputValue value){
        if (modules[moduleNumber].inputs.Contains("Selection")){
            modules[moduleNumber].script.HandleNumberedValue(4);
        }
    }
}
