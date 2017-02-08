using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Stato che gestisce il Setup prima del GamePlay
/// </summary>
public class SetUpGamePlayState : StateBase {

    

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
        stateMachine.CreateNestedSM<SetupSM>();
        //SetUpPlayers(GamePlayManager.I.currentLevel);
        //SetUpBoard(GamePlayManager.I.currentLevel);
        //SetUpCards(GamePlayManager.I.currentLevel);
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

        #region Costruttore di Livelli 
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

        #endregion


        return returnGameLevel;
    }



 
    #endregion
}
