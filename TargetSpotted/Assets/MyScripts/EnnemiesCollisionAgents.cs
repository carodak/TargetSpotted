using UnityEngine;

public class EnnemiesCollisionAgents : MonoBehaviour {

    public bool insideObstacle = false;
    public Vector2 fovSize;
    public float timeLeft = 0.5f;

    private void Start()
    {
        fovSize = gameObject.GetComponent<BoxCollider2D>().size;
    }

   
    void Update()
    {

        ChangeEnemyOffset();

        
        if (insideObstacle == true)
        {
            HideFOV();

        }

    }

    //If we have detected that the ennemy is inside the obstacle no FOV
    public void HideFOV()
    {
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0f, 0f);

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            insideObstacle = false;
            gameObject.GetComponent<BoxCollider2D>().size = fovSize;
            timeLeft = 0.5f;
        }
    }

    //Change the offset of the FOV according to the direction the ennemy is going
    public void ChangeEnemyOffset()
    {
        Enemy enemy = transform.parent.gameObject.GetComponent<Enemy>();

        if (enemy.GetDirection() == Vector2.right)
        {
            SetLeftOffset();
        }

        if (enemy.GetDirection() == Vector2.left)
        {
            SetRightOffset();
        }
    }
    //Set offset to the right
    private void SetRightOffset()
    {
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-1.024887f, gameObject.GetComponent<BoxCollider2D>().offset.y);
    }
    //Set offset to the left
    private void SetLeftOffset()
    {
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(1.024887f, gameObject.GetComponent<BoxCollider2D>().offset.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("haha");

    }

    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Agent" && coll.gameObject.name != "DetectingEnnemies")
        {
            KillAgent(coll);
        }


    }

    //If the ennemy sees an agent, it destroys it
    public void KillAgent(Collider2D coll)
    {
        Debug.Log("Enemy saw the agent");

        if (KillAI(coll))
        {
            Debug.Log("AI killed");
        }
        else if (KillPlayer(coll))
        {
            Debug.Log("Player killed");
        }
        else
        {
            Debug.LogError("Error while killing an agent (EnnemiesCollision)");
        }
    }

    //Kill the player
    public bool KillPlayer(Collider2D coll)
    {
        Player player = coll.gameObject.transform.parent.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.isAlive = false;
            Destroy(coll.gameObject.transform.parent.gameObject);
            return true;
        }

        return false;
    }

    //Kill the AI
    public bool KillAI(Collider2D coll)
    {
        AI ai = coll.gameObject.transform.parent.gameObject.GetComponent<AI>();
        if (ai != null)
        {
            ai.isAlive = false;
            Destroy(coll.gameObject.transform.parent.gameObject);
            return true;
        }
        return false;
    }
}
