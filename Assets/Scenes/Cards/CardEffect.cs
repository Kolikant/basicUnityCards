using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    public enum SpecialEffect {
        PRINT
    }
    [SerializeField] int cardAttak = 0;
    [SerializeField] SpecialEffect specialEffect = SpecialEffect.PRINT;

    private void applySpecialEffect() {
        switch(this.specialEffect){
            case SpecialEffect.PRINT:
                Debug.Log(this.transform.name);
                break;
        }
    }

    private void moveCardToGraveyard() {
        Destroy(gameObject);
    }    

    public void playCard() {
        Debug.Log("Damage: " + this.cardAttak);
        this.applySpecialEffect();
        this.moveCardToGraveyard();
    }
}
