using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaySM : StateMachine {

    private void Start() {
        ChangeState(new SetUpGamePlay());
    }
    public override void NotifyTheStateIsOver() {
        switch (CurrentState.GetType().Name) {
            case "SetUpGamePlay":
                ChangeState(new InGame());
                break;
            default:
                break;
        }
    }
}
