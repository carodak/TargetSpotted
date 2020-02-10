using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : Agents {

    [SerializeField]
    public Player player;

    public bool ennemyNearby = false;

    //If true AI will use teleport trap
    private bool useTeleport;

    // Use this for initialization
    void Start ()
    {
    }

    //Set alcove number where the ai will spawn
    protected override void SetAlcoveNumber()
    {
        alcoveNumber = GetRandomPosition();
        while (player.GetComponent<Player>().alcoveNumber == alcoveNumber)
        {
            alcoveNumber = GetRandomPosition();
        }
    }

    //Spawn inherited method
    public override void Spawn(int rand)
    {
        base.Spawn(rand);
    }


    // Update is called once per frame
    void Update ()
    {

        SetUseTeleport();

        //Go to the closest item if no opponents nearby
        if (ennemyNearby == false)
        {
            GoToNearestItem();
        }

    }

    //AI moves to the nearest item
    public void GoToNearestItem()
    {
        List<GameObject> itemsList = items.GetComponent<Items>().GetListItems();
        GameObject gO = GetClosestGameObject(itemsList);
        MoveToPosition(gO);
    }

    //AI moves to the nearest alcove
    public void GoToNearestAlcove()
    {
        List<GameObject> alcovesList = alcoves.GetComponent<Alcoves>().GetAlcovesList();
        GameObject gO = GetClosestGameObject(alcovesList);
        MoveToPosition(gO);
    }

    //Get Closest Agent or Enemy
    public override GameObject GetClosestAgentOrEnemy()
    {
        List<GameObject> list = ennemies.GetComponent<Ennemies>().GetEnnemiesList();
        if (player!=null)
             list.Add(player.transform.GetChild(0).gameObject);
        GameObject gO = GetClosestGameObject(list);
        return gO;
    }

    //Respawn the other agent
    protected override void ReSpawnAgent()
    {
        Debug.Log("closest " + closest.name);
        int rand1 = Random.Range(0, 10);
        //closest.transform.parent.GetComponent<Player>().Spawn(rand1);
        GameObject.Find("Player").GetComponent<Player>().Spawn(rand1);
    }


    //Randomly Set useTeleport AI's attribute
    public void SetUseTeleport(){
        int rand1 = Random.Range(1, 501);
        if (rand1 == 1){
            useTeleport = true;
            GetClosestAgentOrEnemy();
            UseTeleportTrap(); //Respawn the player or destroy an ennemy
        }
        useTeleport = false;
    }


    //Move the AI to the gameobject position (with A* algo)
    public void MoveToPosition(GameObject go){
        if(go!=null)
            gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = go.transform;
    }

}
