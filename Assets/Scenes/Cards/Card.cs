using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card {
    public enum SpecialEffect {
        PRINT
    }
    public enum Element {
        WATER, FIRE, EARTH, WOOD, METAL
    }
    public SpecialEffect specialEffect;
    public Element element;
    public int cardCost;
    public int cardAttack;    

    public Card(string name) {
    }

    public Card(Element element, SpecialEffect specialEffect, int cardCost, int cardAttack) {
        this.element = element;
        this.specialEffect = specialEffect;
        this.cardCost = cardCost;
        this.cardAttack = cardAttack;
    }
}
