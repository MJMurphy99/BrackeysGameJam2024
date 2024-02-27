using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//using TMPro;
using Newtonsoft.Json;
//Newtonsoft.Json is a 3rd party Json reader. It's being used here because it is able to serialize and deserialize multidimensional arrays,
//which are used for dialogue storage. More can be learned about Newtonsoft at https://www.newtonsoft.com/json/help/html/serializingjson.htm

[System.Serializable]
public class StateData
{
    private string[][] interactions, functions;
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

    public string[][] Functions
    {
        get
        {
            return functions;
        }
        set
        {
            functions = value;
        }
    }

    public string[] State(int index, bool isInteraction)
    {
        return isInteraction ? interactions[index] : functions[index];
    }
}

public class TextManager : SpeechBubble
{
    //public TextMeshProUGUI txt;
    public string filePath;
    public string[] functionNames;
    public GameObject[] functionObjects;
    public string[] data;
    private PlayerController pc;

    private int index = 0;
    private string fileText;
    private StateData dialogueData;

    public static bool inDialogue = true;
    public bool activeNPC = false;

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        fileText = File.ReadAllText(Application.streamingAssetsPath + filePath);
        dialogueData = JsonConvert.DeserializeObject<StateData>(fileText);
    }

    public void Talk(int context)
    {
        if (index <= dialogueData.State(context, true).Length - 2)
        {
            pc.DisableMovement();
            Setup(dialogueData.State(context, true)[index]);
            string funcLine = dialogueData.State(context, false)[index];
            if (funcLine.CompareTo("") != 0)
                ActionDictionary.TalkCallback(funcLine);
            index++;
            pc.DisableMovement();
        }
        else
        {
            DisableSpeechBubble();
            pc.EnableMovement();
            index = 0;
            activeNPC = false;
        }
    }

    public void ActiveDialogue()
    {
        activeNPC = true;
    }
}
