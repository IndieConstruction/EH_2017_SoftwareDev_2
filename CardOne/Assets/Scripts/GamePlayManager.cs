using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GamePlayManager : MonoBehaviour {

    #region variables
    public string CurrentLevelId = "1.1";
    
    GameLevelData currentLevel; 

    public static GamePlayManager Instance;
	public int CurrentRound ;
    /// <summary>
    /// Contiene il player attivo nella fase di gameplay.
    /// </summary>
	PlayerData currentPlayer;
    public CardManager cm;

    private List<PlayerData> players;
    /// <summary>
    /// Contiene l'elenco ordinato dei players.
    /// </summary>
    public List<PlayerData> Players {
        get { return players; }
        set { players = value; }
    }

    public BoardView boardView;
    public PlayerView PView1,PView2;
    #endregion

    void Awake(){
        if (Instance == null)
            Instance = this;
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
        currentLevel = GetLevelInfo(CurrentLevelId);
        CurrentRound = 1;
        SetUpPlayers(currentLevel);
        SetUpBoard(currentLevel);
        SetUpCards(currentLevel);
    }

    /// <summary>
    /// Gestisce il flow del gameplay.
    /// </summary>
    public void GameplayFlow() {
        bool endGame = false;
      //  while (!endGame) {
            SetUpRound(CurrentRound, currentLevel);
            // Gameplay
            CurrentRound++;
            if (CurrentRound == 5)
                endGame = true;
       // }

    }

    #endregion

    #region functions

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
    /// Setta i players
    /// </summary>
	void SetUpPlayers(GameLevelData _gameLeveldata) {
        Debug.Log("Setup Players");
        Players = LoadPlayersFromDisk();
        // TODO: Limitare numero di player a 2.
        Players.RemoveRange(2, Players.Count-2);
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
    /// Setta le informazioni necessare per il round corrente.
    /// </summary>
    void SetUpRound(int _round, GameLevelData _gameLeveldata) {
        Debug.Log("Setup Round");
        if (CurrentRound == 1) {
            foreach (PlayerData playerD in Players) {
                playerD.PutCardsInHand(_gameLeveldata.StartNumberOfCards);
            } 
        } else {
            foreach (PlayerData playerD in Players) {
                playerD.PutCardsInHand(1);
            }
        }
        foreach (PlayerData p in LoadPlayersFromDisk()) {
			p.Mana = CurrentRound;
        }
    }

    /// <summary>
    /// Setta l'ordine dei giocatori durante i round.
    /// </summary>
    /// <returns></returns>
    List<PlayerData> SetPlayersOrder()
    {
        List<PlayerData> pd = new List<PlayerData>();
        int randomInd = Random.Range(0, Players.Count);
        pd.Insert(0, Players[randomInd]);
        Players.Remove(Players[randomInd]);
        pd.Insert(1, Players[0]);
        Players = pd;

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
    
    #region API

    /// <summary>
    /// Restituisce la view del player passato come parametro.
    /// </summary>
    /// <param name="_playerData"></param>
    /// <returns></returns>
    public PlayerView GetPlayerViewFromData(PlayerData _playerData) {
        if (_playerData.id == Players[0].id)
            return PView1;
        else
            return PView2;
    }
    /// <summary>
    /// Restituisce 1 se il parametro è riferito al player1, 2 se è riferito al player2
    /// </summary>
    /// <param name="_playerData"></param>
    /// <returns></returns>
    public int GetPlayerNumber(PlayerData _playerData) {
        if (_playerData.id == Players[0].id)
            return 1;
        else
            return 2;
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
