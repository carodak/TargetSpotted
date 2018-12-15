using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public static int numberItems = 0;

    public int teleportTrap = 2;

    //The world = ennemy and items
    public List<GameObject> ennemies = new List<GameObject>();
    public List<GameObject> items = new List<GameObject>();

    //Get the closest alcove to hide
    public List<GameObject> alcoves = new List<GameObject>();

    public bool ennemyNearby = false;

    // Use this for initialization
    void Start () {

        //Initialize 'alcoves' with the position of each alcove
        GameObject a = new GameObject();
        a.transform.position = new Vector3(-16.5f, -11.1f, -9.5f);
        alcoves.Add(a);
        GameObject b = new GameObject();
        b.transform.position = new Vector3(-8.5f, -11.1f, -9.5f);
        alcoves.Add(b);
        GameObject c = new GameObject();
        c.transform.position = new Vector3(-0.3f, -11.1f, -9.5f);
        alcoves.Add(c);
        GameObject d = new GameObject();
        d.transform.position = new Vector3(7.5f, -11.1f, -9.5f);
        alcoves.Add(d);
        GameObject e = new GameObject();
        e.transform.position = new Vector3(15.7f, -11.1f, -9.5f);
        alcoves.Add(e);
        GameObject f = new GameObject();
        f.transform.position = new Vector3(-16.5f, 11.1f, -9.5f);
        alcoves.Add(f);
        GameObject g = new GameObject();
        g.transform.position = new Vector3(-8.5f, 11.1f, -9.5f);
        alcoves.Add(g);
        GameObject h = new GameObject();
        h.transform.position = new Vector3(-0.3f, 11.1f, -9.5f);
        alcoves.Add(h);
        GameObject i = new GameObject();
        i.transform.position = new Vector3(7.5f, 11.1f, -9.5f);
        alcoves.Add(i);
        GameObject j = new GameObject();
        j.transform.position = new Vector3(15.7f, 11.1f, -9.5f);
        alcoves.Add(j);
    }
	
	// Update is called once per frame
	void Update () {

        //Initialise an array with all ennemies + the AI
        // ennemies = new GameObject[GameObject.Find("Ennemies").transform.childCount+1]; 

        ennemies.Clear();

        for (int i = 0; i < GameObject.Find("Ennemies").transform.childCount; i++)
        {
            ennemies.Add(GameObject.Find("Ennemies").transform.GetChild(i).gameObject);
        }

        //Get the closest gameobject
        GameObject closest = GetClosestEnemy();
        //Debug.Log("closest: " + closest);

        bool useTeleport = UseTeleport();

        //Use the teleport trap is space is pressed
        if (useTeleport && closest.name == "Player" && teleportTrap > 0)
        {
            int rand1 = Random.Range(1, 11);
            closest.GetComponent<AI>().Spawn(rand1);

            teleportTrap--;
        }

        if (useTeleport && closest.tag == "Ennemy" && teleportTrap > 0)
        {
            //Update the number on ennemies that are on the top or on the bottom
            if (closest.GetComponent<EnnemiesMovement>().GetIsTop() == true)
            {
                closest.GetComponent<EnnemiesMovement>().DecreaseOnTop();
            }

            else
            {
                closest.GetComponent<EnnemiesMovement>().DecreaseOnBottom();
            }

            //Destroy the ennemy
            Destroy(closest);
            teleportTrap--;

        }


        //Get the closest item
        items.Clear();

        for (int i = 0; i < GameObject.Find("Alcoves").transform.childCount; i++)
        {
            if(GameObject.Find("Alcoves").transform.GetChild(i).childCount>0){
                items.Add(GameObject.Find("Alcoves").transform.GetChild(i).gameObject.transform.GetChild(0).gameObject);
            }
                
        }

        if(ennemyNearby == false)
            MoveToPosition(GetClosestItem());


    }

    //Spawn randomly the AI in one of the 10 alcoves
    public void Spawn(int rand)
    {

        switch (rand)
        {
            case 1:
                gameObject.transform.position = new Vector3(-16.5f, -11.1f, -9.5f);
                break;
            case 2:
                gameObject.transform.position = new Vector3(-8.5f, -11.1f, -9.5f);
                break;

            case 3:
                gameObject.transform.position = new Vector3(-0.3f, -11.1f, -9.5f);
                break;

            case 4:
                gameObject.transform.position = new Vector3(7.5f, -11.1f, -9.5f);
                break;

            case 5:
                gameObject.transform.position = new Vector3(15.7f, -11.1f, -9.5f);
                break;

            case 6:
                gameObject.transform.position = new Vector3(-16.5f, 11.1f, -9.5f);
                break;

            case 7:
                gameObject.transform.position = new Vector3(-8.5f, 11.1f, -9.5f);
                break;

            case 8:
                gameObject.transform.position = new Vector3(-0.3f, 11.1f, -9.5f);
                break;

            case 9:
                gameObject.transform.position = new Vector3(7.5f, 11.1f, -9.5f);
                break;

            case 10:
                gameObject.transform.position = new Vector3(15.7f, 11.1f, -9.5f);
                break;


            default:
                Debug.Log("Error while the ennemy met the obstacle");


                break;
        }

    }

    //Get the closest ennemy
    GameObject GetClosestEnemy()
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in ennemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    //Get the closest item
    GameObject GetClosestItem()
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in items)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    //Get the closest alcove
    public GameObject GetClosestAlcove()
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        Debug.Log(currentPos);
        foreach (GameObject t in alcoves)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    bool UseTeleport(){
        int rand1 = Random.Range(1, 501);
        if (rand1 == 1){
            return true;
        }
        return false;
    }


    //Move the AI to the gameobject position (with A* algo)
    public void MoveToPosition(GameObject go){
        gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = go.transform;
    }

}
