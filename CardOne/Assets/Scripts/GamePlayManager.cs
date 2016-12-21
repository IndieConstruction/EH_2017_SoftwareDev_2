using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayManager : MonoBehaviour {

	public static GamePlayManager gpm;
	public int CurrentRound ;
	Player currentPLayer;
	public List <Player> Players;


	void Awake(){

		if (gpm == null)
			gpm = this;
	}

    void Start() {
        GameLevel levelToLoad = GetLevelInfo(2);
        SetUpPlayers(levelToLoad);
        SetUpBoard(levelToLoad);
        SetUpCards(levelToLoad);
        SetUpRound(levelToLoad);
    }

    /// <summary>
    /// Setta i players
    /// </summary>
	void SetUpPlayers(GameLevel _gameLeveldata) {
        Debug.Log("Setup Players");
		//foreach (Player p in players) {
			//currentPLayer.Life = 20;
			//currentPLayer.Mana = CurrentRound;
		//}

    }
    /// <summary>
    /// Setta il tavolo
    /// </summary>
    void SetUpBoard(GameLevel _gameLeveldata) {
        Debug.Log("Setup Board");
        foreach (BoardCol col in _gameLeveldata.Cols) {
            switch (col.ColType) {
                case 0:
                    // base
                    break;
                case 1:
                    // Acqua
                    break;
                case 2:
                    // Sopraelevato
                    break;
                default:
                    // Non utilizzato
                    break;
            }
        }
    }
    /// <summary>
    /// Setta le carte
    /// </summary>
    void SetUpCards(GameLevel _gameLeveldata) {
        Debug.LogFormat("Setup Cards {0}", _gameLeveldata.AllCards.Count);

    }
    /// <summary>
    /// Setta il round
    /// </summary>
    void SetUpRound(GameLevel _gameLeveldata) {
        Debug.Log("Setup Round");
		CurrentRound++;
		currentPLayer = RandomPlayer ();
		currentPLayer.MyTurn = true;
		if (CurrentRound == 1) {
			DealCards (_gameLeveldata.StartNumberOfCards);
		} 
		else {
			DealCards (1);
		}
		foreach (Player p in Players) {
			p.Mana = CurrentRound;		}
    }

	public Player RandomPlayer()
	{
		int randomInd = Random.Range(0, Players.Count);
		return Players[randomInd];

	
	}

	public void StrategicPhase(){
	
		if (gpm.Players[0].MyTurn)
		{
			gpm.Players[0].MyTurn = false;
			gpm.Players[1].MyTurn = true;

		}
		else if (gpm.Players[1].MyTurn)
		{
			gpm.Players[1].MyTurn = false;
			gpm.Players[0].MyTurn = true;
		}

	}

	void DealCards (int numberOfCards){
		//dai carte
	}


    int GetInitialCardNumberFromDifficultyLevel(int _levelId) {
        switch (_levelId) {
            case 1:
                return 5;
            case 2:
                return 4;
            case 3:
                return 3;
        }

        return 0;
    }


    GameLevel GetLevelInfo(int _levelId) {
        GameLevel returnGameLevel = new GameLevel();
        switch (_levelId) {
            case 1:
                returnGameLevel = new GameLevel() {
                    StartNumberOfCards = 5,
                    Cols = new List<BoardCol>() {
                                             new BoardCol() { ColType = -1 },
                                             new BoardCol() { ColType = 0 },
                                             new BoardCol() { ColType = 0 },
                                             new BoardCol() { ColType = 0 },
                                             new BoardCol() { ColType = -1 },
                                         }
                };
                break;
            case 2:
                returnGameLevel = new GameLevel() {
                    StartNumberOfCards = 4,
                    Cols = new List<BoardCol>() {
                                             new BoardCol() { ColType = 0 },
                                             new BoardCol() { ColType = 0 },
                                             new BoardCol() { ColType = 0 },
                                             new BoardCol() { ColType = 0 },
                                             new BoardCol() { ColType = 0 },
                                          }
                };
                break;
            case 3:
                returnGameLevel = new GameLevel() {
                    StartNumberOfCards = 2,
                    Cols = new List<BoardCol>() {
                                             new BoardCol() { ColType = 1 },
                                             new BoardCol() { ColType = 0 },
                                             new BoardCol() { ColType = 0 },
                                             new BoardCol() { ColType = 0 },
                                             new BoardCol() { ColType = 2 },
                                         },
                    ThemePrefix = "Disco",
                };
                break;
            default:
                returnGameLevel = new GameLevel();
                break;
        }

        returnGameLevel.AllCards = CardManager.GetAllCards();

        return returnGameLevel;
    }


    #region Data Structure for Game Level 
    public class GameLevel {
        public int StartNumberOfCards;
        public List<BoardCol> Cols;
        public string ThemePrefix;
        public List<CardData> AllCards;
    }

    public class BoardCol {
        public int ColType;
    }
    #endregion


}
