using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV : MonoBehaviour
{

    // GLOBAL VARIABLES
    public enum SCENENAMES { DUMMY, UIScene, MainEntryScene, MainMenu, MainScene, ArchitectureScene }
    public static float _MAXSPEED = 5f;

    // car information (player)
    public static readonly string CAR_TAG = "Car";
    public static readonly float MAX_AMOUNT_NITRO = 10;
    public static readonly float MAX_CAR_SPEED = 10;


}
