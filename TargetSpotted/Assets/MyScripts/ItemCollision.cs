using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to handle Items collision with agents

public class ItemCollision : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "AIBodyCollider")
        {
            AI ai = UpdateAiItems(coll);

            DestroyItem();
            Debug.Log("AI has " + ai.GetNumberItems() + "items");
        }

        if (coll.gameObject.name == "PlayerBodyCollider")
        {
            Player player = UpdatePlayerItems(coll);

            DestroyItem();
            Debug.Log("Player has " + player.GetNumberItems() + "items");
        }

    }

    //Update the nb of items the player got
    public Player UpdatePlayerItems(Collider2D coll)
    {
        Player player = coll.transform.parent.GetComponent<Player>();
        player.IncreaseNbItems();
        return player;
    }

    //Update the nb of items the AI got
    public AI UpdateAiItems(Collider2D coll)
    {
        AI ai = coll.transform.parent.GetComponent<AI>();
        ai.IncreaseNbItems();
        return ai;
    }

    //Destroy item
    public void DestroyItem()
    {
        Items item = transform.parent.parent.parent.GetComponent<Items>();
        item.RemoveItemFromList(transform.parent.gameObject);
        Destroy(transform.parent.gameObject);
    }
}
