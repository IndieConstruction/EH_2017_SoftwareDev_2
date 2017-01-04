using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class CardView : MonoBehaviour {
    public CardManager cm;
    public CardData Data;
    private Text LifeText;
    private Text ManaCostText;
    private Text AttackText;
    public SpriteRenderer ImageToLoad;
    public string IdCard;
 

    /// <summary>
    /// Init dei dati.
    /// </summary>
    /// <param name="_cardData"></param>
    public void Init(CardData _cardData) {
        Data = _cardData;
        InitGraphic();
    }

    /// <summary>
    /// Fa tutte le cose che servono a visualizzare i dati nella carta.
    /// </summary>

    private void Awake()
    {
        cm = FindObjectOfType<CardManager>();
       cm.cardsView.Add(this);
    }
    public void InitGraphic()
    {

           Debug.Log("initgraphic");

    }
}


