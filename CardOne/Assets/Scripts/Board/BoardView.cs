using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BoardView : MonoBehaviour{
    public BoardData Data;
    public List<Column> Colums;
    public SpriteRenderer RendererToLoad;
    //public SpriteRenderer Empty;
    //public SpriteRenderer Elevated;
    //public SpriteRenderer Water;
    //public SpriteRenderer Ground;

    public void Init(BoardData _boardData){
        Data = _boardData;
        InitGraphic(0);
    }
    public void InitGraphic(int _spriteToLoad) {
     
    }

    }



    