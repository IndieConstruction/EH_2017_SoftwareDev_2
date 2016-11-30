
public class Enemy {

    public int Life;
    public static int EnemiesCounter;
    EnemyClass enemyClass;

    public Enemy(EnemyClass _enemyType) {
        enemyClass = _enemyType;
        EnemiesCounter = EnemiesCounter + 1;
        Life = EnemyHelper.GetInitialLifeByElementType(enemyClass);
        
        
        switch (enemyClass) {
            case EnemyClass.orco:
                // ........... Orco
                break;
            case EnemyClass.goblin:
                // ........... Enemy
                break;
            default:
                break;
        }


    }

    public void function1() {
        Enemy.function2();
    }

    public static void function2() {

    }

}

public enum EnemyClass {
    orco,
    goblin
}