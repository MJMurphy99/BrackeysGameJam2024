using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : Interactable
{
    public Transform playerTransform;
    public int context;
    private TextManager tm;

    private void Start()
    {
        Player = playerTransform;
        tm = GetComponent<TextManager>();
    }

    public override void ActionFunction()
    {
        tm.Talk(context);
    }
}
