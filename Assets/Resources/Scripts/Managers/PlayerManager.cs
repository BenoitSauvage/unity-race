using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager {
    
    #region singleton
    private static PlayerManager instance;

    private PlayerManager() { }

    public static PlayerManager Instance {
        get {
            if (instance == null)
                instance = new PlayerManager();

            return instance;
        }
    }
    #endregion singleton

    private Dictionary<int, Car> players = new Dictionary<int, Car>();

    public void Init () {
        GameObject[] cars = GameObject.FindGameObjectsWithTag(GV.CAR_TAG);

        for (int i = 0; i < cars.Length; i++) {
            Car car = cars[i].GetComponent<Car>();
            car.InitCar(i);
            players.Add(i, car);
        }
    }

    public void Update (float _dt) {
        // @TODO
    }

    public void FixedUpdate (float _fdt) {
        foreach (KeyValuePair<int, Car> kv in players) {
            kv.Value.FixedUpdateCar(InputManager.Instance.GetInputInformation(kv.Key));
        }
    }
}
