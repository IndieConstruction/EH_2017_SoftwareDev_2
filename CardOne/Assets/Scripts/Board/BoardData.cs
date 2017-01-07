using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Classe che contiene le informazioni riguardanti la board di gioco
/// </summary>
[System.Serializable]
public class BoardData : ScriptableObject
{
    public List<Column> ColumnList = new List<Column> (5);
        //public SpriteRenderer Empty_image;
        //public SpriteRenderer Elevated_image;
        //public SpriteRenderer Water_image;
        //public SpriteRenderer Ground_image;
}

/// <summary>
/// Enumeratore che definisce i possibili valori del Terrain type.
/// </summary>
public enum TerrainTypes { Empty, Elevated, Water, Ground };
/// <summary>
/// Enumeratore che definische dove i player possono posizionare la carta nella board durante la fase strategica
/// </summary>
public enum PlayerSlotType{Player1,Player2};
