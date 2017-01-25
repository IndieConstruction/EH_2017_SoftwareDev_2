using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base da estendere per creare una macchina Stati finiti.
/// </summary>
public abstract class StateMachine : MonoBehaviour {

    private List<State> states;
    /// <summary>
    /// Elenco degli stati della state machine.
    /// </summary>
    public List<State> States {
        get { return states; }
        set { states = value; }
    }

    private State currentState;
    /// <summary>
    /// Stato corrente.
    /// </summary>
    public State CurrentState {
        get { return currentState; }
        set { currentState = value; }
    }

    /// <summary>
    /// Cambia lo stato in param come stato attuale.
    /// </summary>
    /// <param name="_newState"></param>
    public void ChangeState(State _newState) {
        if (CurrentState == _newState)
            return;
        if(CurrentState != null)
            CurrentState.End();
        CurrentState = _newState;
        CurrentState.Start();
    }

    public virtual void Update() {
        if(CurrentState != null)
            CurrentState.Update();
    }
}
