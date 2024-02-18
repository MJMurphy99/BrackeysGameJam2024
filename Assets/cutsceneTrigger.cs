using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneTrigger : MonoBehaviour
{
    public GameObject cutsceneManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            cutsceneManager.SetActive(true);
        }
    }
}
