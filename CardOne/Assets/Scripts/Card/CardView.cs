using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class CardView : MonoBehaviour {
    public CardManager cm;
    [HideInInspector] public CardData Data;
    
    public string IdCard;
 

    /// <summary>
    /// Init dei dati.
    /// </summary>
    /// <param name="_cardData"></param>
    public void Init(CardData _cardData) {
        Data = _cardData;
        InitGraphic(_cardData);
    }

    /// <summary>
    /// Fa tutte le cose che servono a visualizzare i dati nella carta.
    /// </summary>

    private void Awake()
    {
        cm = FindObjectOfType<CardManager>();
       
    }
    public void InitGraphic(CardData c)
    {
        gameObject.GetComponentsInChildren<TextMesh>()[0].text = c.Life.ToString();
        gameObject.GetComponentsInChildren<TextMesh>()[1].text = c.Attack.ToString();
        gameObject.GetComponentsInChildren<TextMesh>()[2].text = c.ManaCost.ToString();
        //gameObject.GetComponentsInChildren<SpriteRenderer>()[3].sprite = Resources.Load(Data.ImageToLoad, typeof(Sprite)) as Sprite;
        


    }
}


