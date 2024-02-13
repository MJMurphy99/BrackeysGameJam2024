using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
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

    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform == player)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ActionFunction();
            }
        }
    }

    public abstract void ActionFunction();
}
