using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public float speed, currentSpeed;
    public int stopMovement = 0;

    private Rigidbody2D rb;
    private Animator anim;

    public bool verticalSynapseEnabled, horizontalSynapseEnabled;

    public bool inCutscene = false;
    public GameObject interactIcon;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inCutscene)
        {
            Walk();
            PizzaTime();
        }
        
    }

    private void Walk()
    {
        //Casey's Way
        if(verticalSynapseEnabled){
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
            rb.velocity = new Vector2(0, currentSpeed);
            anim.SetInteger("isWalking", 1);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                //Down
                rb.velocity = new Vector2(0, -currentSpeed);
                anim.SetInteger("isWalking", 3);
            }
        }
        if(horizontalSynapseEnabled){
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                //Left
                rb.velocity = new Vector2(-currentSpeed, 0);
                transform.localScale = new Vector3(-1, 1, 1); //flip the sprite
                anim.SetInteger("isWalking", 2);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                //Right
                rb.velocity = new Vector2(currentSpeed, 0);
                transform.localScale = new Vector3(1, 1, 1); //flip the sprite
                anim.SetInteger("isWalking", 2);
            }
        }

        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            //No Input
            rb.velocity = new Vector2(0, 0);
            anim.SetInteger("isWalking", 0);
        }
    }

    private void PizzaTime()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Pizza Time", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Pizza Time", false);
        }
    }

    public void DisableMovement()
    {
        inCutscene = true;
    }

    public void EnableMovement()
    {
        inCutscene = false;
    }

    public void EnableInteractIcon()
    {
        interactIcon.SetActive(true);
    }
    public void DisableInteractIcon()
    {
        interactIcon.SetActive(false);
    }
}
