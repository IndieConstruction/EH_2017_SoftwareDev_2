using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : State {

   
    public override void Start(StateMachine _stateMachine) {
        base.Start(_stateMachine);
    }
    public override void Update() {
        Debug.Log("InGame Update");
    }

    public override void End() {
        Debug.Log("InGame End");
    }
}
