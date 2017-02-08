using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlayersState : StateBase {

    public override void Start(StateMachineBase _stateMachine) {
        base.Start(_stateMachine);
        SetUpPlayers(GamePlayManager.I.currentLevel);
        stateMachine.NotifyTheStateIsOver();
    }

    public override void Update() {

    }

    public override void End() {

    }
    /// <summary>
    /// Setta i players
    /// </summary>
    void SetUpPlayers(GameLevelData _gameLeveldata) {
        Debug.Log("Setup Players");
        GamePlayManager.I.Players = LoadPlayersFromDisk();
        // TODO: Limitare numero di player a 2.
        GamePlayManager.I.Players.RemoveRange(2, GamePlayManager.I.Players.Count - 2);
        SetPlayersOrder();
        // Player 1 inizializzazione
        GamePlayManager.I.PView1.Init(GamePlayManager.I.Players[0]);
        GamePlayManager.I.Players[0].Mana = GamePlayManager.I.CurrentRound;
        GamePlayManager.I.Players[0].Life = _gameLeveldata.PlayersStartLife;

        // Player 2 inizializzazione
        GamePlayManager.I.PView2.Init(GamePlayManager.I.Players[1]);
        GamePlayManager.I.Players[1].Mana = GamePlayManager.I.CurrentRound;
        GamePlayManager.I.Players[1].Life = _gameLeveldata.PlayersStartLife;
    }

    /// <summary>
    /// Legge tutti i players selezionabili in gioco.
    /// </summary>
    /// <returns></returns>
    static List<PlayerData> LoadPlayersFromDisk() {
        List<PlayerData> Players = new List<PlayerData>() {
             new PlayerData() { id = "Red" },
             new PlayerData() { id = "Blue" }
         };
        //PlayerData[] allPlayer = Resources.LoadAll<PlayerData>("Players");
        return Players;
    }
    /// <summary>
    /// Setta l'ordine dei giocatori durante i round.
    /// </summary>
    /// <returns></returns>
    List<PlayerData> SetPlayersOrder() {
        List<PlayerData> pd = new List<PlayerData>();
        int randomInd = UnityEngine.Random.Range(0, GamePlayManager.I.Players.Count);
        pd.Insert(0, GamePlayManager.I.Players[randomInd]);
        GamePlayManager.I.Players.Remove(GamePlayManager.I.Players[randomInd]);
        pd.Insert(1, GamePlayManager.I.Players[0]);
        GamePlayManager.I.Players = pd;

        return GamePlayManager.I.Players;
    }
}
