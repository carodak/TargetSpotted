using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnnemiesCollisionObstacles : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("haha");

    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        //If the ennemy spawned at the top/bottom left door, it would moves to the right
        if (coll.gameObject.name == "LeftTopDoor" || coll.gameObject.name == "LeftBottomDoor")
            MoveToTheRight();

        //If the ennemy spawned at the left/bottom right door, it would moves to the left
        if (coll.gameObject.name == "RightTopDoor" || coll.gameObject.name == "RightBottomDoor")
        {
            MoveToTheLeft();
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

            Enemy enemy = transform.parent.gameObject.GetComponent<Enemy>();

            int rand = Random.Range(1, 4);
            switch (rand)
            {
                case 1:

                    ReverseDirection(enemy);
                    //Debug.Log("Reversing direction");
                    break;
                case 2:
                    //Update the number on ennemies that are on the top or on the bottom
                    KillEnemy(enemy);
                    //Debug.Log("Get destroyed");
                    break;

                case 3:
                    //Debug.Log("Nothing changed");
                    //While the ennemy is in the obstacle its FOV size is 0

                    MoveUnhindered();
                    break;

                default:
                    Debug.Log("Error while the ennemy met the obstacle");
                

                    break;
            }

        }



    }
    //Move through the obstacle unhindered
    public void MoveUnhindered()
    {
        GameObject go_fov = transform.parent.gameObject.transform.GetChild(1).gameObject;
        go_fov.GetComponent<EnnemiesCollisionAgents>().insideObstacle = true;
    }

    //Kill an oponent
    public void KillEnemy(Enemy enemy)
    {
        DecreaseNbEnemies(enemy);

        //Remove ennemy from the List of enemies
        transform.parent.parent.GetComponent<Ennemies>().RemoveOpponentFromList(transform.parent.gameObject);

        //Destroy gameobject
        Destroy(transform.parent.gameObject);
    }

    //Decrease number of enemies
    public void DecreaseNbEnemies(Enemy enemy)
    {
        if (enemy.GetIsTop() == true)
        {
            transform.parent.parent.GetComponent<Ennemies>().DecreaseOnTop();
        }

        else
        {
            transform.parent.parent.GetComponent<Ennemies>().DecreaseOnBottom();
        }
    }

    //Reverse direction of an enemy
    public void ReverseDirection(Enemy enemy)
    {
        if (enemy.GetDirection() == Vector2.right)
        {
            enemy.SetDirection(Vector2.left);
        }
        else
        {
            enemy.SetDirection(Vector2.right);
        }
    }

    //Enemy will move to the left
    public void MoveToTheLeft()
    {
        Enemy enemy = transform.parent.gameObject.GetComponent<Enemy>();
        enemy.SetDirection(Vector2.left);
    }

    //Enemy will move to the right
    public void MoveToTheRight()
    {
        Enemy enemy = transform.parent.gameObject.GetComponent<Enemy>();
        //Set the direction of the current GameObject (= the one that collided) to the right 
        enemy.SetDirection(Vector2.right);
    }
}
