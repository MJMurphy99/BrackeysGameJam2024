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

    private void Update()
    {
        InRange();
    }

    public override void ActionFunction()
    {
        tm.Talk(context);
    }
}
