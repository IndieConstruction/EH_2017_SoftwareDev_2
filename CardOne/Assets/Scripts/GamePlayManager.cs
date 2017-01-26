using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GamePlayManager : MonoBehaviour {

    #region variables
    public string CurrentLevelId = "1.1";

    /// <summary>
    /// contiene i dati del livello corrente 
    /// </summary>
    public GameLevelData currentLevel;


    public static GamePlayManager I;
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
        if (I == null)
            I = this;
        cm = FindObjectOfType<CardManager>();
	}

    #region Flow

    void Start() {
       // GameplayFlow();
    }

    private void Update() {
       // Debug.Log("Debug Update");
    }



    /// <summary>
    /// Gestisce il flow del gameplay.
    /// </summary>
    //GameLevelData currentLevel;
    //public void GameplayFlow() {
    //    bool endGame = false;
    //  //  while (!endGame) {
    //        SetUpRound(CurrentRound, currentLevel);
    //        // Gameplay
    //        CurrentRound++;
    //        if (CurrentRound == 5)
    //            endGame = true;
       // }

    

    #endregion

    #region functions
    


    

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


    
}
