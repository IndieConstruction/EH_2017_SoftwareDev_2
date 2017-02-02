
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
        for (int i = 0; i < GamePlayManager.I.GetNumberOfColumns(); i++) {
            List<CardData> cards =GamePlayManager.I.GetCardsInColumn(i);
            switch (cards.Count) {
                case 0:
                    break;

                case 1:
                    //Prende l'altro player e sottrae alla sua vita  il valore dell'attacco della carta giocata
                    GamePlayManager.I.GetOtherPlayer(GamePlayManager.I.GetPlayerOwner(cards[0])).Life -= cards[0].Attack;
                   
                    break;
                case 2:
                    //  fa il combattimento tra le due carte
                    cards[0].Life -= cards[1].Attack;
                    cards[1].Life -= cards[0].Attack;
                    
                    break;
                    
                default:
                    break;
            }
        }
        stateMachine.NotifyTheStateIsOver();
    }

    public override void Update(){
        
    }
    public override void End(){

    }
}
