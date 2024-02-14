using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, currentSpeed;
    public int stopMovement = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 direction = new(x, y, 0);
        Vector3 moveVector = (x != 0 && y != 0 ? Vector3.Normalize(direction) : direction) * currentSpeed * Time.deltaTime;
        transform.position += moveVector;
    }
}
