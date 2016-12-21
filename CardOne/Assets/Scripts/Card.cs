using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    public CardData Data;


    public Card(CardData _cardData)
    {
        Data = _cardData;
    }
}

/// <summary>
/// Allowed slot type.
/// </summary>
public enum Slot { Roof, Water, Terrain, MyTable, Street };
