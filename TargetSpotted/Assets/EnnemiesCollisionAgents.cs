using UnityEngine;

public class EnnemiesCollisionAgents : MonoBehaviour {

    public bool insideObstacle = false;
    public Vector2 fovSize;
    public float timeLeft = 0.5f;

    private void Start()
    {
        fovSize = gameObject.GetComponent<BoxCollider2D>().size;
    }

    //Change the offset of the FOV according to the direction the ennemy is going
    void Update()
    {
        if(transform.parent.gameObject.GetComponent<EnnemiesMovement>().GetDirection() == Vector2.right){
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(1.024887f, gameObject.GetComponent<BoxCollider2D>().offset.y);
        }

        if (transform.parent.gameObject.GetComponent<EnnemiesMovement>().GetDirection() == Vector2.left)
        {
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-1.024887f, gameObject.GetComponent<BoxCollider2D>().offset.y);
        }

        //If we have detected by the ennemy is inside the obstacle the FOV won't 
        if (insideObstacle == true){
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0f, 0f);

            timeLeft -= Time.deltaTime;

            if (timeLeft < 0){
                insideObstacle = false;
                gameObject.GetComponent<BoxCollider2D>().size = fovSize;
                timeLeft = 0.5f;
            }
           

        }

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("haha");

    }

    //If the ennemy sees an agent, it destroys it
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Agent" && coll.gameObject.name != "DetectingEnnemies")
        {
            Debug.Log("Ennemy saw the agent");
            Destroy(coll.gameObject.transform.parent.gameObject);
        }


    }


}
