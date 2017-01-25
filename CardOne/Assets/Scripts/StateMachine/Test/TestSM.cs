using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSM : StateMachine {

    public Button PlayButton;

    public static TestSM I;

    private void Awake() {
        if (I == null)
            I = this;
    }

    // Use this for initialization
    void Start () {
        ChangeState(new PreGameplay());
	}

    #region API StateMachine

    public void GoToInGame() {
        ChangeState(new InGame());
    }

    public void GoToGameOver() {
        ChangeState(new GameOver());
    }

    #endregion


    #region GameplayAPI

    public void ShowPlayButton(bool _show) {
        if (_show)
            PlayButton.transform.position = Vector2.zero;
        else
            PlayButton.transform.position = new Vector2(1000, 0);
    }

    #endregion
}
