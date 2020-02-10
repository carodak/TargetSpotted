using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    private List<GameObject> items = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        AddItemsToList();

    }

    //Add each items to the list
    public void AddItemsToList()
    {
        items.Clear();

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).childCount > 0)
            {
                items.Add(gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject);
            }

        }
    }

    //Add each items to the list
    public void RemoveItemFromList(GameObject item)
    {
        items.Remove(item);
    }

    public List<GameObject> GetListItems()
    {
        return items;
    }
}
