using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGameplay : State {
    public override void Start(StateMachine _stateMachine) {
        base.Start(_stateMachine);
    }

    public override void Update() {
        Debug.Log("PreGameplay Update");
    }

    public override void End() {
        Debug.Log("PreGameplay End");
    }
}
