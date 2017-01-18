using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {// fa spostato nel cardData
    public string id;
    public CardManager cm;
    public List<CardData> cards;
    private void Awake()
    {
        cm = FindObjectOfType<CardManager>();
        cm.decks.Add(this);
    }
}
