using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


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
            audioManager.SetActive(false);
            camera.SetActive(true);

            TimelinePlayer.BuildDirector(GetComponent<PlayableDirector>());
            TimelinePlayer.StartTimeline();

            StartCoroutine(DevilTalk());

            hitOnce = false;
        }
    }

    IEnumerator DevilTalk()
    {

        yield return new WaitForSeconds(1.1f);
        devilGO.SetActive(true);
        yield return new WaitForSeconds(1f);

        tm.Talk(0);
    }
}
