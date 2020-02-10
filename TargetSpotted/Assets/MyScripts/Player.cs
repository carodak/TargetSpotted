using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agents {

    [SerializeField]
    public AI ai;

    //Get inherited attributes
    public Player()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
    }

    //Set alcove number where the player will spawn
    protected override void SetAlcoveNumber()
    {
        alcoveNumber = GetRandomPosition();

        while (ai.GetComponent<AI>().alcoveNumber == alcoveNumber)
        {
            alcoveNumber = GetRandomPosition();
        }
    }

    public override void Spawn(int rand)
    {
        base.Spawn(rand);
    }

    //Get Closest Agent or Enemy
    public override GameObject GetClosestAgentOrEnemy()
    {
        List<GameObject> list = ennemies.GetComponent<Ennemies>().GetEnnemiesList();
        if (ai != null)
            list.Add(ai.transform.GetChild(0).gameObject);
        GameObject gO = GetClosestGameObject(list);
        return gO;
    }

    // Update is called once per frame
    void Update () {


        //Use the teleport trap is space is pressed
        if (Input.GetKeyDown("space") && teleportTrap > 0)
        {
            GetClosestAgentOrEnemy();
            UseTeleportTrap();

        }


    }

    //Respawn the other agent
    protected override void ReSpawnAgent()
    {
        Debug.Log("closest " + closest.name);
        int rand1 = Random.Range(0, 10);
        //closest.transform.parent.GetComponent<AI>().Spawn(rand1);
        GameObject.Find("AI").GetComponent<AI>().Spawn(rand1);
        teleportTrap--;
    }


    //Get the closest ennemy
    GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = GetDistance(currentPos, t);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
