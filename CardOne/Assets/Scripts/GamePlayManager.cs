﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GamePlayManager : MonoBehaviour {

    #region variables
    GameLevelData currentLevel; 

    public static GamePlayManager gpm;
	public int CurrentRound ;
    /// <summary>
    /// Contiene il player attivo nella fase di gameplay.
    /// </summary>
	PlayerData currentPlayer;
    CardManager cm;

    private List<PlayerData> players;
    /// <summary>
    /// Contiene l'elenco ordinato dei players.
    /// </summary>
    public List<PlayerData> Players {
        get { return players; }
        set { players = value; }
    }

    #endregion

    void Awake(){
        if (gpm == null)
            gpm = this;
        cm = FindObjectOfType<CardManager>();
	}

    #region Flow

    void Start() {
        // Setup gameplay
        SetupGameplay();
        GameplayFlow();
    }

    /// <summary>
    /// Esegue il setup del gameplay.
    /// </summary>
    public void SetupGameplay() {
        currentLevel = GetLevelInfo("1.2");
        SetUpPlayers(currentLevel);
        SetUpBoard(currentLevel);
        SetUpCards(currentLevel);
        CurrentRound = 1;
    }

    /// <summary>
    /// Gestisce il flow del gameplay.
    /// </summary>
    public void GameplayFlow() {
        bool endGame = false;
        while (!endGame) {
            SetUpRound(CurrentRound, currentLevel);
            // Gameplay
            CurrentRound++;
            if (CurrentRound == 5)
                endGame = true;
        }

    }

    #endregion

    #region functions

    /// <summary>
    /// Legge tutti i players selezionabili in gioco.
    /// </summary>
    /// <returns></returns>
    public static List<PlayerData> LoadPlayersFromDisk() {
        // TODO: Limitare numero di player a 2.
        PlayerData[] allPlayer = Resources.LoadAll<PlayerData>("Players");
        return allPlayer.ToList<PlayerData>();
    }

    /// <summary>
    /// Setta i players
    /// </summary>
	void SetUpPlayers(GameLevelData _gameLeveldata) {
        Debug.Log("Setup Players");
        players = LoadPlayersFromDisk();
        SetPlayersOrder();
        // TODO: inizializzare ogni player con i dati di partenza (se prensenti nel _gameLeveldata prenderli da lì)
        //foreach (Player p in players) {
        //currentPLayer.Life = 20;
        //currentPLayer.Mana = CurrentRound;
        //}


    }
    /// <summary>
    /// Setta il tavolo
    /// </summary>
    void SetUpBoard(GameLevelData _gameLeveldata) {
        Debug.Log("Setup Board");
        Debug.Log("il level data e" + _gameLeveldata.Id);

    }
    /// <summary>
    /// Setta le carte
    /// </summary>
    void SetUpCards(GameLevelData _gameLeveldata) {
        Debug.LogFormat("Setup Cards {0}", _gameLeveldata.AllCards.Count);
        cm.GiveCardsToDecks(2);
        cm.GiveDeck();
        
    }


    /// <summary>
    /// Setta le informazioni necessare per il round corrente.
    /// </summary>
    void SetUpRound(int _round, GameLevelData _gameLeveldata) {
        Debug.Log("Setup Round");
		//if (CurrentRound == 1) {
  //          cm.GiveCards(4);
  //      } 
		//else {
  //          cm.GiveCards(1);
  //      }
		foreach (PlayerData p in LoadPlayersFromDisk()) {
			p.Mana = CurrentRound;
        }
    }

    /// <summary>
    /// Setta l'ordine dei giocatori durante i round.
    /// </summary>
    /// <returns></returns>
	public List<PlayerData> SetPlayersOrder()
	{
		// TODO: mischiare l'ordine dei player random
		return Players;
        
	}

	public void StrategicPhase(){
	
		//if (gpm.Players().MyTurn)
		//{
		//	gpm.Players[0].MyTurn = false;
		//	gpm.Players[1].MyTurn = true;

		//}
		//else if (gpm.Players[1].MyTurn)
		//{
		//	gpm.Players[1].MyTurn = false;
		//	gpm.Players[0].MyTurn = true;
		//}

	}

    #endregion


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
