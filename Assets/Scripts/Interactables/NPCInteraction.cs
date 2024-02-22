using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : Interactable
{
    public Transform playerTransform;
    public int context;

    private void Start()
    {
        Player = playerTransform;
    }

    private void Update()
    {
        InRange();
    }

    public override void ActionFunction()
    {
        tm.Talk(context);
    }
}
