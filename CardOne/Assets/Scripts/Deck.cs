using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    public string id;
    public CardManager cm;
    public List<CardData> cards;
    private void Awake()
    {
        cm = FindObjectOfType<CardManager>();
        cm.decks.Add(this);
    }
}
