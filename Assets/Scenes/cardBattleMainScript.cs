using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class cardBattleMainScript : MonoBehaviour
{
    public GameObject cardPrefab;
    int deckSize = 5;
    List<Card> deck = new List<Card>();
    List<Card> hand = new List<Card>();
    List<Card> discard = new List<Card>();

    // Start is called before the first frame update
    void Start() {
        generateDeck();
    }

    // Update is called once per frame
    void Update()
    {
        updateCardAmountDisplay();
        if(Input.GetKeyDown(KeyCode.Space)) {
            this.drawCardFromDeck();
        }
    }

    //DisplayUpdates
    void updateCardAmountDisplay() {
        GameObject.Find("Deck").transform.Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text = this.deck.Count.ToString();
        GameObject.Find("Discard").transform.Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text = this.discard.Count.ToString();
    }

    //Logic
    void generateDeck() {
        for(int i = 0; i < this.deckSize; i++) {
            System.Random random = new System.Random();
            
            var values = Enum.GetValues(typeof(Card.Element));
            Card.Element element = (Card.Element)(values).GetValue(random.Next(values.Length));    
            
            values = Enum.GetValues(typeof(Card.SpecialEffect));
            Card.SpecialEffect specialEffect = (Card.SpecialEffect)(values).GetValue(random.Next(values.Length));    
            
            values = Enumerable.Range(0, 10).ToArray();
            int cost = (int)(values).GetValue(random.Next(values.Length));    

            values = Enumerable.Range(1, 5).ToArray();
            int attack = (int)(values).GetValue(random.Next(values.Length));    

            Debug.Log("" + element + " " + specialEffect + " " + cost + " " + attack);
            this.deck.Add(new Card(element, specialEffect, cost, attack));
        }
    }

    void drawCardFromDeck() {
        if(this.deck.Count > 0) {
            GameObject newCardPrefabInstance = Instantiate(cardPrefab);
            
            Card drawnCardObject = deck[0];
            this.hand.Add(drawnCardObject);
            this.deck.RemoveAt(0);

            newCardPrefabInstance.GetComponent<CardEffect>().element = drawnCardObject.element;   
            newCardPrefabInstance.GetComponent<CardEffect>().specialEffect = drawnCardObject.specialEffect;   
            newCardPrefabInstance.GetComponent<CardEffect>().cardCost = drawnCardObject.cardCost;

            newCardPrefabInstance.transform.SetParent(GameObject.Find("Hand").transform);
        }
    }
}
