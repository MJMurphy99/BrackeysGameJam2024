using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainSynapseInteractable : Interactable
{

    public GameObject player;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        Player = playerTransform;
    }

    // Update is called once per frame
    private void Update()
    {
        InRange();
    }

    public override void ActionFunction()
    {
        if(this.tag == "VerticalSynapse"){
            if(player.GetComponent<PlayerController>().verticalSynapseEnabled == true){
                player.GetComponent<PlayerController>().verticalSynapseEnabled = false;
            } else {
                player.GetComponent<PlayerController>().verticalSynapseEnabled = true;
            }
        } else if(this.tag == "HorizontalSynapse"){
            if(player.GetComponent<PlayerController>().horizontalSynapseEnabled == true){
                player.GetComponent<PlayerController>().horizontalSynapseEnabled = false;
            } else {
                player.GetComponent<PlayerController>().horizontalSynapseEnabled = true;
            }
        }

        
    }

}
