using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Level", menuName = "Levels/LevelData", order = 1)]
public class GameLevelData : ScriptableObject
{
    public string Id;
    public int StartNumberOfCards;
    public string ThemePrefix;
    [HideInInspector] public List<CardData> AllCards;
    public BoardData Board;
}
