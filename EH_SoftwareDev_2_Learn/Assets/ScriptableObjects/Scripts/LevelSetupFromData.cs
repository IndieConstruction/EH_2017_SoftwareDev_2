using UnityEngine;
using System.Collections.Generic;

public class LevelSetupFromData : MonoBehaviour {

    public List<LevelInfo> LevelsData;

	// Use this for initialization
	void Start () {
        foreach (LevelInfo levelData in LevelsData) {
            Debug.LogFormat("Level {0}", levelData.Name);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
