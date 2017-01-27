
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Fase del Combattimento.Avviene dopo la StrategicPhase
/// Per ogni colonna si controlla :
///         Quante carte ci sono per ogni player.
///         Le carte nelle colonne attaccano le carte del player avversario
///         O in assenza di carte avversarie, attaccano il player avversario
/// </summary>
public class CombatPhase : StateBase {

    public override void Start(StateMachineBase _stateMachine){
        base.Start(_stateMachine);
        Debug.Log("CombatPhase iniziata");
        //funzioni
        stateMachine.NotifyTheStateIsOver();
    }

    public override void Update(){
       
    }
    public override void End(){

    }
}
