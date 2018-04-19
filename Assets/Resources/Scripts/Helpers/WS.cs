using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WS : MonoBehaviour {

    [Tooltip("Transform holding all checkpoints")]
    public Transform checkpoints;

    public void Awake() {
        GV.ws = this;
    }
}