using UnityEngine;

public class NPCInteraction : Interactable
{
    public Transform playerTransform;

    private void Start()
    {
        Player = playerTransform;
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        base.OnTriggerStay2D(other);
    }

    public override void ActionFunction()
    {
        print("Hello World");
    }
}
