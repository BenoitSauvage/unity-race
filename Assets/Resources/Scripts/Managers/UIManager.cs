using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    RectTransform speedOMeterP1;
    RectTransform speedOMeterP2;

    Text positionP1; 
    Text positionP2;
    Text timer;

    Chronos chronos;
    CarController player1;
    CarController player2;

    public void Init() {
        speedOMeterP1 = GameObject.Find("SpeedometerP1").GetComponent<RectTransform>();
        speedOMeterP2 = GameObject.Find("SpeedometerP2").GetComponent<RectTransform>();
        positionP1 = GameObject.Find("Position1").GetComponent<Text>();
        positionP2 = GameObject.Find("Position2").GetComponent<Text>();
        timer = GameObject.Find("Timer").GetComponent<Text>();

        player1 = GameObject.Find("CarOriginal0").GetComponent<CarController>(); 
        player2 = GameObject.Find("CarOriginal1").GetComponent<CarController>();

        chronos = TimerManager.Instance.CreateSimpleChronos(this, TimerManager.Timebook.InGame);


    }


    public void Update(float _dt) {
        timer.text = chronos.ToString();

       

        speedOMeterP1.localEulerAngles = new Vector3(0,0, Utility.Instance.SpeedOMeterClamp(player1.CurrentSpeed));
        speedOMeterP2.localEulerAngles = new Vector3(0,0, Utility.Instance.SpeedOMeterClamp(player2.CurrentSpeed));


    }

}
