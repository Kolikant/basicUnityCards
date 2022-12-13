using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class cardBattleMainScript : MonoBehaviour
{
    public GameObject cardPrefab;
    int deckAmount = 20;
    int discardAmount = 0;

    // Start is called before the first frame update
    void Start() {
        generateDeck();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            this.drawCard();
        }
    }

    void generateDeck() {

    }

    void drawCard() {
        GameObject newCard = Instantiate(cardPrefab);
        System.Random random = new System.Random();
        
        var values = Enum.GetValues(typeof(CardEffect.Element));
        newCard.GetComponent<CardEffect>().element = (CardEffect.Element)(values).GetValue(random.Next(values.Length));    
        
        values = Enum.GetValues(typeof(CardEffect.SpecialEffect));
        newCard.GetComponent<CardEffect>().specialEffect = (CardEffect.SpecialEffect)(values).GetValue(random.Next(values.Length));    
        
        values = Enumerable.Range(0, 10).ToArray();
        newCard.GetComponent<CardEffect>().cardCost = (int)(values).GetValue(random.Next(values.Length));    

        newCard.transform.SetParent(GameObject.Find("Hand").transform);
    }
}
