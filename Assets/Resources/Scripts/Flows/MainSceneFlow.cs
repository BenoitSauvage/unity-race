using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneFlow : Flow {

    /*
     * Managers have to be called in this order :
     * - PlayerManager
     * - CheckpointManager
     * - InputManager
     * - UIManager
     */

    public override void InitializeFlow() {
        Debug.Log("InitializeFlow MainSceneFlow");
        // GENERIC INIT
        TimerManager.InGame = true;
        GameMananger.Instance.Init();
        // PowerUpManager.Instance.Init();
        UIManager.Instance.Init();

        // ORDERED FLOWS
        PlayerManager.Instance.Init();
        CheckpointManager.Instance.Init();
        // InputManager.Instance.Init(); // -> Does nothing for now
    }

    public override void UpdateFlow(float _dt) {
        // ORDERED FLOWS
        PlayerManager.Instance.Update(_dt);
        UIManager.Instance.Update(_dt);
    }

    public override void FixedUpdateFlow(float _fdt) {
        // ORDERED FLOWS
        PlayerManager.Instance.FixedUpdate(_fdt);
        // InputManager.Instance.FixedUpdate(_fdt); // -> Does nothing for now
    }
}
