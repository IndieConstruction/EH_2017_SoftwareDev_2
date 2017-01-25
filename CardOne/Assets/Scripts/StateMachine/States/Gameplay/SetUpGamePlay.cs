using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpGamePlay : State {

    GameLevelData currentLevel;

    public override void Start() {
        SetupGameplay();
    }
    public override void Update() {
        throw new NotImplementedException();
    }
    public override void End() {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Esegue il setup del gameplay.
    /// </summary>
    public void SetupGameplay() {
        currentLevel = GetLevelInfo(CurrentLevelId);
        CurrentRound = 1;
        SetUpPlayers(currentLevel);
        SetUpBoard(currentLevel);
        SetUpCards(currentLevel);
    }
    /// <summary>
    /// Setta i players
    /// </summary>
    void SetUpPlayers(GameLevelData _gameLeveldata) {
        Debug.Log("Setup Players");
        Players = LoadPlayersFromDisk();
        // TODO: Limitare numero di player a 2.
        Players.RemoveRange(2, Players.Count - 2);
        SetPlayersOrder();
        // Player 1 inizializzazione
        PView1.Init(Players[0]);
        Players[0].Mana = CurrentRound;
        Players[0].Life = _gameLeveldata.PlayersStartLife;

        // Player 2 inizializzazione
        PView2.Init(Players[1]);
        Players[1].Mana = CurrentRound;
        Players[1].Life = _gameLeveldata.PlayersStartLife;
    }
    /// <summary>
    /// Setta il tavolo
    /// </summary>
    void SetUpBoard(GameLevelData _gameLeveldata) {
        Debug.Log("Setup Board");
        boardView.Init(_gameLeveldata.Board);
        Debug.Log("il level data e" + _gameLeveldata.Id);

    }
    /// <summary>
    /// Setta le carte
    /// </summary>
    void SetUpCards(GameLevelData _gameLeveldata) {
        Debug.LogFormat("Setup Cards {0}", _gameLeveldata.AllCards.Count);
        cm.GiveCardsToDecks(_gameLeveldata.StartNumberOfCardsInPlayerDeck);
    }
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
}
