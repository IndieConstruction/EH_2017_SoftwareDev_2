using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Fase Strategica del GamePlay :
/// 1 - Si controlla quale player e' attivo
/// 2 - Si controlla la Mana?
/// 3 - il player attivo puo posizionare le carte in mano solo nella riga a sua disposizione
/// 4 - Cliccato il button, si cambia player e si ripetono i primi 3 punti.
/// 5 - Quando il secondo player termina la sua fase strategica, si passa alla fase di combattimento.
/// 6 - Bisogna avere un flag per ogni player per far capire che ha finito la sua fase strategica
/// </summary>
public class StrategicPhase : StateBase {

    public override void Start(StateMachineBase _stateMachine) {
        base.Start(_stateMachine);
        Debug.Log("StrategicPhase iniziata");
    }

    public override void Update() {
        
    }

    public override void End() {
    
    }

    
}
