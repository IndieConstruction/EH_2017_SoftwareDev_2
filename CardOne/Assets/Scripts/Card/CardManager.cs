using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class CardManager : MonoBehaviour {

    public PlayerView[] players;
    public CardView cardView;
    
    /// <summary>
    /// Prende tutte le carte che stanno nella cartella Resources/Cards
    /// </summary>
    /// <returns></returns>
    public static List<CardData> GetAllCards() {
        CardData[] allCards = Resources.LoadAll<CardData>("Cards");
        return allCards.ToList<CardData>();
        // Vecchio sistema con creazione manuale dei dati.
        //return new List<CardData>() {
        //    new CardData() { ID = "Monster1", ManaCost = 1, Type = CardType.Base, SlotType = Slot.Terrain, Life = 1, Attack = 1 },
        //    new CardData() { ID = "Monster Block", ManaCost = 1, Type = CardType.Base, SlotType = Slot.Terrain, Life = 1, Attack = 0 },
        //    new CardData() { ID = "Hero Attack", ManaCost = 2, Type = CardType.Effect, SlotType = Slot.Terrain, Life = 0, Attack = 3 },
        //};

        // L'arrayList della classe Cardata va a pescare 
        //          i dati(scriptableObject) nella directory tramite
        //          la lettura delle risorse(Resources)
    }

    private void Awake() {
        players = FindObjectsOfType<PlayerView>();
    }
    /// <summary>
    /// Assegna le carte ai mazzi 
    /// </summary>
    /// <param name="numberOfCards">Numero di carte da dare per ogni mazzo dei player</param>
    public void GiveCardsToDecks(int numberOfCards) {
        //Ripete per il numberOfCards la scelta della carta Ranom e l'assegna al deck di ogni Player
        for (int i = 0; i < numberOfCards; i++) {
            int RandomInd = Random.Range(0, GetAllCards().Count);
            CardData newCard = GetAllCards()[RandomInd];
            GamePlayManager.Istance.Players[0].Deck.Add(newCard);
        }
        for (int i = 0; i < numberOfCards; i++) {
            int RandomInd = Random.Range(0, GetAllCards().Count);
            CardData newCard = GetAllCards()[RandomInd];
            GamePlayManager.Istance.Players[1].Deck.Add(newCard);
        }
    }

    
    
}

