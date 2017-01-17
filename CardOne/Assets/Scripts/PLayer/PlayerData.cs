using UnityEngine;
using System.Collections;


[CreateAssetMenu(fileName = "PlayerDataInfo", menuName = "Player/PlayerData", order = 1)]
public class PlayerData : ScriptableObject{
    public string id; 
    public Sprite PlayerImage;
    private int mana = 1;

    public int Mana {
        get { return mana; }
        set {
            if (OnDataChanged != null)
                OnDataChanged();
            mana = value;
        }
    }

    private int life = 20;

    public int Life {
        get { return life; }
        set {
            if (OnDataChanged != null)
                OnDataChanged();
            life = value;
        }
    }

    #region Events
    public delegate void DataEvent();

    public DataEvent OnDataChanged;
    #endregion

}
