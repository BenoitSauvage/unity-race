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

    private Dictionary<int, CarUserControl> players = new Dictionary<int, CarUserControl>();

    public void Init () {
        GameObject[] cars = GameObject.FindGameObjectsWithTag(GV.CAR_TAG);

        for (int i = 0; i < cars.Length; i++) {
            CarUserControl car = cars[i].GetComponent<CarUserControl>();
            car.InitCar(i);
            players.Add(i, car);
        }
    }

    public Dictionary<int, CarUserControl> GetPlayers() {
        return players;
    }

    public void Update (float _dt) {
        foreach (KeyValuePair<int, CarUserControl> kv in players)
            CheckPlayerStuck(kv.Value);
    }

    public void FixedUpdate (float _fdt) {
        foreach (KeyValuePair<int, CarUserControl> kv in players)
            kv.Value.FixedUpdateCar(InputManager.Instance.GetInputInformation(kv.Key));
    }

    public float GetPlayerSpeed(int _id) {
        return 0;
        // return players[_id].GetSpeed();
    }

    private void CheckPlayerStuck(CarUserControl _player) {
         Vector3 angles = _player.transform.eulerAngles;

        _player.upsideDown = (angles.z >= GV.CAR_UPSIDEDOWN_RANGE.x && angles.z <= GV.CAR_UPSIDEDOWN_RANGE.y);

        if (_player.GetUpsideDownTimerValue() >= GV.CAR_UPSIDEDOWN_TIME || _player.transform.position.y <= GV.CAR_FALL_LIMIT)
            ResetCarPosition(_player);
    }

    private void ResetCarPosition (CarUserControl _player) {
        _player.upsideDown = false;

        Checkpoint last_checkpoint = CheckpointManager.Instance.GetLastCheckpoint(_player.IDCar);
        Vector3 checkpoint_position = last_checkpoint.transform.position;

        // TO PREVENT GLITCHING IN THE ROAD
        checkpoint_position.y += 2;

        _player.transform.eulerAngles = last_checkpoint.transform.eulerAngles;
        _player.transform.position = checkpoint_position;
        _player.ResetVelocity();

        Debug.Log("Car position reset");
    }
}
