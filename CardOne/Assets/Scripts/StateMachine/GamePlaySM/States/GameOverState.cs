using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : StateBase {
    public override void Start(StateMachineBase _stateMachine) {
        base.Start(_stateMachine);
    }

    public override void Update() {
        Debug.Log("GameOver Update");
    }

    public override void End() {
        Debug.Log("GameOver End");
    }
}
