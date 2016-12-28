using UnityEngine;
using System;

[CreateAssetMenu(fileName = "CardDataInfo", menuName = "Card/CardData", order = 1)]
public class CardData : ScriptableObject {
    public string ID;
    public CardType Type;
    public int ManaCost;
    public int Life;
    public int Attack;
    public SpriteRenderer CardSprite;
    public TerrainTypes SlotType;
}
/// <summary>
/// Enumeratore che definisce i tipi di carte.
/// </summary>
public enum CardType {
    Base,
    Effect,
}

