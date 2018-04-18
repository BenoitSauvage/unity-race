using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WS : MonoBehaviour {

    public List<Transform> spawnPoints;

    public void Awake() {
        GV.ws = this;
    }
}