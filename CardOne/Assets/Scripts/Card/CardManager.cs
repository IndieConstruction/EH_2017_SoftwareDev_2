using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class CardManager {

    public static List<CardData> GetAllCards() {
        // Vecchio sistema con creazione manuale dei dati.
        //return new List<CardData>() {
        //    new CardData() { ID = "Monster1", ManaCost = 1, Type = CardType.Base, SlotType = Slot.Terrain, Life = 1, Attack = 1 },
        //    new CardData() { ID = "Monster Block", ManaCost = 1, Type = CardType.Base, SlotType = Slot.Terrain, Life = 1, Attack = 0 },
        //    new CardData() { ID = "Hero Attack", ManaCost = 2, Type = CardType.Effect, SlotType = Slot.Terrain, Life = 0, Attack = 3 },
        //};

        // L'arrayList della classe Cardata va a pescare 
        //          i dati(scriptableObject) nella directory tramite
        //          la lettura delle risorse(Resources)
        CardData[] allCards = Resources.LoadAll<CardData>("Cards");
        return allCards.ToList<CardData>();

    }

}
