using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGameplay : State {
    public override void Start() {
        Debug.Log("PreGameplay Start");
    }

    public override void Update() {
        Debug.Log("PreGameplay Update");
    }

    public override void End() {
        Debug.Log("PreGameplay End");
    }
}
