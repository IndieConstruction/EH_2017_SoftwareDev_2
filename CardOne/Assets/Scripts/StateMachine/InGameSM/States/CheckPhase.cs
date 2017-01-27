using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Fase di controllo, avviene subito dopo la Fase di combattimento
/// Controlla se qualche Player ha life 0.
/// In caso Entrambi i Player sono ancora vivi si torna alla fase Strategica
/// In caso un player avese 0 life, si va in GameOver
/// </summary>
public class CheckPhase : StateBase {

    public override void Start(StateMachineBase _stateMachine){
        base.Start(_stateMachine);
        Debug.Log("CheckPhase iniziata");
        //funzioni
        stateMachine.NotifyTheStateIsOver();
    }

    public override void Update(){
    }
    public override void End(){
    }
}
