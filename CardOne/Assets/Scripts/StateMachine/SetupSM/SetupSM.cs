using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupSM : StateMachineBase {

    // Use this for initialization
    void Start() {
        ChangeState(new SetupPlayersState());
    }

    public override void NotifyTheStateIsOver() {
        switch (CurrentState.GetType().Name) {
            case "SetupPlayersState":
                ChangeState(new SetupBoardState());
                break;
            case "SetupBoardState":
                ChangeState(new SetupCardsState());
                break;
            case "SetupCardsState":
                Debug.Log("FineSetup");
                GamePlaySM gp = ParentSM as GamePlaySM;
                gp.DestroyNestedSM(this);
                Debug.Log("EndState");
                break;
            default:
                break;
        }
    }
}
