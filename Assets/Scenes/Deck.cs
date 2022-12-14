using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void presentDeck() {
        switch(gameObject.name) {
            case "Deck":
                for(int i = 0; i < cardBattleMainScript.deck.Count; i++) {
                    Debug.Log(JsonUtility.ToJson(cardBattleMainScript.deck[i], true));
                }
                break;
            case "Discard":
                for(int i = 0; i < cardBattleMainScript.discard.Count; i++) {
                    Debug.Log(JsonUtility.ToJson(cardBattleMainScript.discard[i], true));
                }         
                break;
        }
    }
}
