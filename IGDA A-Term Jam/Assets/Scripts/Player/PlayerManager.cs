using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModule
{
    public bool playerControlled;
    public List<string> inputs;
    public View script;

    public GameModule(List<string> actions, View scr){
        playerControlled = false;
        inputs = actions;
        script = scr;
    }
}

public class PlayerManager : MonoBehaviour
{
    public static GameModule[] modules = new GameModule[4];
    public static int numberPlayers = 0;

    public WheelSpin wheelView;
    public BailingWater belowDeckView;
    public Sail sailView;
    public CannonView cannonView;
    
    void Start()
    {
        modules[0] = new GameModule(new List<string> {"MoveL"}, wheelView); // 0 = steering
        modules[1] = new GameModule(new List<string> {"Selection", "Button1", "Button2", "Button3"}, cannonView); // 1 = cannon
        modules[2] = new GameModule(new List<string> {"MoveR"}, sailView); // 2 = sail
        modules[3] = new GameModule(new List<string> {"ClickL", "TriggerL"}, belowDeckView); // 3 = bucket
    }

    public int AddPlayer(){
        numberPlayers++;
        return numberPlayers;
    }
}
