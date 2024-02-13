using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        //Dan's Way
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //Vector3 direction = new(x, y, 0);
        //Vector3 moveVector = (x != 0 && y != 0 ? Vector3.Normalize(direction) : direction) * speed * Time.deltaTime;
        //transform.position += moveVector;

        //Casey's Way
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //Down
            rb.velocity = new Vector2(0, -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Left
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector3(-1, 1, 1); //flip the sprite
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //Right
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector3(1, 1, 1); //flip the sprite
        }

        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            //No Input
            rb.velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerEnter2d(Collision2D col){
        if(col.gameObject.CompareTag("EnemyEyesight")){
            Debug.Log("Spotted by the enemy - Do something about it...");    
        }
    }
}
