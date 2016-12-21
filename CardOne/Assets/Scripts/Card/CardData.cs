using UnityEngine;
using System;

[CreateAssetMenu(fileName = "CardDataInfo", menuName = "Card/CardData", order = 1)]
public class CardData : ScriptableObject {
    public string ID;
    public CardType Type;
    public int ManaCost;
    public int Life;
    public int Attack;
    public Slot SlotType;
}

public enum CardType {
    Base,
    Effect,
}
