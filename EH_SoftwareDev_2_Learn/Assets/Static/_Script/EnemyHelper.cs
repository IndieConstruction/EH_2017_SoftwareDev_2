public class EnemyHelper {

    static int baseLif = 0;
    int baseExp = 1;

    public static int GetInitialLifeByElementType(EnemyClass _enemyClass) {
        switch (_enemyClass) {
            case EnemyClass.orco:
                return 30;
            case EnemyClass.goblin:
                return 10;
            default:
                return baseLif;
        }
    }

    public  int GetExp() {
        return baseExp;
    }

}
