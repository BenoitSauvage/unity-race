using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV : MonoBehaviour {

    public static WS ws;

    // GLOBAL VARIABLES
    public enum SCENENAMES { DUMMY, UIScene, MainEntryScene, MainMenu, MainScene, ArchitectureScene, ToolsScene }

    // CAR INFORMATION (player)
    public static readonly string CAR_TAG = "Car";
    public static readonly float CAR_MASS = 500;
    public static readonly float MAX_AMOUNT_NITRO = 10;
    public static readonly float MAX_CAR_SPEED = 10;

    // HELPERS
    public static readonly Vector2 CAR_UPSIDEDOWN_RANGE = new Vector2(90, 270);
    public static readonly float CAR_UPSIDEDOWN_TIME = 3f;
    public static readonly float CAR_FALL_LIMIT = 40f;
    // POWER UP
    public static readonly float POWERUP_ROTATE_SEED = 2.5f; 

}
