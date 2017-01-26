using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSM : StateMachineBase {

	// Use this for initialization
	void Start () {
        ChangeState(new SetupRoundState());
        Debug.Log("Partenza della SM in game");
	}

    public override void NotifyTheStateIsOver() {
        switch (CurrentState.GetType().Name) {
            case "SetupRoundState":
                ChangeState(new StrategicPhase());
                break;
            case "StrategicPhase":
                break;
            default:
                break;
        }
    }
}
