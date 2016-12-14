using UnityEngine;
using System.Collections;

public class GamePlayManager : MonoBehaviour {

    void Start() {

        SetUpPlayers();
        SetUpBoard();
        SetUpCards();
        SetUpRound();
    }

    /// <summary>
    /// Setta i players
    /// </summary>
	void SetUpPlayers() {
        Debug.Log("Setup Players");
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
        Debug.Log("Setup Round ");
    }
}
