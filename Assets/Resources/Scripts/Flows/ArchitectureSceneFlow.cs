using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS CLASS IS DESIGNED FOR TESTING
public class ArchitectureSceneFlow : Flow {

    /*
     * Managers have to be called in this order :
     * - PlayerManager
     * - CheckpointManager
     * - InputManager
     */

    public override void InitializeFlow() {
        // GENERIC INIT
        TimerManager.InGame = true;
        GameMananger.Instance.Init();

        // ORDERED FLOWS
        PlayerManager.Instance.Init();
        CheckpointManager.Instance.Init();
        // InputManager.Instance.Init(); // -> Does nothing for now
    }

    public override void UpdateFlow(float _dt) {
        // ORDERED FLOWS
        PlayerManager.Instance.Update(_dt);
        // InputManager.Instance.Update(_dt); // -> Does nothing for now
    }

    public override void FixedUpdateFlow(float _fdt) {
        // ORDERED FLOWS
        PlayerManager.Instance.FixedUpdate(_fdt);
        // InputManager.Instance.FixedUpdate(_fdt); // -> Does nothing for now
    }
}
