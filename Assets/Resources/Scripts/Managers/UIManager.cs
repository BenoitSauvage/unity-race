using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {


    #region Singleton
    private static UIManager instance;

    private UIManager() { }

    public static UIManager Instance {
        get {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }
    }
    #endregion


    public void Init() {

    }


    public void Update(float _dt) {


    }
    

}
