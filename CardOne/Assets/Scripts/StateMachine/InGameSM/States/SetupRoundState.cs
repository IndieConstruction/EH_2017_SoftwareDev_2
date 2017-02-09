using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupRoundPhase: StateBase {

    public override void Start(StateMachineBase _stateMachine) {
        base.Start(_stateMachine);
        SetUpRound(GamePlayManager.I.CurrentRound,GamePlayManager.I.currentLevel);
        CheckLifeCards();
        stateMachine.NotifyTheStateIsOver();
    }

    public override void Update() {

    }

    public override void End() {
        GamePlayManager.I.CurrentRound++;
    }

    /// <summary>
    /// Setta le informazioni necessare per il round corrente.
    /// </summary>
    void SetUpRound(int _round, GameLevelData _gameLeveldata) {
        Debug.Log("Setup Round");
        if (GamePlayManager.I.CurrentRound == 1) {
            foreach (PlayerData playerD in GamePlayManager.I.Players) {
                playerD.PutCardsInHand(_gameLeveldata.StartNumberOfCards);
            }
        } else {
            foreach (PlayerData playerD in GamePlayManager.I.Players) {
                playerD.PutCardsInHand(1);
            }
        }
        foreach (PlayerData p in GamePlayManager.I.Players) {
            p.Mana = GamePlayManager.I.CurrentRound;
        }
        
    }

    /// <summary>
    /// controlla se c'è qualche carta con vita 0 e la rimuove dal tavolo 
    /// </summary>
    void CheckLifeCards() {
        foreach (CardData c in GamePlayManager.I.cm.GetAllCardsFromBoard()) {
            if (c.Life < 1) {
                GamePlayManager.I.cm.DestroyCardOnBoard(c);
            }
        }
        
    }
}
