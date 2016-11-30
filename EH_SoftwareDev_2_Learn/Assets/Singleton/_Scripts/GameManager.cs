using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

	// Use this for initialization
	void Start () {
        if(instance == null)
            instance = this;

        if (instance != this)
            Destroy(this.gameObject);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public string GameInfo() {
        return "MyGame v.1.0";
    }
}
