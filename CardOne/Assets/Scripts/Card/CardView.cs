﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// Fa tutte le cose che servono a visualizzare i dati nella carta.
/// </summary>
public class CardView : MonoBehaviour, IBeginDragHandler, IDropHandler, IDragHandler{
    #region Public Variables
    public CardData Data;
    public SpriteRenderer ImageToLoad;
    public PlayerView playerView;
    #endregion
    #region RunTime Variables
    Transform parentToReturnTo = null;
    ColumnView columnCollision;
    bool isDraggable;
    #endregion
    #region Events
    public delegate void CardEvent(CardView _cardView);

    public static CardEvent OnBeginDragCard;
    public static CardEvent OnDragCard;
    public static CardEvent OnDropCard;
    #endregion

    private void OnEnable() {
        StateMachineBase.OnStateChanged += OnStateChanged;
    }

    private void OnStateChanged() {
        UpdateGraphic(Data);
        if (Data.Life <= 0)
        {
            if (this)
            {
                this.gameObject.SetActive(false); 
            }
        }
    }

    private void OnDisable() {

    }

    private void Start() {
        
    }
    /// <summary>
    /// Inizializza la view della card con i dati passati come parametro.
    /// </summary>
    /// <param name="_cardData"></param>
    public void Init(CardData _cardData) {
        Data = _cardData;
        UpdateGraphic(_cardData);
        isDraggable = true;
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
        if (c != null)
        {
            if (this != null)
            {
                gameObject.GetComponentsInChildren<Text>()[0].text = c.Life.ToString();
                gameObject.GetComponentsInChildren<Text>()[1].text = c.Attack.ToString();
                gameObject.GetComponentsInChildren<Text>()[2].text = c.ManaCost.ToString(); 
            }
            //ImageToLoad.sprite = c.CardSprite;   
        } 
    }

    #region Drop
    public void OnDrop(PointerEventData eventData) {
        if (OnDropCard != null)
        OnDropCard(this);
    }
    public void DoDrop() {
        if (columnCollision != null && playerView.playerData.Mana >= Data.ManaCost) {

            columnCollision.PlaceCard(this, playerView.playerData);
            parentToReturnTo = null;
            playerView.playerData.Mana -= Data.ManaCost;
            isDraggable = false;
        }
        else
        {
            this.transform.SetParent(parentToReturnTo);

        }
    }
    #endregion

    #region Drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragCard != null)
            OnBeginDragCard(this);
    }
    /// <summary>
    /// funzione che viene chiamata quando si tenta di fare un drag
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData) {
        if (OnDragCard != null)
        OnDragCard(this);

    }
    /// <summary>
    /// la carta segue il mouse
    /// </summary>
    public void DoDrag() {
        //if (columnCollision == null)
        //{

        if (isDraggable)
        {
            transform.position = Input.mousePosition;   
        }
       
       // }
    }

   public void DoBeginDrag() {
        if (isDraggable)
        {
            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent); 
        }
    }
    #endregion

    #region Collisioni

    /// <summary>
    /// se la carta collide con una colonna riempie la variabile columnCollision
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision) {
        ColumnView col = collision.GetComponent<ColumnView>();
        if (col != null) {
            columnCollision = col;
            col.Highlight(true);
        }
    }
    /// <summary>
    /// se la carta non collide più con la colonna, mette a null la variabile columnCollision
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision) {
        ColumnView col = collision.GetComponent<ColumnView>();
        if (col != null) {
            columnCollision = null;
            col.Highlight(false);
        }
    }
    #endregion
    private void Update() {
       // UpdateGraphic(Data);
    }
}


