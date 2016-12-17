using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int Mana;
	public int Life;
	public bool MyTurn;
	
	void Awake (){
		
	}

	// Use this for initialization
	void Start () {
		GamePlayManager.gpm.Players.Add (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
