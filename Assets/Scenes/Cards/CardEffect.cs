using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardEffect : MonoBehaviour
{
    // public enum SpecialEffect {
    //     PRINT
    // }
    // public enum Element {
    //     WATER, FIRE, EARTH, WOOD, METAL
    // }
    public Card.SpecialEffect specialEffect = Card.SpecialEffect.PRINT;
    public Card.Element element = Card.Element.WATER;
    public int cardCost = 0;
    public int cardAttack = 0;

    private void Start() {
        Color color = Color.white;
        switch(this.element){
            case Card.Element.WATER:
                color = new Color32(156, 211, 219, 255);
                break;
            case Card.Element.FIRE:
                color = new Color32(226, 88, 34, 255);
                break;
            case Card.Element.EARTH:
                color = new Color32(128, 96, 67, 255);  
                break;
            case Card.Element.WOOD:
                color = new Color32(186, 140, 99, 255); 
                break;
            case Card.Element.METAL:
                color = new Color32(202, 204, 206, 255);  
                break;                                                                
        }
        this.GetComponent<Image>().color = color; 

        this.transform.Find("Panel").transform.Find("Cost").transform.GetComponent<Text>().text = this.cardCost.ToString();
    }

    private void applySpecialEffect() {
        switch(this.specialEffect){
            case Card.SpecialEffect.PRINT:
                Debug.Log(this.transform.name);
                break;
        }
    }

    private void moveCardToGraveyard() {
        Destroy(gameObject);
    }    

    public void playCard() {
        Debug.Log("Damage: " + this.cardAttack);
        this.applySpecialEffect();
        this.moveCardToGraveyard();
    }
}
