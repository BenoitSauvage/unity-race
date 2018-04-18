using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsSceneFlow : Flow {

    public override void InitializeFlow() {
        Debug.Log("Init flow called");

        SoundManager.Instance.Play();
    }

    public override void UpdateFlow(float _dt) {
        // @TODO
    }

    public override void FixedUpdateFlow(float _fdt) {
        // @TODO
    }
}
