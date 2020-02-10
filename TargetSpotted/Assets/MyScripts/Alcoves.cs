using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alcoves : MonoBehaviour {

    private List<GameObject> alcoves = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        InitializeAlcoves();
    }

    //Initialize and save positions of alcoves
    public void InitializeAlcoves()
    {
        AddAlcoveToList(new Vector3(-16.5f, -11.1f, -9.5f));
        AddAlcoveToList(new Vector3(-8.5f, -11.1f, -9.5f));
        AddAlcoveToList(new Vector3(-0.3f, -11.1f, -9.5f));
        AddAlcoveToList(new Vector3(7.5f, -11.1f, -9.5f));
        AddAlcoveToList(new Vector3(15.7f, -11.1f, -9.5f));
        AddAlcoveToList(new Vector3(-16.5f, 11.1f, -9.5f));
        AddAlcoveToList(new Vector3(-8.5f, 11.1f, -9.5f));
        AddAlcoveToList(new Vector3(-0.3f, 11.1f, -9.5f));
        AddAlcoveToList(new Vector3(7.5f, 11.1f, -9.5f));
        AddAlcoveToList(new Vector3(15.7f, 11.1f, -9.5f));
    }

    //Create alcove gameobject at position and add it to the list of alcoves
    public void AddAlcoveToList(Vector3 position)
    {
        GameObject alcoveGO = new GameObject();
        alcoveGO.transform.position = position;
        alcoves.Add(alcoveGO);
    }

    public List<GameObject> GetAlcovesList()
    {
        return alcoves;
    }
}
