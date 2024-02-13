using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    public bool followsPathing;

    public Transform[] waypoints;

    public float moveSpeed;

    public int waypointIndex = 0;

    public Transform randomTargetLocation;

    public bool touchingWall = false;

    public Rigidbody2D rb;

    void Start()
    {
        if(followsPathing){
            rb.transform.position = waypoints[waypointIndex].transform.position;
        } else {
            randomTargetLocation.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-4, 4));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(followsPathing){
            followPathMovement();
        } else {
            randomMovement();
        }
    }

    //Moves from one set waypoint to another. Will reset the pathing once it completes it's route
    private void followPathMovement(){
        if(waypointIndex <= waypoints.Length -1){
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            if(rb.transform.position == waypoints[waypointIndex].transform.position)   {
                waypointIndex +=1;
                if(waypointIndex == waypoints.Length){
                    waypointIndex = 0;
                }
            }
        } 
    }

    private void randomMovement(){
        if(randomTargetLocation.transform.position == rb.transform.position || touchingWall){
            randomTargetLocation.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-4, 4));
            if(touchingWall){
                touchingWall = false;
            }
        }
        rb.transform.position = Vector2.MoveTowards(rb.transform.position, randomTargetLocation.transform.position, moveSpeed * Time.deltaTime);
    }
    
    //important to have both of these here, this prevents it from getting stuck
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Wall")){
            touchingWall = true;    
        }
    }

    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.CompareTag("Wall")){
            touchingWall = true;    
        }
    }
}
