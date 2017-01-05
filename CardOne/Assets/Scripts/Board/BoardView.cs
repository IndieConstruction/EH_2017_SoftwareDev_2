using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BoardView : MonoBehaviour{
    public BoardData Data;
    public List<Column> Columns;
    public SpriteRenderer RendererToLoad;
    //public SpriteRenderer Empty;
    //public SpriteRenderer Elevated;
    //public SpriteRenderer Water;
    //public SpriteRenderer Ground;

    public void Init(BoardData _boardData){
        Data = _boardData;
        InitGraphic(_boardData);

    }
    public void InitGraphic(BoardData board_d) {

        foreach (Column citem in Columns)
        {
            if (citem.terrainType == TerrainTypes.Empty)
                RendererToLoad = board_d.Empty_image;
            if (citem.terrainType == TerrainTypes.Elevated)
                RendererToLoad = board_d.Elevated_image;
            if (citem.terrainType == TerrainTypes.Water)
                RendererToLoad = board_d.Water_image;
            if (citem.terrainType == TerrainTypes.Ground)
                RendererToLoad = board_d.Ground_image;
        }
    }

}



    