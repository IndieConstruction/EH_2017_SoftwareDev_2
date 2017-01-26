using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base da estendere per creare una macchina Stati finiti.
/// </summary>
public abstract class StateMachineBase : MonoBehaviour {

    private List<StateBase> states;
    /// <summary>
    /// Elenco degli stati della state machine.
    /// </summary>
    public List<StateBase> States {
        get { return states; }
        set { states = value; }
    }

    private StateBase currentState;
    /// <summary>
    /// Stato corrente.
    /// </summary>
    public StateBase CurrentState {
        get { return currentState; }
        set { currentState = value; }
    }

    /// <summary>
    /// Cambia lo stato in param come stato attuale.
    /// </summary>
    /// <param name="_newState"></param>
    public void ChangeState(StateBase _newState) {
        if (CurrentState == _newState)
            return;
        if(CurrentState != null)
            CurrentState.End();
        CurrentState = _newState;
        CurrentState.Start(this);
    }

    public virtual void Update() {
        if(CurrentState != null)
            CurrentState.Update();
    }
    /// <summary>
    /// Avvisa che lo stato attuale ha finito
    /// </summary>
    public virtual void NotifyTheStateIsOver() { }
}
