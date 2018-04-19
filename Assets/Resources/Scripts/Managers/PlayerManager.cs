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
    private Dictionary<int, bool> upsideDowns = new Dictionary<int, bool>();

    public void Init () {
        GameObject[] cars = GameObject.FindGameObjectsWithTag(GV.CAR_TAG);

        for (int i = 0; i < cars.Length; i++) {
            Car car = cars[i].GetComponent<Car>();
            car.InitCar(i);
            players.Add(i, car);
            upsideDowns.Add(i, false);
        }
    }

    public void Update (float _dt) {
        foreach (KeyValuePair<int, Car> kv in players)
            CheckPlayerUpsideDown(kv.Value);
    }

    public void FixedUpdate (float _fdt) {
        foreach (KeyValuePair<int, Car> kv in players)
            kv.Value.FixedUpdateCar(InputManager.Instance.GetInputInformation(kv.Key));
    }

    private void CheckPlayerUpsideDown(Car _player) {
         Vector3 angles = _player.transform.eulerAngles;

        if (angles.z >= GV.CAR_UPSIDEDOWN_RANGE.x && angles.z <= GV.CAR_UPSIDEDOWN_RANGE.y)
            _player.upsideDown = true;
        else
            _player.upsideDown = false;

        if (_player.GetUpsideDownTimerValue() >= GV.CAR_UPSIDEDOWN_TIME)
            ResetCarPosition(_player);
    }

    private void ResetCarPosition (Car _player) {
        Vector3 angles = _player.transform.eulerAngles;

        angles.z = 0;
        _player.upsideDown = false;
        _player.transform.eulerAngles = angles;

        _player.transform.position = GV.ws.spawnPoints[0].position;

        Debug.Log("Car position reset");
    }
}
