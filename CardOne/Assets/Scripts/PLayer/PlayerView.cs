using UnityEngine;
using System.Collections.Generic;

public class PlayerView : MonoBehaviour {

    #region prova
    public List<CardView> cardsInScene;
    public List<SpawnPoint> cardsSpawnPoints;
    #endregion


    public PlayerData playerData;
    public string id;
    void Awake (){
        SpawnPoint[] spawn = FindObjectsOfType<SpawnPoint>();
        for (int i = 0; i < spawn.Length; i++)
        {
            if (id == spawn[i].id)
            {
                cardsSpawnPoints.Add(spawn[i]);
            }

        }
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
        /// gameObject.GetComponentsInChildren<SpriteRenderer>()[2].sprite = pd.PlayerSprite.sprite;

    }
}
