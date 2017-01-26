using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerDataInfo", menuName = "Player/PlayerData", order = 1)]
public class PlayerData{
    public string id; 
    public Sprite PlayerImage;
    private int mana = 1;

    public int Mana {
        get { return mana; }
        set {
            if (OnDataChanged != null)
                OnDataChanged();
            mana = value;
        }
    }

    private int life = 20;

    public int Life {
        get { return life; }
        set {
            if (OnDataChanged != null)
                OnDataChanged();
            life = value;
        }
    }

    #region Events
    public delegate void DataEvent();

    public DataEvent OnDataChanged;
    #endregion
    #region Runtime Data
    [HideInInspector]
    /// <summary>
    /// Deck del player
    /// </summary>
    public List<CardData> Deck = new List<CardData>();
    /// <summary>
    /// Contenitore delle carte in mano al player
    /// </summary>
    [HideInInspector]
    public List<CardData> CardDataInHand = new List<CardData>();
    #endregion
    /// <summary>
    /// mette le carte in CardsInHand e le toglie da Deck
    /// </summary>
    /// <param name="numberOfCards"></param>
    public void PutCardsInHand(int numberOfCards) {

        for (int i = 0; i < numberOfCards; i++) {
            //Debug.Log(Deck[i].ID);
            CardDataInHand.Add(Deck[0]);
            //GameObject.Instantiate(GamePlayManager.Istance.cm.cardView).Init(Deck[0]);
            CardView newCardView = GameObject.Instantiate(GamePlayManager.I.cm.cardViewPrefab);
            newCardView.Init(Deck[0]);
            newCardView.AllocateCardToPlayer(this);

            //GameObject cardGameObject = GameObject.Instantiate(GamePlayManager.Istance.cm.cardView) as GameObject;
            Deck.Remove(Deck[0]);
        }
       
    }
}
