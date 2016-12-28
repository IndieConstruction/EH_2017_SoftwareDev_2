using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardView : MonoBehaviour {

    public CardData Data;
    public Text PlayerLifeText;
    public Text ManaCostText;
    public Text AttackText;
    public SpriteRenderer ImageToLoad;

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
    public void InitGraphic() {
        /// TODO: CardView InitGraphic
        /// - Visualizzare la label con l'id della carta
        /// - Visualizzare la life
        /// - Attack
        /// ...
        if (ImageToLoad.ToString() == Data.ID)
        {
            AttackText.text = Data.Attack.ToString();
            ManaCostText.text = Data.ManaCost.ToString();
            PlayerLifeText.text = Data.Life.ToString();
            ImageToLoad = Data.CardSprite;
        }
    }
}


