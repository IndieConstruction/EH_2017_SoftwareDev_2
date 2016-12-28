using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BoardView : MonoBehaviour{
    public BoardData Data;
    public List<Column> Colums;
    public SpriteRenderer RendererToLoad;
    //public SpriteRenderer Empry;
    //public SpriteRenderer Elevated;
    //public SpriteRenderer Water;
    //public SpriteRenderer Ground;

    public void Init(BoardData _boardData){
        Data = _boardData;
        InitGraphic(0);
    }
    public void InitGraphic(int _spriteToLoad) {
        /// TODO: CardView InitGraphic
        /// - Visualizzare la label con l'id della carta
        /// - Visualizzare la life
        /// - Attack
        /// ...
    }

    }



    