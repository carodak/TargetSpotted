using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for setting up enemy speed, direction
public class Enemy : MonoBehaviour {

    private Vector2 direction; //direction of the movement

    private bool isTop = false; //true if enemy is on top of the map

    [SerializeField]
    public float speed = 5f; //Speed of the horizontal movement

    //Set enemy direction
    public Enemy(Vector2 direction)
    {
        this.direction = direction;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveEnemy();
	}

    public Vector2 GetDirection()
    {
        return direction;
    }

    //Set direction of oponent
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    //Know where is the current ennemy
    public bool GetIsTop()
    {
        return isTop;
    }

    public void SetIsTop(bool isTop)
    {
        this.isTop = isTop;
    }

    //Move enemy
    public void MoveEnemy()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

}
