using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Level", menuName = "Levels/LevelData", order = 1)]
public class GameLevelData : ScriptableObject
{
    public string Id;
    /// <summary>
    /// Carte che da in mano al primo round
    /// </summary>
    public int StartNumberOfCards;
    /// <summary>
    /// Carte che vengono iniettate nel deck di ogni player durante il SetUp.
    /// </summary>
    public int StartNumberOfCardsInPlayerDeck = 20;
    public string ThemePrefix;
    [HideInInspector] public List<CardData> AllCards;
    public BoardData Board;
    public int PlayersStartLife = 20;
}
