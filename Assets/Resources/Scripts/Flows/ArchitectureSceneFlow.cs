using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS CLASS IS DESIGNED FOR TESTING
public class ArchitectureSceneFlow : Flow {

    float timePassed = 0f;
    Chronos chrono;

    public override void InitializeFlow() {
        Debug.Log("ArchitectureSceneFlow Init");

        chrono = new Chronos();
        TimerManager.Instance.AddTimer(this, chrono);
    }

    public override void UpdateFlow(float _dt) {
        timePassed += _dt;

        if (timePassed >= 2f) {
            timePassed = 0;
            Debug.Log("Passed time : " + chrono.Value);
        }
    }

    public override void FixedUpdateFlow(float _dt) {
        // @TODO
    }
}
