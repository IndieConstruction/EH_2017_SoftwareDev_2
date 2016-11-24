using UnityEngine;
using System.Collections;

public class StaticTester : MonoBehaviour {

    Enemy enemy1;
    Enemy enemy2; 
    Enemy enemy3; 
    Enemy enemy4;

    // Use this for initialization
    void Start () {

        enemy1 = new Enemy(EnemyClass.orco);
        enemy2 = new Enemy(EnemyClass.orco);
        enemy3 = new Enemy(EnemyClass.goblin);
        enemy4 = new Enemy(EnemyClass.orco);

        
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.D)) {
            EnemyToDamage.Life = EnemyToDamage.Life - DamageAmount;
        }
    }

    public EnemyView EnemyToDamage;
    public int DamageAmount = 4;

    

    
}
