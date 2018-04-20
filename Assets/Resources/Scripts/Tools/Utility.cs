﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility {

    #region Singleton
    private static Utility instance;


   
    public static Utility Instance {
        get {
            if (instance == null) {
                instance = new Utility();
            }
            return instance;
        }
    }

    #endregion



    
    /// <summary>
    /// UI Tool
    /// </summary>
    /// <param name="speed"></param>
    /// <returns>
    /// Clamped value for Speed-o-meter
    /// 0 to -225 (theoric max speed) GV._MAXSPEED
    /// </returns>
    public float SpeedOMeterClamp(float speed) {
        float angle = speed / GV.MAX_CAR_SPEED * -200;

        if (angle < -240) {
            //Debug.Log("Error : Car speed max superior of Speed-o-meter  maximum");
            angle = Random.value < .5 ? -241 : -239;
        }
        else if (angle > 0) {
            //Debug.Log("Car speed is negativ... Be sure sure this is normal");
            angle *= -1;
        }

       // Debug.Log(angle);

        return angle;
    }

}