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
        //RestartGameplay();
    }

    public override void Update(){
    }
    public override void End(){
    }

    /// <summary>
    /// Fa ripartire le fasi se entrambi i Player hanno vita.
    /// 
    /// </summary>
    public void RestartGameplay() {
      

        stateMachine.NotifyTheStateIsOver();
      
      
    }
}
