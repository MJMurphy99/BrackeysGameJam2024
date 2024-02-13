using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    private SpriteRenderer backgroundSR;
    private TextMeshPro textMeshPro;
    public float maxWidth = 5f; // Maximum width before text wraps
    public float maxHeight = 3f; // Maximum height before text truncates
    public float padding = 0.5f; // Padding around the text
    public float letterDelay = 0.1f; // Time delay between displaying each letter

    private Coroutine textWriterCoroutine;

    private void Awake()
    {
        Setup("Hello World! My name is the scientist and I have come for your pickle!!! My pickle is juicy and tender?????? and you know what else I dont like ");
    }

    private void Setup(string text)
    {
        backgroundSR = transform.Find("Speech Bubble").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();

        textMeshPro.SetText("");
        textMeshPro.maxVisibleCharacters = 0;

        if (textWriterCoroutine != null)
            StopCoroutine(textWriterCoroutine);

        textWriterCoroutine = StartCoroutine(WriteText(text));
    }

    IEnumerator WriteText(string text)
    {
        string wrappedText = WrapText(text, maxWidth);
        textMeshPro.SetText(wrappedText);
        textMeshPro.ForceMeshUpdate();
        TMP_TextInfo textInfo = textMeshPro.textInfo;

        int totalVisibleCharacters = textInfo.characterCount;
        int counter = 0;
        while (counter < totalVisibleCharacters)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            textMeshPro.maxVisibleCharacters = visibleCount;

            // Calculate total height of wrapped text
            float totalHeight = textMeshPro.textBounds.size.y;

            // Adjust background size based on text size and padding
            Vector2 backgroundSize = new Vector2(maxWidth + padding * 2, Mathf.Min(totalHeight + padding * 2, maxHeight));
            backgroundSR.size = backgroundSize;

            counter++;
            yield return new WaitForSeconds(letterDelay);
        }
    }

    string WrapText(string text, float maxWidth)
    {
        List<string> newLines = new List<string>();
        string currentLine = "";
        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            if (textMeshPro.GetPreferredValues(currentLine + " " + word).x > maxWidth)
            {
                newLines.Add(currentLine);
                currentLine = "";
            }
            currentLine += (currentLine == "" ? "" : " ") + word;
        }

        if (!string.IsNullOrEmpty(currentLine))
            newLines.Add(currentLine);

        return string.Join("\n", newLines);
    }
}
