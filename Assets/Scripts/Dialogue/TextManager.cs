using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//using TMPro;
using Newtonsoft.Json;
//Newtonsoft.Json is a 3rd party Json reader. It's being used here because it is able to serialize and deserialize multidimensional arrays,
//which are used for dialogue storage. More can be learned about Newtonsoft at https://www.newtonsoft.com/json/help/html/serializingjson.htm

[System.Serializable]
public class ContextDialogue
{
    private string[][] interactions;
    public string[][] Interactions
    {
        get
        {
            return interactions;
        }
        set
        {
            interactions = value;
        }
    }

    public string[] Context(int index)
    {
        return interactions[index];
    }
}

public class TextManager : SpeechBubble
{
    //public TextMeshProUGUI txt;
    public string filePath;
    public string[] functionNames;
    public GameObject[] functionObjects;
    private PlayerController pc;

    private int index = 0;
    private string fileText;
    private ContextDialogue interactions;

    public static bool inDialogue = true;
    public bool activeNPC = false;

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        fileText = File.ReadAllText(Application.streamingAssetsPath + filePath);
        interactions = JsonConvert.DeserializeObject<ContextDialogue>(fileText);
    }

    public void Talk(int context)
    {
        if (index <= interactions.Context(context).Length - 2)
        {
            pc.DisableMovement();
            Setup(interactions.Context(context)[index]);
            index++;
            pc.DisableMovement();
            //pc.currentSpeed = index == 0 ? pc.speed : pc.stopMovement;
        }
        else
        {
            DisableSpeechBubble();
            pc.EnableMovement();
            index = 0;
            activeNPC = false;
            gameObject.SendMessage(functionNames[0]);
        }
    }

    public void ActiveDialogue()
    {
        activeNPC = true;
    }
}
