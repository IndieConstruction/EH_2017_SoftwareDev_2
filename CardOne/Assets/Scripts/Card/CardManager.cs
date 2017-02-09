using UnityEngine;
using System.Linq;
using System.Collections.Generic;
/// <summary>
/// Si occupa di tutto quello che riguarda le carte nel gioco.
/// </summary>
public class CardManager : MonoBehaviour {
    
    /// <summary>
    /// Prefab per la costruzione della cardView.
    /// </summary>
    public CardView cardViewPrefab;
    
    /// <summary>
    /// Prende tutte le carte che stanno nella cartella Resources/Cards
    /// </summary>
    /// <returns></returns>
    public static List<CardData> GetAllCards() {
        CardData[] allCardsfromResources = Resources.LoadAll<CardData>("Cards");
        List<CardData> newCardList = new List<CardData>();
        foreach (CardData cardPointer in allCardsfromResources) {
            newCardList.Add(new CardData {

                ID = cardPointer.ID,
                Attack = cardPointer.Attack,
                Life = cardPointer.Life,
                Type = cardPointer.Type,
                CardSprite = cardPointer.CardSprite,
                ManaCost = cardPointer.ManaCost,
                SlotType = cardPointer.SlotType,

            }
            );
        }
        return newCardList;
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
    
    /// <summary>
    /// Assegna le carte ai mazzi 
    /// </summary>
    /// <param name="numberOfCards">Numero di carte da dare per ogni mazzo dei player</param>
    public void GiveCardsToDecks(int numberOfCards) {
        //Ripete per il numberOfCards la scelta della carta Ranom e l'assegna al deck di ogni Player
        for (int i = 0; i < numberOfCards; i++) {
            int RandomInd = Random.Range(0, GetAllCards().Count);
            CardData newCard = GetAllCards()[RandomInd];
            GamePlayManager.I.Players[0].Deck.Add(newCard);
        }
        for (int i = 0; i < numberOfCards; i++) {
            int RandomInd = Random.Range(0, GetAllCards().Count);
            CardData newCard = GetAllCards()[RandomInd];
            GamePlayManager.I.Players[1].Deck.Add(newCard);
        }
    }

    
    
}

