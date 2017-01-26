using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// Fa tutte le cose che servono a visualizzare i dati nella carta.
/// </summary>
public class CardView : MonoBehaviour, IDropHandler, IDragHandler {
    #region Public Variables
    public CardData Data;
    public SpriteRenderer ImageToLoad;
    public PlayerView playerView;
    #endregion
    #region RunTime Variables
    ColumnView columnCollision;
    #endregion
    private void Start() {
        
    }
    /// <summary>
    /// Inizializza la view della card con i dati passati come parametro.
    /// </summary>
    /// <param name="_cardData"></param>
    public void Init(CardData _cardData) {
        Data = _cardData;
        UpdateGraphic(_cardData);
    }

    /// <summary>
    /// Sposto nel container delle carte in mano al player la cardb
    /// </summary>
    /// <param name="_player"></param>
    public void AllocateCardToPlayer(PlayerData _player) {
       playerView = GamePlayManager.I.GetPlayerViewFromData(_player);
       transform.SetParent(playerView.CardContainer, false);
    }


    /// <summary>
    /// Update degli elementi grafici.
    /// </summary>
    /// <param name="c"></param>
    public void UpdateGraphic(CardData c)
    {
        gameObject.GetComponentsInChildren<Text>()[0].text = c.Life.ToString();
        gameObject.GetComponentsInChildren<Text>()[1].text = c.Attack.ToString();
        gameObject.GetComponentsInChildren<Text>()[2].text = c.ManaCost.ToString();
        //ImageToLoad.sprite = c.CardSprite;   
    }

    public void OnDrop(PointerEventData eventData) {
        if (columnCollision != null) {

            columnCollision.PlaceCard(this);
        }
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        transform.position = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        ColumnView col = collision.GetComponent<ColumnView>();
        if (col != null) {
            columnCollision = col;
            col.Highlight(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        ColumnView col = collision.GetComponent<ColumnView>();
        if (col != null) {
            columnCollision = null;
            col.Highlight(false);
        }
    }
}


