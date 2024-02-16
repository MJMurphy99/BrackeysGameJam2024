using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactIconTrigger : MonoBehaviour
{
    public PlayerController pc;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            pc.EnableInteractIcon();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            pc.DisableInteractIcon();
        }
    }
}
