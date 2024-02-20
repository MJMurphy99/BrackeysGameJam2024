using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float minDistance;
    public bool dialogueDone = true;
    public TextManager tm;


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
        if (Vector2.Distance(transform.position, player.position) <= minDistance || tm.activeNPC == true)
        {
            if (dialogueDone && Input.GetKeyDown(KeyCode.E))
            {
                ActionFunction();
                FMODUnity.RuntimeManager.PlayOneShot("event:/Dialogue_AdvanceText");
            }
        }
    }

    public abstract void ActionFunction();
}
