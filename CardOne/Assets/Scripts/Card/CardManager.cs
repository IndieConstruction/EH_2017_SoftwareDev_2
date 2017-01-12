using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    
    public PlayerView[] players;
    public List<Deck> decks;
    public CardView cardView;

   
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

    private void Awake(){
        players = FindObjectsOfType<PlayerView>();
    }
    /// <summary>
    /// assegna le carte ai mazzi 
    /// </summary>
    public void GiveCardsToDecks(int numberOfCards) {
        for (int i = 0; i < GetAllCards().Count; i++){
            if (i < numberOfCards){
                decks[0].cards.Add(GetAllCards()[i]);
            }
            if (i >= numberOfCards){
                decks[1].cards.Add(GetAllCards()[i]);
            }
        }
    }

    /// <summary>
    /// Gives the decks to the players
    /// </summary>
    public void GiveDeck(){
        foreach (PlayerView p in players)
        {
            for (int i = 0; i < decks.Count; i++)
            {
                // assegna i mazzi ai player
            }
        }
    }
    /// <summary>
    /// Give the cards to the players
    /// </summary>
    /// <param name="numberOfCards"></param>
    public void GiveCards(int numberOfCards) {

        foreach (PlayerView pv in players){
            for (int n = 0; n < numberOfCards; n++){
                List<CardData> cardsData = pv.GetComponentInChildren<Deck>().cards;
                int randomIndex = Random.Range(0, cardsData.Count);
                Instantiate(cardView);
                
                //cardView.gameObject.transform.position = new Vector3(0, pv.transform.position.y, 0);
                cardView.Init(cardsData[randomIndex]);
            }
           
         }
        }
    /// <summary>
    /// Quando prendo una carte da posizionare nella board,controllo se la posizione in cui il player vuole posizionarla e' corretta.
    /// </summary>
    public void DropCardInRightBoardPosition() {

    }
    }

