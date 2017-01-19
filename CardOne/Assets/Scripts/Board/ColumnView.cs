using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnView : MonoBehaviour {

    #region Runtime variables
    ColumnData data; 
    #endregion

    #region Public Variables
    public Image BackgroundSprite;
    public Transform SlotP1, SlotP2; 
    #endregion

    /// <summary>
    /// inizializzazione del componente
    /// </summary>
    public void Init(ColumnData _data) {
        data = _data;
        switch (data.terrainType) {
            case TerrainTypes.Empty:
                BackgroundSprite.sprite = Resources.Load<Sprite>("Empty");
                break;
            case TerrainTypes.Elevated:
                BackgroundSprite.sprite = Resources.Load<Sprite>("Elevated");
                break;
            case TerrainTypes.Water:
                BackgroundSprite.sprite = Resources.Load<Sprite>("Water");
                break;
            case TerrainTypes.Ground:
                BackgroundSprite.sprite = Resources.Load<Sprite>("Ground");
                break;
            default:
                break;
        }
    } 
    /// <summary>
    /// Evidenzia l'elemento se la bool passata come parametro è vero
    /// </summary>
    /// <param name="highlighted"></param>
    public void Highlight (bool highlighted) {
        if (highlighted)
            BackgroundSprite.color = Color.gray;
        else
            BackgroundSprite.color = Color.white;
    }

    public void PlaceCard(CardView card) {
        if (GamePlayManager.Instance.GetPlayerNumber(card.playerView.playerData) == 1) {
            //è una carta del player 1
            card.transform.SetParent(SlotP1);
            card.transform.localPosition = Vector2.zero;
        }
        else {
            //è una carta del player 2
            card.transform.SetParent(SlotP2);
            card.transform.localPosition = Vector2.zero;
            
        }
        
        
    }
}
