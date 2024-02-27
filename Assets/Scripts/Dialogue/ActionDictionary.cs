using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class ActionDictionary
{

    private static List<object> ParseParameterFromText(string text)
    {
        List<object> parameters = new();
        string[] parametersAsString = text.Split("|");
        foreach (string p in parametersAsString)
        {
            if (p[0].CompareTo('f') == 0 || p[0].CompareTo('t') == 0)
            {
                parameters.Add(p[0].CompareTo('f') == 0);
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
            case 1:
                {
                    HopefullyThisWorks(parameters[1] as bool?, parameters[2] as int?, parameters[3] as bool?);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    private static void HopefullyThisWorks(bool? b1, int? i1, bool? b2)
    {
        Debug.Log(b1 + " " + i1 + " " + b2);
    }
}
