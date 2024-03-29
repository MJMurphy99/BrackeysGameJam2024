using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class ActionDictionary
{
    private static bool CheckCondition(string s)
    {
        string[] strArr = s.Split();
        return strArr[0].ToLower().CompareTo("true") == 0 || strArr[0].ToLower().CompareTo("false") == 0;
    }

    private static List<object> ParseParameterFromText(string text)
    {

        List<object> parameters = new();
        string[] parametersAsString = text.Split("|");
        foreach (string p in parametersAsString)
        {
            if (CheckCondition(p))
            {
                parameters.Add(p.ToLower().CompareTo("true") == 0);
            }
            else if (char.IsLetter(p[0]))
            {
                parameters.Add(p);
            }
            else if (p[0].CompareTo('@') == 0)
            {
                GameObject g = GameObject.Find(p.Substring(1, p.Length - 1));
                parameters.Add(g);
            }
            else
            {
                parameters.Add(int.Parse(p));
            }
        }

        return parameters;
    }

    public static void TalkCallback(string text)
    {
        var parameters = ParseParameterFromText(text);
        int? actionIndex = parameters[0] as int?;

        switch (actionIndex)
        {
            /*
                In the parameters of the function, pass each parameter from the parameters[]
                After writing the parameter from the array, write as (data type you want) - ex) 'parameters[1] as string'
                If the parameter is an 'int' or 'bool', write it as 'int?' or 'bool?'  
            */
            case 1:
                {

                    ToggleObjectActivation(parameters[1] as GameObject, parameters[2] as bool?);
                    break;
                }
            default:
                {
                    Debug.Log("Function ID does not exist");
                    break;
                }
        }
    }

    private static void SampleFunction(GameObject g)
    {
        /*
            This is an example of how 'Action' functions will look in the Action Dictionary
            They will all be labeled as 'private static void' - If you need a value returned, let us know
            If your function will have parameters, 'int' and 'bool' need to include ? - ex) 'int?' or 'bool?'
            If you need a Vector2, combine to 'int?' parameters - eg) private static void FunctionName(int? x int? y){}
        */


        Debug.Log(g.transform.position);
    }

    private static void ToggleObjectActivation(GameObject g, bool? isActive)
    {
        g.SetActive((bool)isActive);
    }

    private static void RotateObject(GameObject g, int? x, int? y, int? z)
    {
        g.transform.Rotate(new Vector3((int)x, (int)y, (int)z));
    }


}
