using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BoardView : MonoBehaviour{
    [HideInInspector] public BoardData Data;
    //[HideInInspector] public List<Column> Columns;
    public TerrainTypes TerrainType;
    public string ImageToLoad;
    public PlayerSlotType CardPositionForPlayer;
    public List<ColumnView> ColsView;


    public void Init(BoardData _boardData){
        List<ColumnData> newInstanceOfColums = new List<ColumnData>();
        foreach (ColumnData cData in _boardData.ColumnList) {
            newInstanceOfColums.Add(new ColumnData() { cards = cData.cards, terrainType = cData.terrainType });
        }
        Data = new BoardData (){ColumnList = newInstanceOfColums };
        InitGraphic(Data);

    }
    public void InitGraphic(BoardData _boardData) {

        int i = 0;
        foreach (var colData in _boardData.ColumnList) {
            ColsView[i].Init(colData);
            i++;
        }

    }
    }



    