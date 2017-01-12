using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Classe che contiene le informazioni riguardanti la board di gioco
/// </summary>
[CreateAssetMenu(fileName = "Board", menuName = "Levels/Board", order = 1)]
public class BoardData : ScriptableObject
{

    #region Board Data
    public List<Column> ColumnList = new List<Column>(5);
    #endregion

    #region Runtime Data
    [HideInInspector]
    /// <summary>
    /// Contenitore delle carte in mano al player 1.
    /// </summary>
    public List<CardData> Player1HandledCardsContainer = new List<CardData>();

    [HideInInspector]
    /// <summary>
    /// Contenitore delle carte in mano al player 2.
    /// </summary>
    public List<CardData> Player2HandledCardsContainer = new List<CardData>(); 
    #endregion
}

/// <summary>
/// Enumeratore che definisce i possibili valori del Terrain type.
/// </summary>
public enum TerrainTypes { Empty, Elevated, Water, Ground };
/// <summary>
/// Enumeratore che definische dove i player possono posizionare la carta nella board durante la fase strategica
/// </summary>
public enum PlayerSlotType{Player1,Player2};
