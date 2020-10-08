using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private static Sprite[] crewSprites = new Sprite[6];
    private static GameObject crewPrefab;

    public static GameModule[] modules = new GameModule[4];
    public WheelSpin wheelView;
    public BailingWater belowDeckView;
    public Sail sailView;
    public CannonView cannonView;

    public static int numberPlayers = 0;
    
    void Start()
    {
        for(int i = 1; i < 7; i++){
            crewSprites[i-1] = Resources.Load<Sprite>("Sprites/Objects/crew/crew ()".Insert(27, i.ToString()));
        }
        crewPrefab = Resources.Load<GameObject>("Prefabs/UI/Crew");

        modules[0] = new GameModule(new List<string> {"MoveL"}, wheelView); // 0 = steering
        modules[1] = new GameModule(new List<string> {"Selection", "Button1", "Button2", "Button3"}, cannonView); // 1 = cannon
        modules[2] = new GameModule(new List<string> {"MoveR"}, sailView); // 2 = sail
        modules[3] = new GameModule(new List<string> {"ButtonL"}, belowDeckView); // 3 = bucket
    }

    public Crew AddPlayer(int moduleNumber){
        Crew crew = Instantiate<GameObject>(crewPrefab).GetComponent<Crew>();
        crew.SetSprite(crewSprites[numberPlayers]);
        crew.SetPosition(moduleNumber);
        crew.SetColor(PlayerConstants.COLORS[numberPlayers]);
        numberPlayers++;
        return crew;
    }

    public void OnPlayerJoined(PlayerInput playerInput) { 

    }
}
