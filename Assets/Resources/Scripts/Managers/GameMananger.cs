using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMananger {

    #region singleton
    private static GameMananger instance;

    private GameMananger() { }

    public static GameMananger Instance {
        get {
            if (instance == null)
                instance = new GameMananger();

            return instance;
        }
    }
    #endregion singleton

    public void Init() {
        int playerNum = 0;

        foreach (Transform point in GV.ws.spawnPoints) {
            SpawnCar(playerNum, point);
            playerNum += 1;
        }
    }

    private void SpawnCar (int _id, Transform _spawn) {
        GameObject car = GameObject.Instantiate(
            Resources.Load<GameObject>("Prefabs/Car")
        );
        Transform car_body = GetCarBody(car);

        car_body.GetComponent<MeshRenderer>().material = Resources.Load<Material>(
            "Materials/Materials/Player" + (_id + 1)
        );

        car.transform.position = _spawn.localPosition;
        car.transform.eulerAngles = _spawn.eulerAngles;

        SetupCamera(car);
    }

    private Transform GetCarBody(GameObject _car) {
        return _car.transform.Find("Body");
    }

    private void SetupCamera(GameObject _car) {
        // @TODO Implement camera position
    }

}
