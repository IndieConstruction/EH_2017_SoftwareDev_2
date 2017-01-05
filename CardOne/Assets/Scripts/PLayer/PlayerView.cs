using UnityEngine;
using System.Collections.Generic;

public class PlayerView : MonoBehaviour {

    public PlayerData playerData;
    public string id;
    void Awake (){
        
	}

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void Init(PlayerData _playerData)
    {
        playerData = _playerData;
        InitGraphic();
    }

    public void InitGraphic()
    {
        /// TODO: PLayerView InitGraphic
        /// - Visualizzare la label con l'id del PLayer
        /// - Visualizzare la life
        /// - Attack
        /// ...

    }
}
