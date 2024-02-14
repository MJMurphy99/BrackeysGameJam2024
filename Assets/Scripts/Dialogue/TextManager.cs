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
    private PlayerController pc;

    private int index = 0;
    private string fileText;
    private ContextDialogue interactions;

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        fileText = File.ReadAllText(Application.dataPath + filePath);
        interactions = JsonConvert.DeserializeObject<ContextDialogue>(fileText);
    }

    public void Talk(int context)
    {
        Setup(interactions.Context(context)[index]);
        index = index == interactions.Context(context).Length - 1 ? index = 0 : index + 1;
        pc.currentSpeed = index == 0 ? pc.speed : pc.stopMovement;
    }
}
