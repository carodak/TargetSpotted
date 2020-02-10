using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script to make the player move Horizontaly and verticaly
public class PlayerMovement : MonoBehaviour {
    public float speed = 100;
    public Transform obj;

    private float h, v; //check if the player moved horizontaly or vertically

    public void Update()
    {
        IsKeyForMovingPressed();
        Move();
        
    }

    //Listen if up, down, left, right keys are pressed
    public void IsKeyForMovingPressed()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    //Move if one of up, down, left, right key is pressed
    public void Move()
    {
        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        obj.transform.position += tempVect;
    }



}
