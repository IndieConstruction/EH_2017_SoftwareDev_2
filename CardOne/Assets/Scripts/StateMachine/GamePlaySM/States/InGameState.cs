using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : StateBase {

   
    public override void Start(StateMachineBase _stateMachine) {
        base.Start(_stateMachine);
        stateMachine.gameObject.AddComponent<InGameSM>();
    }
    public override void Update() {
        //Debug.Log("InGame Update");
    }

    public override void End() {
        Debug.Log("InGame End");
    }
}
