﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GamePlayManager : MonoBehaviour {

	public static GamePlayManager gpm;
	public int CurrentRound ;
	PlayerData currentPLayer;
    CardManager cm;
   
    public static List<PlayerData> Players() {
                PlayerData[] allPlayer = Resources.LoadAll<PlayerData>("Players");
                return allPlayer.ToList<PlayerData>();
                }


	void Awake(){
        if (gpm == null)
            gpm = this;
        cm = FindObjectOfType<CardManager>();
	}

    void Start() {
        
        GameLevelData levelToLoad = GetLevelInfo("1.2");
        SetUpPlayers(levelToLoad);
        SetUpBoard(levelToLoad);
        SetUpCards(levelToLoad);
        SetUpRound(levelToLoad);
    }

   

    /// <summary>
    /// Setta i players
    /// </summary>
	void SetUpPlayers(GameLevelData _gameLeveldata) {
        Debug.Log("Setup Players");
       
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
    /// Setta il round
    /// </summary>
    void SetUpRound(GameLevelData _gameLeveldata) {
        Debug.Log("Setup Round");
		CurrentRound++;
		currentPLayer = RandomPlayer ();
		currentPLayer.MyTurn = true;
		if (CurrentRound == 1) {
            cm.GiveCards(4);
        } 
		else {
            cm.GiveCards(1);
        }
		foreach (PlayerData p in Players()) {
			p.Mana = CurrentRound;		}
    }

	public PlayerData RandomPlayer()
	{
		int randomInd = Random.Range(0, Players().Count);
		return Players()[randomInd];

	
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
