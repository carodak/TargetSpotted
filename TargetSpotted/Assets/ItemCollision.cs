using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If the agent called "AI" or the player is on the item -> destroy the item and increment their number of items

public class ItemCollision : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "AIBodyCollider")
        {
            AI.numberItems++;
            Agents.numberItemsAI++;
            Destroy(transform.parent.gameObject);
            Debug.Log("Agent has " + AI.numberItems + "items");
        }

        if (coll.gameObject.name == "PlayerBodyCollider")
        {
            Player.numberItems++;
            Agents.numberItemsPlayer++;
            Destroy(transform.parent.gameObject);
            Debug.Log("Player has " + Player.numberItems + "items");
        }

    }
}
