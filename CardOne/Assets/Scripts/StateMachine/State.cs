using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base per ogni stato della macchina a stati.
/// </summary>
public abstract class State {
    protected StateMachine stateMachine;
    public virtual void Start(StateMachine _stateMachine) {
        stateMachine = _stateMachine;
    }
    
    public abstract void Update();
    public abstract void End();
}
