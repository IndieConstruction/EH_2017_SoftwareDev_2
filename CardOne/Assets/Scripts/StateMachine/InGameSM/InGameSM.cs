using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// State Machine che gestisce le fasi di gioco
/// </summary>
public class InGameSM : StateMachineBase {
  
    Button next;
	// Use this for initialization
	void Start () {
        ChangeState(new SetupRoundPhase());
        //Debug.Log("Partenza della InGameSM");
        foreach (Button b in FindObjectsOfType<Button>()) {
            if (b.name == "NextButton")
                next = b;
        }
        if (next)
            next.onClick.AddListener(() => EndStrategic());
        //if (next)
           next.onClick.AddListener(() => EndCheck());
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
                ChangeState(new SetupRoundPhase());
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// chiamata quando viene premuto il bottone, indica che il player attivo ha finito la sua fase strategica
    /// </summary>
    public void EndStrategic() {
        if (CurrentState.GetType().Name == "StrategicPhase") {
            StrategicPhase tempStrategic = CurrentState as StrategicPhase;
            tempStrategic.GoToNextStep();
        }
    }
    /// <summary>
    /// chiamata quando vierne premuto il bottone, fa terminare la check phase
    /// Non ha senso averlo,ma senno andava in loop continuo
    /// </summary>
    public void EndCheck()
    {
        if (CurrentState.GetType().Name == "CheckPhase")
        {
            CheckPhase tempCheckPhase = CurrentState as CheckPhase;
            tempCheckPhase.RestartGameplay();
            foreach (CardView item in GamePlayManager.I.GetCardsInScene())
            {
                if (item.Data.Life <= 0)
                    Destroy(item.gameObject);
            }
        }
     
    }


    private void OnDestroy() {
        if (next)
            next.onClick.RemoveAllListeners();
        
    }

    public void PlayerIsDead(PlayerData _playerData) {
       // ChangeState(new )); 
    }
}
