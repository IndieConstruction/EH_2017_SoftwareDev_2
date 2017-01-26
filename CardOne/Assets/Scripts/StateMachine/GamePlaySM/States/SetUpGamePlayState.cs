using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Stato che gestisce il Setup prima del GamePlay
/// </summary>
public class SetUpGamePlayState : StateBase {

    #region Runtime Variables
    
    #endregion

    #region LifeCycle
    public override void Start(StateMachineBase _stateMachine) {
        base.Start(_stateMachine);
        SetupGameplay();
        stateMachine.NotifyTheStateIsOver();
    }
    public override void Update() {

    }
    public override void End() {

    } 
    #endregion

    #region Setups
    /// <summary>
    /// Esegue il setup del gameplay.
    /// </summary>
    void SetupGameplay() {
        GamePlayManager.I.currentLevel = GetLevelInfo(GamePlayManager.I.CurrentLevelId);
        GamePlayManager.I.CurrentRound = 1;
        SetUpPlayers(GamePlayManager.I.currentLevel);
        SetUpBoard(GamePlayManager.I.currentLevel);
        SetUpCards(GamePlayManager.I.currentLevel);
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
    /// Setta il tavolo
    /// </summary>
    void SetUpBoard(GameLevelData _gameLeveldata) {
        Debug.Log("Setup Board");
        GamePlayManager.I.boardView.Init(_gameLeveldata.Board);
        //Debug.Log("il level data e" + _gameLeveldata.Id);

    }
    /// <summary>
    /// Setta le carte
    /// </summary>
    void SetUpCards(GameLevelData _gameLeveldata) {
        Debug.LogFormat("Setup Cards {0}", _gameLeveldata.AllCards.Count);
        GamePlayManager.I.cm.GiveCardsToDecks(_gameLeveldata.StartNumberOfCardsInPlayerDeck);
    }

    #endregion

    #region Functions

    /// <summary>
    /// Carica da disco le info del livello tramite l'id del livello,
    /// Operazione da seguire solo nella fase di setup
    /// </summary>
    /// <param name="_levelId"></param>
    /// <returns></returns>
    GameLevelData GetLevelInfo(string _levelId) {
        // Creo oggetto riempire e restutire
        GameLevelData returnGameLevel = new GameLevelData();

        GameLevelData[] allLevels = Resources.LoadAll<GameLevelData>("Levels");
        foreach (GameLevelData levelData in allLevels) {
            if (levelData.Id == _levelId)
                returnGameLevel = levelData;
        }

        returnGameLevel.AllCards = CardManager.GetAllCards();

        //switch (_levelId) {
        //    case 1:
        //        returnGameLevel = new GameLevel() {
        //            StartNumberOfCards = 5,
        //            Cols = new List<BoardCol>() {
        //                                     new BoardCol() { ColType = -1 },
        //                                     new BoardCol() { ColType = 0 },
        //                                     new BoardCol() { ColType = 0 },
        //                                     new BoardCol() { ColType = 0 },
        //                                     new BoardCol() { ColType = -1 },
        //                                 }
        //        };
        //        break;

        //    default:
        //        returnGameLevel = new GameLevel();
        //        break;
        //}



        return returnGameLevel;
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
    #endregion
}
