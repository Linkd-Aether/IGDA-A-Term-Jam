using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameModule
{
    public int? player = null;
    public List<string> inputs;
    public View script;

    public GameModule(List<string> actions, View scr){
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

    private List<PlayerController> players = new List<PlayerController>();
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

    public void OnPlayerJoined(PlayerInput playerInput) { 
        PlayerController newPlayer = playerInput.gameObject.GetComponent<PlayerController>();
        newPlayer.playerNumber = numberPlayers;
        numberPlayers++;
        SetPlayerModule(newPlayer, NextOpenModule(0), true);
        AddCrew(newPlayer);
        players.Add(newPlayer);
    }

    // Changes the moduleNumber of the player and makes the corresponding changes to the modules variable
    static public void SetPlayerModule(PlayerController player, int moduleNumber, bool spawning = false){
        if (!spawning) modules[player.moduleNumber].player = null;
        modules[moduleNumber].player = player.playerNumber;
        player.moduleNumber = moduleNumber;
    }

    static public int NextOpenModule(int currentModuleNumber){
        int modulesLength = modules.Length;

        for(int i = 0; i < modulesLength; i++){
            int index = currentModuleNumber + i;
            if (index >= modulesLength) index -= modulesLength;
            if (modules[index].player == null) return index; 
        }
        return currentModuleNumber;
    }

    static public int LastOpenModule(int currentModuleNumber){
        int modulesLength = modules.Length;

        for(int i = modulesLength; i > 0; i--){
            int index = currentModuleNumber + i;
            if (index >= modulesLength) index -= modulesLength;
            if (modules[index].player == null) return index; 
        }
        return currentModuleNumber;
    }

    static private void AddCrew(PlayerController player){
        Crew crew = Instantiate<GameObject>(crewPrefab).GetComponent<Crew>();
        crew.SetSprite(crewSprites[player.playerNumber]);
        crew.SetColor(PlayerConstants.COLORS[player.playerNumber]);
        crew.SetPosition(player.moduleNumber);
        player.crew = crew;
    }
}
