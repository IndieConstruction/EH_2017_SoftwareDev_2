using UnityEngine;
using System.Collections;

public class EnemyView : MonoBehaviour {

    Enemy EnemyModel;
    public TextMesh LifeLable;
    public EnemyClass Class;

    public int Life {
        get { 
            return EnemyModel.Life;
        }
        set {
            if (EnemyModel.Life == value)
                return;
            EnemyModel.Life = value;
            /////
            // OnChange value ractions
            LifeLable.text = Life.ToString();
            /////
        }
    }


    // Use this for initialization
    void Start () {
	    EnemyModel = new Enemy(Class);
        LifeLable.text = EnemyModel.Life.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
