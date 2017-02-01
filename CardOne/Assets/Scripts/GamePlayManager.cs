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
   /// <summary>
   /// Restituisce una lista di carte per la colonna indicata
   /// </summary>
   /// <param name="idColumn"></param>
   /// <returns></returns>
    public List<CardData> GetCardsInColumn(int idColumn) {
       return boardView.Data.ColumnList[idColumn].cards;

    }
    /// <summary>
    /// restituisce il numero di colonne attive nella fase di gioco
    /// </summary>
    /// <returns></returns>
    public int GetNumberOfColumns() {
        return boardView.Data.ColumnList.Count;
    }
    /// <summary>
    /// Restituisce il player a cui appartiene la carta indicata
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    public PlayerData GetPlayerOwner(CardData card) {
        foreach ( PlayerData p in players) {
            foreach (CardData c in p.CardsOnBoard) {
                if (card == c) {
                    return p;
                }
            }
        }
        return null;
    }
    /// <summary>
    /// Restituisce l'altro player se gli si passa come parametro un player
    /// </summary>
    /// <param name="_player"></param>
    /// <returns></returns>
    public PlayerData GetOherPlayer (PlayerData _player) {
        foreach (PlayerData p in players) {
            if (p != _player)
                return p;
        }
        return null;
    }
    #endregion


    
}
