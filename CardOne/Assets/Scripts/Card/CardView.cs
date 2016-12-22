using UnityEngine;
using System.Collections;

public class CardView : MonoBehaviour {

    public CardData Data;

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
        
    }
}


