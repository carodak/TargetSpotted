using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICollisionEnnemies : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ennemy")
        {
            Debug.Log("The AI saw an ennemy");
            GameObject closestAlcove = gameObject.transform.parent.gameObject.GetComponent<AI>().GetClosestAlcove();

            Debug.Log("The AI is hidding fast");
            gameObject.transform.parent.gameObject.GetComponent<AI>().MoveToPosition(closestAlcove);

            gameObject.transform.parent.gameObject.GetComponent<AI>().ennemyNearby = true;
        }


    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ennemy"){
            gameObject.transform.parent.gameObject.GetComponent<AI>().ennemyNearby = false;
        }
    }
}
