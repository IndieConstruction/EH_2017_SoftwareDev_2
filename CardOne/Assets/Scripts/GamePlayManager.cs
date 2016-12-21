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

        SetUpPlayers();
        SetUpBoard();
        SetUpCards();//
        SetUpRound();
    }

    /// <summary>
    /// Setta i players
    /// </summary>
	void SetUpPlayers() {
        Debug.Log("Setup Players");
		//foreach (Player p in players) {
			//currentPLayer.Life = 20;
			//currentPLayer.Mana = CurrentRound;
		//}

    }
    /// <summary>
    /// Setta il tavolo
    /// </summary>
    void SetUpBoard() {
        Debug.Log("Setup Board");
    }
    /// <summary>
    /// Setta le carte
    /// </summary>
    void SetUpCards() {
		
        Debug.Log("Setup Cards");
    }
    /// <summary>
    /// Setta il round
    /// </summary>
    void SetUpRound() {
        Debug.Log("Setup Round");
		CurrentRound++;
		currentPLayer = RandomPlayer ();
		currentPLayer.MyTurn = true;
		if (CurrentRound == 1) {
			Deck.DealCards(4,currentPLayer);
		} 
		else {
			Deck.DealCards (1,currentPLayer);
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

	//void DealCards (int numberOfCards){
		//dai carte
	//}


}
