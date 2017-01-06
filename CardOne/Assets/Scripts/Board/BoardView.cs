using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BoardView : MonoBehaviour{
    public BoardData Data;
    public List<Column> Columns;
    public TerrainTypes TerrainType;

    private void Awake()
    {
        Init(Data);
    }
    public void Init(BoardData _boardData){
        Data = _boardData;
        InitGraphic(_boardData);

    }
    public void InitGraphic(BoardData board_d) {

        if (TerrainType == TerrainTypes.Empty){
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Empty_512x512_Tex", typeof(Sprite)) as Sprite;
        }
        if (TerrainType == TerrainTypes.Elevated){
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Elevated_512x512_Tex", typeof(Sprite)) as Sprite;
        }
        if (TerrainType == TerrainTypes.Water){
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Water_512x512_Tex", typeof(Sprite)) as Sprite;
        }
        if (TerrainType == TerrainTypes.Ground){
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Ground_512x512_Tex", typeof(Sprite)) as Sprite;
        }
    }

}



    