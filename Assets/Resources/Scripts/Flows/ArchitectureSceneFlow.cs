using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS CLASS IS DESIGNED FOR TESTING
public class ArchitectureSceneFlow : Flow {

    /*
     * Managers have to be called in this order :
     * - TimerManager
     * - PlayerManager
     * - InputManager
     */

    public override void InitializeFlow() {
        TimerManager.InGame = true;
        PlayerManager.Instance.Init();
        // InputManager.Instance.Init(); // -> Does nothing for now
    }

    public override void UpdateFlow(float _dt) {
        PlayerManager.Instance.Update(_dt);
        // InputManager.Instance.Update(_dt); // -> Does nothing for now
    }

    public override void FixedUpdateFlow(float _fdt) {
        PlayerManager.Instance.FixedUpdate(_fdt);
        // InputManager.Instance.FixedUpdate(_fdt); // -> Does nothing for now
    }
}
