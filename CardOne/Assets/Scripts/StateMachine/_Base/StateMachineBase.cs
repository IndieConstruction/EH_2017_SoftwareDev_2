using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base da estendere per creare una macchina Stati finiti.
/// </summary>
public abstract class StateMachineBase : MonoBehaviour {
    #region Events
    /// <summary>
    /// Evento che comunica il cambio dello stato di questa SM.
    /// </summary>
    public delegate void StateMachineEvent();

    public static StateMachineEvent OnStateChanged;
    #endregion
    /// <summary>
    /// Contiene la SMparent, se è vuota, non ho nessun SMparent.
    /// </summary>
    private StateMachineBase _parentSm;
    public StateMachineBase ParentSM {
        get { return _parentSm; }
        set { _parentSm = value; }
    }

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
        if (OnStateChanged != null)
            OnStateChanged();
    }

    public virtual void Update() {
        if(CurrentState != null)
            CurrentState.Update();
    }
    /// <summary>
    /// Avvisa che lo stato attuale ha finito
    /// </summary>
    public virtual void NotifyTheStateIsOver() { }

   /// <summary>
   /// Innesta una SM con parent a questa SM.
   /// </summary>
    public void CreateNestedSM<T>() where T : StateMachineBase {
        T component = gameObject.AddComponent<T>();
        component.ParentSM = this;
    }
}
