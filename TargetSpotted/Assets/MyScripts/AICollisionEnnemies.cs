using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for collisions that the AI detects (opponents)
public class AICollisionEnnemies : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        //If the collider detects an enemy, then the ai has to hide fast
        if (coll.gameObject.tag == "Ennemy")
        {
            Debug.Log("The AI saw an ennemy");
            Debug.Log("The AI is hidding fast");

            gameObject.transform.parent.gameObject.GetComponent<AI>().GoToNearestAlcove();
            gameObject.transform.parent.gameObject.GetComponent<AI>().ennemyNearby = true;
        }


    }

    void OnTriggerExit2D(Collider2D coll)
    {
        //Area clear
        if (coll.gameObject.tag == "Ennemy"){
            gameObject.transform.parent.gameObject.GetComponent<AI>().ennemyNearby = false;
        }
    }
}
