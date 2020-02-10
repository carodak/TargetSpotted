using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherence: Parent class and 2 specialised Agents (AI and Player)
abstract public class Agents: MonoBehaviour {

    protected int nbItems = 0; //number of items that the agent has
    public int alcoveNumber; //get the number of the alcove where the agent spawn
    protected int teleportTrap = 2; //number of teleport trap

    public bool isAlive = true;

    //Get the closest alcove
    [SerializeField]
    public Alcoves alcoves;

    //Get closest item
    [SerializeField]
    public Items items;

    //get closest enemy
    [SerializeField]
    public Ennemies ennemies;

    [SerializeField]
    public GameObject[] spawns;

    //Get closest gameobject
    protected GameObject closest;

    // Use this for initialization
    void Start ()
    {
        ennemies = ennemies.GetComponent<Ennemies>();
        SetAlcoveNumber();
        Spawn(alcoveNumber);
    }

    //Spawn randomly the agent in one of the 10 alcoves
    public virtual void Spawn(int rand)
    {
        Vector3 pos = spawns[rand].transform.position;
        gameObject.transform.position = new Vector3(pos.x, pos.y, gameObject.transform.position.z);

    }

    //Agent and AI have 10 positions for spawning (10 alcoves)
    protected virtual int GetRandomPosition()
    {
        return Random.Range(0, 10);
    }

    

    //Get closest gameobject that is in list
    protected virtual GameObject GetClosestGameObject(List<GameObject> list)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;//really small
        Vector3 currentPos = transform.position;

        foreach (GameObject t in list)
        {
            float dist = GetDistance(currentPos, t);

            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        closest = tMin;
        return tMin;
    }

    //Get distance between current position and position of t
    public float GetDistance(Vector3 currentPos, GameObject t)
    {
        return Vector3.Distance(t.transform.position, currentPos);
    }


    //If teleport trap is used, respawn the agent or destroy an enemy
    protected virtual void UseTeleportTrap()
    {
        //Use the teleport trap 
        if (closest.tag == "Agent" && teleportTrap > 0)
        {
            ReSpawnAgent();
            teleportTrap--;
        }

        else if (closest.tag == "Ennemy" && teleportTrap > 0)
        {
            ennemies.DecreaseNbEnemies(closest);
            //Destroy the ennemy
            DestroyClosestEnemy();
            teleportTrap--;

        }
    }

    //Destroy closest enemy
    public virtual void DestroyClosestEnemy()
    {
        ennemies.RemoveOpponentFromList(closest);
        Destroy(closest);
    }

    //ReSpawn selected agent
    protected abstract void ReSpawnAgent();

    //Set alcove number where the agent will spawn
    protected abstract void SetAlcoveNumber();

    //Get closest agent or closest enemy
    public abstract GameObject GetClosestAgentOrEnemy();

    public virtual int GetNumberItems()
    {
        return nbItems;
    }

    //Increase the number of collected items
    public virtual void IncreaseNbItems()
    {
        nbItems++;
    }


    // Update is called once per frame
    void Update () {

    }
}
