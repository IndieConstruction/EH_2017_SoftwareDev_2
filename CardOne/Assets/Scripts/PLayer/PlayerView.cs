﻿using UnityEngine;
using System.Collections.Generic;

public class PlayerView : MonoBehaviour {

    [HideInInspector]public PlayerData playerData;
    public string id;
    void Awake (){
        
	}


    public void Init(PlayerData _playerData)
    {
        playerData = _playerData;
        InitGraphic(_playerData);
    }

    public void InitGraphic(PlayerData pd)
    {
        /// TODO: PLayerView InitGraphic
      
        gameObject.GetComponentsInChildren<TextMesh>()[0].text = pd.Life.ToString();
        gameObject.GetComponentsInChildren<TextMesh>()[1].text = pd.Mana.ToString();
        gameObject.GetComponentsInChildren<SpriteRenderer>()[2].sprite = Resources.Load(playerData.ImageToLoad, typeof(Sprite)) as Sprite;


    }
}
