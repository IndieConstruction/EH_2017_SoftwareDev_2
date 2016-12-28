using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "PlayerDataInfo", menuName = "Player/PlayerData", order = 1)]
public class PlayerData : ScriptableObject{

    public int Mana;
    public int Life;
    public bool MyTurn;

}
