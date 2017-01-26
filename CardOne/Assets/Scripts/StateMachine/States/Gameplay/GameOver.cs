using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : State {
    public override void Start(StateMachine _stateMachine) {
        base.Start(_stateMachine);
    }

    public override void Update() {
        Debug.Log("GameOver Update");
    }

    public override void End() {
        Debug.Log("GameOver End");
    }
}
