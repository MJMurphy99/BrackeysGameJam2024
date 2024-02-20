using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class devilCutsceneTrigger : MonoBehaviour
{
    public GameObject devilGO;
    public GameObject doorGO;
    public GameObject audioManager;
    public GameObject camera;

    public TextManager tm;

    private Collider2D col;
    public bool hitOnce = true;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player") && hitOnce)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/DevilPopout");
            devilGO.SetActive(true);
            doorGO.SetActive(true);
            audioManager.SetActive(false);
            camera.SetActive(true);

            StartCoroutine(DevilTalk());

            hitOnce = false;
        }
    }

    IEnumerator DevilTalk()
    {
        yield return new WaitForSeconds(1f);

        tm.Talk(0);
    }
}
