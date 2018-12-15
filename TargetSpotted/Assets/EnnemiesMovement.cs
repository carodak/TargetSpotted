using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesMovement : MonoBehaviour
{

    [SerializeField]
    public float speed = 5f; //Speed of the horizontal movement

    public Vector2 direction;

    public static int onTop = 0; //Check how many ennemies are at the top
    public bool isTop = true;
    public static int onBottom = 0;

    public EnnemiesMovement()
    {
    }

    public EnnemiesMovement(Vector2 direction)
    {
        this.direction = direction;
    }

    // Use this for initialization
    void Start()
    {
        Spawn();
    }


    // Update is called once per frame
    void Update()
    {
        MoveEnnemy();
        SpawnMultipleEnnemies();
    }

    //Know where is the current ennemy
    public bool GetIsTop(){
        return isTop;
    }

    //If the ennemy is destroyed, descrease the number of ennemies that are at the top of the map
    public void DecreaseOnTop()
    {
        onTop--;
    }

    public void DecreaseOnBottom()
    {
        onBottom--;
    }

    //Change the direction of an ennemy
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    //Get the direction of an ennemy
    public Vector2 GetDirection()
    {
        return this.direction;
    }

    //Always having 2 ennemies (uncomment for a maximum of 3 ennemies)
    public void SpawnMultipleEnnemies()
    {
        if (GameObject.Find("Ennemies").transform.childCount < 2)
        {
            //Debug.Log("New ennemy");
            GameObject go = Instantiate(gameObject, transform.position, Quaternion.identity);
            go.transform.parent = GameObject.Find("Ennemies").transform;

        }

        /*
        if (GameObject.Find("Ennemies").transform.childCount < 3)
        {
            int rand2 = Random.Range(1, 501);
            if (rand2 == 1)
            {
                GameObject go = Instantiate(gameObject, transform.position, Quaternion.identity);
                go.transform.parent = GameObject.Find("Ennemies").transform;
            }
        }
        */

    }

    public void MoveEnnemy()
    {
        //Move the ennemy horizontally from left to right at speed
        gameObject.transform.Translate(direction * speed * Time.deltaTime);

    }

    //Spawn randomly at a door
    public void Spawn()
    {
        int rand = Random.Range(1, 3);

        if (onTop<=onBottom){
            switch (rand)
            {
                case 1:
                    gameObject.transform.position = new Vector3(-20.61f, 5.9f, -9f);
                    break;
                case 2:
                    gameObject.transform.position = new Vector3(20.61f, 5.9f, -9f);
                    break;
                default:
                    Debug.Log("Error while choosing the random spawn. Error with rand?");
                    break;
            }
            //Debug.Log("Not enought ennemies at the top");
            isTop = true;
            onTop++;
        }

        else {
            switch (rand)
            {
                //Spawn at top left door, bottom left door, top right door, bottom right door
                case 1:
                    gameObject.transform.position = new Vector3(-20.61f, -5.9f, -9f);
                    break;
                case 2:
                    gameObject.transform.position = new Vector3(20.61f, -5.9f, -9f);
                    break;
                default:
                    Debug.Log("Error while choosing the random spawn. Error with rand?");
                    break;
            }
            isTop = false;
            onBottom++;
            //Debug.Log("Not enought ennemies at the bottom");
        }
    }
}
