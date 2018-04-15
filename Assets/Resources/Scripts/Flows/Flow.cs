using UnityEngine;
using System.Collections;

public class Flow {
    
    public virtual void InitializeFlow() {}
    public virtual void UpdateFlow(float _dt) {}
    public virtual void FixedUpdateFlow(float _dt) {}
    public virtual void Finish() {}

}
