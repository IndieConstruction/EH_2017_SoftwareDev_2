
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
                    return;

                case 1:
                    //rendere più leggibile, prende l'altro player e sottrae alla sua vita l'attacco della carta giocata
                    GamePlayManager.I.GetOherPlayer(GamePlayManager.I.GetPlayerOwner(cards[0])).Life -= cards[0].Attack;
                   
                    break;
                case 2:
                    // se sono di due player diversi fa il combattimento tra le due carte
                    //se sono dello stesso player sottrae vita all'altro eroe per ogni carta

                    break;
                    
                default:
                    break;
            }
        }
    }

    public override void Update(){
        
    }
    public override void End(){

    }
}
