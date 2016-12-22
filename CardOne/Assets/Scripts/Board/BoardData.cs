using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Classe che contiene le informazioni riguardanti la board di gioco
/// </summary>
[System.Serializable]
public class BoardData {
    public List<Column> ColumnList = new List<Column> (5);

}

/// <summary>
/// Enumeratore che definisce i possibili valori del Terrain type.
/// </summary>
public enum TerrainTypes { Empty, Elevated, Water, Ground };
