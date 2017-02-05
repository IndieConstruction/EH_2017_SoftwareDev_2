using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Fase Strategica del GamePlay :
/// 1 - Si controlla quale player e' attivo
/// 2 - Si controlla la Mana?
/// 3 - il player attivo puo posizionare le carte in mano solo nella riga a sua disposizione
/// 4 - Cliccato il button, si cambia player e si ripetono i primi 3 punti.
/// 5 - Quando il secondo player termina la sua fase strategica, si passa alla fase di combattimento.
/// 6 - Bisogna avere un flag per ogni player per far capire che ha finito la sua fase strategica
/// </summary>
public class StrategicPhase : StateBase {
    int CurrentPlayerIndex = 0;
    public override void Start(StateMachineBase _stateMachine) {
        base.Start(_stateMachine);
        CardView.OnDragCard += OnDrag;
        CardView.OnDropCard += OnDrop;
        CurrentPlayerIndex = 0;
        Debug.Log("StrategicPhase iniziata");  
    }

    public override void Update() {
        
    }

    public override void End() {
        CardView.OnDragCard -= OnDrag;
        CardView.OnDropCard -= OnDrop;
    }
    /// <summary>
    /// Contiene le regole per permettere il drag al player attivo
    /// </summary>
    /// <param name="card"></param>
    void OnDrag(CardView card) {
        
        if (card.playerView.playerData == GamePlayManager.I.Players[CurrentPlayerIndex]) {
            card.DoDrag();
        }
        
    }
    void OnDrop(CardView card) {
        if (card.playerView.playerData == GamePlayManager.I.Players[CurrentPlayerIndex]) {
            card.DoDrop();
        }
    }
    public void GoToNextStep() {

        CurrentPlayerIndex++;
        if (CurrentPlayerIndex > GamePlayManager.I.Players.Count -1) {
            stateMachine.NotifyTheStateIsOver();
        }
    }
}
