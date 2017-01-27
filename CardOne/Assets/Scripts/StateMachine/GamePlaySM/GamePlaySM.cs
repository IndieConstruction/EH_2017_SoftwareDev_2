using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaySM : StateMachineBase {

    private void Start() {
        ChangeState(new SetUpGamePlayState());
    }
    public override void NotifyTheStateIsOver() {
        switch (CurrentState.GetType().Name) {
            case "SetUpGamePlayState":
                ChangeState(new InGameState());
                break;
            default:
                break;
        }
    }
}
