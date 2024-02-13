using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    public bool followsPathing;
    public bool lookoutMode;
    public GameObject eyesightCone;
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
        inLookoutMode();
    }

    //Moves from one set waypoint to another. Will reset the pathing once it completes it's route
    private void followPathMovement(){
        if(waypointIndex <= waypoints.Length -1){
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            RotateTowardsTarget(rb.transform, waypoints[waypointIndex].transform);
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
        RotateTowardsTarget(rb.transform, randomTargetLocation.transform);
    }

    private void inLookoutMode(){
        if(lookoutMode){
            eyesightCone.SetActive(true);
        } else {
            eyesightCone.SetActive(false);
        }
    }

    private void RotateTowardsTarget(Transform enemyTransform, Transform targetTrasform){
        float rotationSpeed = 10f; 
        float offset = 90f;
        Vector3 direction = targetTrasform.position - enemyTransform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation, rotation, rotationSpeed * Time.deltaTime);
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
