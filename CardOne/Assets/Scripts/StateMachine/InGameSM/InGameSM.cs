using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class InGameSM : StateMachineBase {

	// Use this for initialization
	void Start () {
        ChangeState(new SetupRoundPhase());
        Debug.Log("Partenza della InGameSM");
	}

    public override void NotifyTheStateIsOver() {
        switch (CurrentState.GetType().Name) {
            case "SetupRoundPhase":
                ChangeState(new StrategicPhase());
                break;
            case "StrategicPhase":
                ChangeState(new CombatPhase());
                break;
            case "CombatPhase":
                ChangeState(new CheckPhase());
                break;
            case "CheckPhase":
                
                break;
            default:
                break;
        }
    }
}
