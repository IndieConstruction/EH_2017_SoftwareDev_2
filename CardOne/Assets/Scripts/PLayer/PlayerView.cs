using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour {
    public Text Mana, Life;
    public Image PlayerImage;

    PlayerData playerData;

    public void Init(PlayerData _playerData){
        playerData = _playerData;
        playerData.OnDataChanged = null;
        playerData.OnDataChanged += dataChanged;
        UpdateGraphic(_playerData);
        PlayerImage.sprite = _playerData.PlayerImage;

    }

    public void UpdateGraphic(PlayerData pd){
        Life.text = pd.Life.ToString();
        Mana.text = pd.Mana.ToString();
        
    }

    #region Event subscriptions
    private void OnEnable() {
        
    }

    void dataChanged() {
        UpdateGraphic(playerData);
    }

    private void OnDisable() {
        if(playerData != null)
            playerData.OnDataChanged = null;
    } 
    #endregion

}
