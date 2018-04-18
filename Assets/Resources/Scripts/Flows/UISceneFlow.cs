using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneFlow : Flow {

    /*
     * Managers have to be called in this order :
     * - PlayerManager
     * - InputManager
     */

    public override void InitializeFlow() {
        PlayerManager.Instance.Init();
        // InputManager.Instance.Init(); // -> Does nothing for now
    }

    public override void UpdateFlow (float _dt) {
        PlayerManager.Instance.Update(_dt);
        // InputManager.Instance.Update(_dt); // -> Does nothing for now
    }

    public override void FixedUpdateFlow (float _fdt) {
        PlayerManager.Instance.FixedUpdate(_fdt);
        // InputManager.Instance.FixedUpdate(_fdt); // -> Does nothing for now
    }
}
