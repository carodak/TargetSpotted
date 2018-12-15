using UnityEngine;

public class EnnemiesCollisionObstacles : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("haha");

    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        //If the ennemy spawned at the top/bottom left door, it would moves to the right
        if (coll.gameObject.name == "LeftTopDoor" || coll.gameObject.name == "LeftBottomDoor")
        {
            //Set the direction of the current GameObject (= the one that collided) to the right 
            transform.parent.gameObject.GetComponent<EnnemiesMovement>().SetDirection(Vector2.right);
        }

        //If the ennemy spawned at the left/bottom right door, it would moves to the left
        if (coll.gameObject.name == "RightTopDoor" || coll.gameObject.name == "RightBottomDoor")
        {
            transform.parent.gameObject.GetComponent<EnnemiesMovement>().SetDirection(Vector2.left);
        }

        if (coll.gameObject.tag == "Obstacle")
        {

            /*If the ennemy met the obstacle
             * with equal probability they either move through the obstacle unhindered, 
             * they disappear, or they reverse direction.
             * 
             * case 1 = reverse direction
             * case 2 = disappear
             * case 3 = move through the obstacle unhindered
            */

            int rand = Random.Range(1, 4);
            switch (rand)
            {
                case 1:

                    if (transform.parent.gameObject.GetComponent<EnnemiesMovement>().GetDirection() == Vector2.right)
                    {
                        transform.parent.gameObject.GetComponent<EnnemiesMovement>().SetDirection(Vector2.left);
                    }
                    else
                    {
                        transform.parent.gameObject.GetComponent<EnnemiesMovement>().SetDirection(Vector2.right);
                    }
                    //Debug.Log("Reversing direction");
                    break;
                case 2:
                    //Update the number on ennemies that are on the top or on the bottom
                    if(transform.parent.gameObject.GetComponent<EnnemiesMovement>().GetIsTop() == true){
                        transform.parent.gameObject.GetComponent<EnnemiesMovement>().DecreaseOnTop();
                    }

                    else{
                        transform.parent.gameObject.GetComponent<EnnemiesMovement>().DecreaseOnBottom();
                    }

                    //Destroy the ennemy
                    Destroy(transform.parent.gameObject);
                    //Debug.Log("Get destroyed");
                    break;

                case 3:
                    //Debug.Log("Nothing changed");
                    //While the ennemy is in the obstacle its FOV size is 0

                    GameObject go_fov = transform.parent.gameObject.transform.GetChild(1).gameObject;
                    go_fov.GetComponent<EnnemiesCollisionAgents>().insideObstacle = true;
                    break;

                default:
                    Debug.Log("Error while the ennemy met the obstacle");
                

                    break;
            }

        }



    }



}
