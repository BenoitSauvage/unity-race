using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsSceneFlow : Flow {

    public override void InitializeFlow() {
        TimerManager.InGame = true;
        SoundManager.Instance.Play();
        UIManager.Instance.Init();
    }

    public override void UpdateFlow(float _dt) {
        UIManager.Instance.Update(_dt);
    }

    public override void FixedUpdateFlow(float _fdt) {
        // @TODO
    }
}
