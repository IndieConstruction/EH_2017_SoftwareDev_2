using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : StateBase
{
    public override void Start(StateMachineBase _stateMachine)
    {
        base.Start(_stateMachine);
        CheckWinner();

    }

    public override void Update()
    {
        Debug.Log("GameOver Update");
    }

    public override void End()
    {
        Debug.Log("GameOver End");
    }

    public void CheckWinner()
    {
        GamePlayManager.I.GameOverComponent.GetComponent<Image>().enabled = true;
        foreach (var item in GamePlayManager.I.GameOverComponent.GetComponentsInChildren<Text>())
        {
            item.enabled = true;
        }
        GamePlayManager.I.ButtonContainer.SetActive(true);
        //foreach (var item in GamePlayManager.I.GameOverComponent.GetComponentsInChildren<Button>())
        //{
        //    item.gameObject.SetActive(true);    
        //}
        if (GamePlayManager.I.Players[1].Life <= 0)
        {
            GamePlayManager.I.PlayerTwoEndGameText.text = "YouLose";
            GamePlayManager.I.PlayerOneEndGameText.text = "YouWin";

        }
        if (GamePlayManager.I.Players[0].Life <= 0)
        {
            GamePlayManager.I.PlayerTwoEndGameText.text = "YouWin";
            GamePlayManager.I.PlayerOneEndGameText.text = "YouLose";

        }

        if (GamePlayManager.I.Players[1].Life <= 0 && GamePlayManager.I.Players[0].Life <= 0)
        {
            GamePlayManager.I.PlayerOneEndGameText.text = "YouLose";
            GamePlayManager.I.PlayerTwoEndGameText.text = "YouLose";
        }

    }
}
