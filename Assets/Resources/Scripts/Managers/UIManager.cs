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

    //Dictionary<int, List<Object>> = // ID AND PLAYER_OBJECT

    //_______________player_1
    CarController player1;
    RectTransform speedOMeterP1;
    Text speedP1;
    Text positionP1;
    Text countP1;
    Image engine1;
    Camera minimap1;

    //_______________player_2
    CarController player2;
    RectTransform speedOMeterP2;
    Text speedP2;
    Text positionP2;
    Text countP2;
    Image engine2;
    Camera minimap2;

    //______________
    Text timer;
    Chronos _chronoGame;
    Chronos _chronoStart;

    public void Init() {

        Debug.Log("UIManager Init");

        //_______________player_1
        player1 = GameObject.Find("CarOriginal0").GetComponent<CarController>();
        speedOMeterP1 = GameObject.Find("SpeedometerP1").GetComponent<RectTransform>();
        speedP1 = GameObject.Find("SpeedCounterP1").GetComponent<Text>();
        positionP1 = GameObject.Find("Position1").GetComponent<Text>();
        countP1 = GameObject.Find("Count1").GetComponent<Text>();
        engine1 = GameObject.Find("Engine1").GetComponent<Image>();
        minimap1 = GameObject.Find("MiniMapCamera1").GetComponent<Camera>();
        //_______________player_2
        player2 = GameObject.Find("CarOriginal1").GetComponent<CarController>();
        speedOMeterP2 = GameObject.Find("SpeedometerP2").GetComponent<RectTransform>();
        speedP2 = GameObject.Find("SpeedCounterP2").GetComponent<Text>();
        positionP2 = GameObject.Find("Position2").GetComponent<Text>();
        countP2 = GameObject.Find("Count2").GetComponent<Text>();
        engine2 = GameObject.Find("Engine2").GetComponent<Image>();
        minimap2 = GameObject.Find("MiniMapCamera2").GetComponent<Camera>();


        timer = GameObject.Find("Timer").GetComponent<Text>();
        _chronoGame = TimerManager.Instance.CreateSimpleChronos(this, TimerManager.Timebook.InGame);
        _chronoStart = TimerManager.Instance.CreateSimpleChronos(this, TimerManager.Timebook.InGame);

    }


    public void Update(float _dt) {
        //init Player_1 
        CountdownRace(player1, countP1, engine1, _chronoGame, _chronoStart);
        initPlayerUI(speedOMeterP1, speedP1, minimap1, player1);

        //init Player_2 
        CountdownRace(player2, countP2, engine2, _chronoGame, _chronoStart);
        initPlayerUI(speedOMeterP2, speedP2, minimap2, player2);

    }


    void initPlayerUI(RectTransform speedOMeter, Text speed, Camera minimap, CarController player) {
        speedOMeter.localEulerAngles = new Vector3(0, 0, Utility.Instance.SpeedOMeterClamp(player.CurrentSpeed));
        speed.text = (-Mathf.Round(Utility.Instance.SpeedOMeterClamp(player.CurrentSpeed))).ToString();
        minimap.transform.parent = player.transform;

    }


    void CountdownRace(CarController player, Text count, Image engine, Chronos _chronoGame, Chronos _chronoStart)
    {
        Rigidbody rb;
        rb = player.GetComponent<Rigidbody>();


        if (_chronoStart.Value < 0.9f)
        {

        }
        else if (_chronoStart.Value >= 0.9f && _chronoStart.Value < 2f)
        {
            rb.isKinematic = true;
            count.text = 3.ToString();
        }
        else if (_chronoStart.Value >= 2f && _chronoStart.Value < 3f)
        {
            count.text = 2.ToString();
        }
        else if (_chronoStart.Value >= 3f && _chronoStart.Value < 4f)
        {
            count.text = 1.ToString();
        }
        else if (_chronoStart.Value >= 4f && _chronoStart.Value < 5f)
        {
            //rb.isKinematic = true;
            count.text = "GO!!!";
            _chronoGame.Reset();
        }
        else {
            rb.isKinematic = false;
            count.text = " ";
            engine.color = new Color32(0, 255, 0, 255);
            _chronoStart.Kill();
            timer.text = _chronoGame.ToString();
        }
    }

    void EngineUI(CarController player, bool on_off) {
        if (on_off == true)
        {
            //.color = new Color32(0, 255, 0, 255);
        }
        else {
            //.color = new Color32(255, 0, 0, 255);
        }
    }
}
