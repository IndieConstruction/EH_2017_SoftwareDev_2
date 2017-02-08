using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCardsState : StateBase {

    public override void Start(StateMachineBase _stateMachine) {
        base.Start(_stateMachine);
        SetUpCards(GamePlayManager.I.currentLevel);
        stateMachine.NotifyTheStateIsOver();
       
    }

    public override void Update() {

    }

    public override void End() {
       
    }

    /// <summary>
    /// Setta le carte
    /// </summary>
    void SetUpCards(GameLevelData _gameLeveldata) {
        Debug.LogFormat("Setup Cards {0}", _gameLeveldata.AllCards.Count);
        GamePlayManager.I.cm.GiveCardsToDecks(_gameLeveldata.StartNumberOfCardsInPlayerDeck);
    }

}
