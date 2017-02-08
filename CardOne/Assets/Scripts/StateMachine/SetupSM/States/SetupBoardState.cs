using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBoardState : StateBase {

    public override void Start(StateMachineBase _stateMachine) {
        base.Start(_stateMachine);
        SetUpBoard(GamePlayManager.I.currentLevel);
        stateMachine.NotifyTheStateIsOver();
    }

    public override void Update() {

    }

    public override void End() {

    }

    /// <summary>
    /// Setta il tavolo
    /// </summary>
    void SetUpBoard(GameLevelData _gameLeveldata) {
        Debug.Log("Setup Board");
        GamePlayManager.I.boardView.Init(_gameLeveldata.Board);
        //Debug.Log("il level data e" + _gameLeveldata.Id);

    }
}
