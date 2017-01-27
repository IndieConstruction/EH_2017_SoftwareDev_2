using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSM : StateMachineBase {

	// Use this for initialization
	void Start () {
        ChangeState(new SetupRoundPhase());
        Debug.Log("Partenza della SM in game");
	}

    public override void NotifyTheStateIsOver() {
        switch (CurrentState.GetType().Name) {
            case "SetupRoundPhase":
                ChangeState(new StrategicPhase());
                break;
            case "StrategicPhase":
                break;
            case "CombatPhase":
                break;
            case "CheckPhase":
                break;
            default:
                break;
        }
    }
}
