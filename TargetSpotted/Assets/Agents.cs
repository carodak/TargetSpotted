using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agents: MonoBehaviour {

    public static int numberItemsAI = 0;
    public static int numberItemsPlayer = 0;

    // Use this for initialization
    void Start () {

        int rand1 = Random.Range(1, 11); //The agent1 has 10 positions for spawning (10 alcoves)
        int rand2 = Random.Range(1, 11);

        //Avoid having both agents in the same alcove
        while(rand2==rand1){
            rand2 = Random.Range(1, 11);
        }

        //Spawn both childs in different alcoves
        gameObject.transform.GetChild(0).gameObject.GetComponent<Player>().Spawn(rand1);
        gameObject.transform.GetChild(1).gameObject.GetComponent<AI>().Spawn(rand2);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
