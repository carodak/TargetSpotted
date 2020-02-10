using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script that contains the list of oponents

public class Ennemies : MonoBehaviour {

    [SerializeField]
    GameObject EnemyPrefab;


    private int onTop = 0; //Check how many ennemies are at the top

    private int onBottom = 0;

    private List<GameObject> ennemies = new List<GameObject>();

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        SpawnMultipleEnnemies();
    }

    //Add all opponents to the list of opponents
    public void AddOpponentToList(GameObject opponent)
    {
        ennemies.Add(opponent);
    }

    public void RemoveOpponentFromList(GameObject opponent)
    {
        ennemies.Remove(opponent);
    }

    //Get the list of ennemies
    public List<GameObject> GetEnnemiesList()
    {
        return ennemies;
    }

    //If an opponent is destroyed and is at the top of the map then decrease the number of ennemies that are at the top
    public void DecreaseOnTop()
    {
        onTop--;
    }

    public void DecreaseOnBottom()
    {
        onBottom--;
    }

    public void IncreaseNbBottom()
    {
        onBottom++;
    }

    public void IncreaseNbTop()
    {
        onTop++;
    }

    public int GetOnTop()
    {
        return onTop;
    }

    public int GetOnBottom()
    {
        return onBottom;
    }

    //Always having 2 ennemies (uncomment for a maximum of 3 ennemies)
    public void SpawnMultipleEnnemies()
    {
        if (transform.childCount < 2)
        {
            Spawn();
        }

    }



    //Spawn randomly an opponent at first or second door
    public void Spawn()
    {
        int rand = Random.Range(1, 3);

        if (GetOnTop() <= GetOnBottom())
        {
            SpawnAtTop(rand);
        }

        else
        {
            SpawnAtBottom(rand);
        }
    }

    //Spawn opponent at one of bottom doors
    private void SpawnAtBottom(int rand)
    {
        switch (rand)
        {
            case 1:
                SpawnAtPosition(new Vector3(20.61f, -5.9f, -9f), false);
                break;
            case 2:
                SpawnAtPosition(new Vector3(-20.61f, -5.9f, -9f), false);
                break;
            default:
                Debug.LogError("Error while choosing the random spawn. Error with rand?");
                break;
        }

        //Debug.Log("Not enought ennemies at the bottom");
    }

    //Spawn opponent at one of top doors
    private void SpawnAtTop(int rand)
    {
        switch (rand)
        {
            case 1:
                SpawnAtPosition(new Vector3(-20.61f, 5.9f, -9f), true);
                break;
            case 2:
                SpawnAtPosition(new Vector3(20.61f, 5.9f, -9f), true);
                break;
            default:
                Debug.LogError("Error while choosing the random spawn. Error with rand?");
                break;
        }
        //Debug.Log("Not enought ennemies at the top");

    }

    //Instanciate opponent
    public void SpawnAtPosition(Vector3 position, bool spawnTop)
    {
        //Instanciate oponent
        GameObject gO = Instantiate(EnemyPrefab, position, Quaternion.identity) as GameObject;
        gO.transform.parent = transform;

        //Add it to the array of opponents
        AddOpponentToList(gO);

        //Set their attribute
        if (!spawnTop)
        {
            gO.GetComponent<Enemy>().SetIsTop(false);
            IncreaseNbBottom();
        }
        else
        {
            gO.GetComponent<Enemy>().SetIsTop(true);
            IncreaseNbTop();
        }

    }

    //Decrease the number of enemies
    public void DecreaseNbEnemies(GameObject enemy)
    {
        if (enemy.GetComponent<Enemy>().GetIsTop() == true)
        {
            DecreaseOnTop();
        }

        else
        {
            DecreaseOnBottom();
        }
    }


}
