using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class CardView : MonoBehaviour {
    public CardManager cm;
    public CardData Data;
    public SpriteRenderer ImageToLoad;


    private void Start() {
        Init(Data);
    }
    /// <summary>
    /// Init dei dati.
    /// </summary>
    /// <param name="_cardData"></param>
    public void Init(CardData _cardData) {
        Data = _cardData;
        UpdateGraphic(_cardData);
    }

    /// <summary>
    /// Fa tutte le cose che servono a visualizzare i dati nella carta.
    /// </summary>

    private void Awake()
    {
        cm = FindObjectOfType<CardManager>();
       
    }
    public void UpdateGraphic(CardData c)
    {
        gameObject.GetComponentsInChildren<Text>()[0].text = c.Life.ToString();
        gameObject.GetComponentsInChildren<Text>()[1].text = c.Attack.ToString();
        gameObject.GetComponentsInChildren<Text>()[2].text = c.ManaCost.ToString();
        ImageToLoad.sprite = c.CardSprite;
        //gameObject.GetComponentsInChildren<SpriteRenderer>()[3].sprite = Resources.Load(Data.ImageToLoad, typeof(Sprite)) as Sprite;
        


    }
}


