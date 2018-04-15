using System.Collections;
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
        return speed / GV._MAXSPEED * -225;
    }

}
