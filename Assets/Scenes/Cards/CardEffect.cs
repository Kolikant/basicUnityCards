using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    Vector3 cachedScale;

    public Card cardInstance = new Card(Card.Element.WATER, Card.SpecialEffect.PRINT, 0, 0);

    private void Start() {
        cachedScale = transform.localScale;

        Color color = Color.white;
        switch(this.cardInstance.element){
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

        this.transform.Find("Panel").transform.Find("Cost").transform.GetComponent<Text>().text = this.cardInstance.cardCost.ToString();
    }
 
     public void OnPointerEnter(PointerEventData eventData) {
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        this.gameObject.GetComponent<LayoutElement>().ignoreLayout = true;
        this.gameObject.GetComponent<Canvas>().sortingOrder++;
     }
 
     public void OnPointerExit(PointerEventData eventData) {
        this.transform.localScale = cachedScale;
        this.gameObject.GetComponent<LayoutElement>().ignoreLayout = false;
        this.gameObject.GetComponent<Canvas>().sortingOrder--;
     }

    private void applySpecialEffect() {
        switch(this.cardInstance.specialEffect){
            case Card.SpecialEffect.PRINT:
                Debug.Log(this.transform.name);
                break;
        }
    }

    // private void moveCardToGraveyard() {
    //     Destroy(gameObject);
    // }    

    public void playCard() {
        Debug.Log("Damage: " + this.cardInstance.cardAttack);
        this.applySpecialEffect();
        // this.moveCardToGraveyard();
    }
}
