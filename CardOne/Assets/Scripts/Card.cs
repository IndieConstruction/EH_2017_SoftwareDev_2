using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	public int ManaCost;
	public int Life;
	public int Strenght;



	public enum Slot{Roof, Water, Terrain, MyTable, Street}
	public Slot TypeOfTerrain = Slot.Roof;
}
