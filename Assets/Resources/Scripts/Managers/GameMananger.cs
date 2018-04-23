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
            Resources.Load<GameObject>("Prefabs/CarOriginal")
        );

        car.name = "CarOriginal" + _id;

        Transform car_body = GetCarBody(car);
        foreach (Transform parts in car_body)
            parts.GetComponent<MeshRenderer>().material = Resources.Load<Material>(
                "Materials/Materials/Player" + (_id + 1)
            );
            

        car.transform.position = _spawn.position;
        car.transform.eulerAngles = _spawn.eulerAngles;

        SetupCamera(_id, car.transform);
    }

    private Transform GetCarBody(GameObject _car) {
        return _car.transform.Find("SkyCar").Find("SkyCarBody");
    }

    private void SetupCamera(int _id, Transform _car) {
        Transform camera = GV.ws.cameras[_id];

        Vector3 cam_position = _car.position;
        cam_position.y += 5;
        cam_position.x += 10;

        camera.position = cam_position;
        camera.SetParent(_car);
        camera.LookAt(_car);
    }

}
