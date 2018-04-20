using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager {

    #region Singleton
    private static PowerUpManager instance;



    public static PowerUpManager Instance {
        get {
            if (instance == null) {
                instance = new PowerUpManager();
            }
            return instance;
        }
    }

    #endregion

    GameObject[] powerUps;

    // Use this for initialization
    void Init () {
        powerUps = GameObject.FindGameObjectsWithTag("PowerUP");
	}


    public void PowerUpTouched(int powerUpId, int carId) {


    }

    private GameObject PowerUpById(int powerUp) {
        GameObject toReturn = null;
        PowerUp script;
        foreach ( GameObject pu in powerUps ) {
            script = pu.GetComponent<PowerUp>();
            if (script.Id == powerUp) {
                toReturn = pu;
            }
        }

        if (toReturn == null) Debug.Log("ERROR : PowerUp don't find in manager");

        return toReturn;
    }



}
