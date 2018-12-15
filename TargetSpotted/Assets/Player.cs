using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static int numberItems = 0;

    public int teleportTrap = 2;

    public List<GameObject> ennemies = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Initialise an array with all ennemies + the AI
        // ennemies = new GameObject[GameObject.Find("Ennemies").transform.childCount+1]; 

        ennemies.Clear();

        for (int i = 0; i < GameObject.Find("Ennemies").transform.childCount;i++){
            ennemies.Add(GameObject.Find("Ennemies").transform.GetChild(i).gameObject);
        }

        //If the AI is still alive
        if (GameObject.Find("Agents").gameObject.transform.childCount ==2)
            ennemies.Add(GameObject.Find("AI").gameObject);

        //Get the closest gameobject
        GameObject closest = GetClosestEnemy(ennemies);
        //Debug.Log("closest: " + closest);

        //Use the teleport trap is space is pressed
        if (Input.GetKeyDown("space") && closest.name == "AI" && teleportTrap>0)
        {
            int rand1 = Random.Range(1, 11);
            closest.GetComponent<AI>().Spawn(rand1);

            teleportTrap--;
        }

        if (Input.GetKeyDown("space") && closest.tag == "Ennemy" && teleportTrap > 0)
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

            //Debug.Log("New ennemy");
            GameObject go = Instantiate(closest, transform.position, Quaternion.identity);
            go.transform.parent = GameObject.Find("Ennemies").transform;

            //Destroy the ennemy
            Destroy(closest);

            teleportTrap--;

        }

    }

    //Spawn randomly the player in one of the 10 alcoves
    public void Spawn(int rand){

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
    GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
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

    int GetNumberItems(){
        return numberItems;
    }
}
