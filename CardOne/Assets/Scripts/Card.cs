using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	public int ManaCost;
	public int Life;
	public int Strenght;
    public string Name;
	public enum Slot{Roof, Water, Terrain, MyTable, Street};
    public Slot TypeOfTerrain;


    public Card(int Strenght, int Life, int ManaCost, string Name, Slot TypeOfTerrain)
    {
        this.Strenght = Strenght;
        this.Life = Life;
        this.ManaCost = ManaCost;
        this.Name = Name;
        this.TypeOfTerrain = TypeOfTerrain;
    }

}
