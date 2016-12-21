using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "LevelInfoData", menuName = "Level/LevelInfo", order = 1)]
public class LevelInfo : ScriptableObject {

    public string Name;
    public LevelTypes LevelType;
    public Color LevelColor;

    public enum LevelTypes { Type1, Type2, }
}
