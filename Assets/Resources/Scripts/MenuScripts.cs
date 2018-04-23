using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScripts : MonoBehaviour {

    public void OnStartClick() {
        FlowManager.Instance.ChangeFlows(GV.SCENENAMES.MainScene);
    }
}
