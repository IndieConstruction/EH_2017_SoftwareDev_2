using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategicPhase : StateBase {

    public override void Start(StateMachineBase _stateMachine) {
        base.Start(_stateMachine);
        Debug.Log("StrategicPhase iniziata");
    }

    public override void Update() {
        
    }

    public override void End() {
    
    }

    
}
