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
    public List<Image> ColumsImages;


    public void Init(BoardData _boardData){
        Data = _boardData;
        InitGraphic(_boardData);

    }
    public void InitGraphic(BoardData _boardData) {

        //if (TerrainType == TerrainTypes.Empty){
        //    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load( ImageToLoad , typeof(Sprite)) as Sprite;
        //}
        //if (TerrainType == TerrainTypes.Elevated){
        //    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(ImageToLoad, typeof(Sprite)) as Sprite;
        //}
        //if (TerrainType == TerrainTypes.Water){
        //    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(ImageToLoad, typeof(Sprite)) as Sprite;
        //}
        //if (TerrainType == TerrainTypes.Ground){
        //    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(ImageToLoad, typeof(Sprite)) as Sprite;
        //}
        int i = 0;
        foreach (var col in _boardData.ColumnList) {
            switch (col.terrainType) {
                case TerrainTypes.Empty:
                    ColumsImages[i].sprite = Resources.Load<Sprite>("Empty");
                    break;
                case TerrainTypes.Elevated:
                    ColumsImages[i].sprite = Resources.Load<Sprite>("Elevated");
                    break;
                case TerrainTypes.Water:
                    ColumsImages[i].sprite = Resources.Load<Sprite>("Water");
                    break;
                case TerrainTypes.Ground:
                    ColumsImages[i].sprite = Resources.Load<Sprite>("Ground");
                    break;
                default:
                    break;
            }
            i++;
        }

        //foreach (Column citem in Columns)
        //{
        //    if (citem.terrainType == TerrainTypes.Empty)
        //        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Empty_512x512_Tex", typeof(Sprite)) as Sprite;
        //    if (citem.terrainType == TerrainTypes.Elevated)
        //        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Elevated_512x512_Tex", typeof(Sprite)) as Sprite;
        //    if (citem.terrainType == TerrainTypes.Water)
        //        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Water_512x512_Tex", typeof(Sprite)) as Sprite;
        //    if (citem.terrainType == TerrainTypes.Ground)
        //        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Ground_512x512_Tex", typeof(Sprite)) as Sprite;

        // }
    }
    }



    