using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public float minDistance;
    protected Transform Player
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
        }
    }

    private Transform player;

    public void InRange()
    {
        if (Vector2.Distance(transform.position, player.position) <= minDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ActionFunction();
            }
        }
    }

    public abstract void ActionFunction();
}
