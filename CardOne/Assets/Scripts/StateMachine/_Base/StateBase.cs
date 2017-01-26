using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base per ogni stato della macchina a stati.
/// </summary>
public abstract class StateBase {
    protected StateMachineBase stateMachine;
    public virtual void Start(StateMachineBase _stateMachine) {
        stateMachine = _stateMachine;
    }
    
    public abstract void Update();
    public abstract void End();
}
