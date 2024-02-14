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

    public GameObject speechBubbleGO;
    public GameObject textGO;
    public GameObject endDialogueCursorGO;

    public void Setup(string text)
    {
        speechBubbleGO.SetActive(true);
        textGO.SetActive(true);
        endDialogueCursorGO.SetActive(false);

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
        float totalHeight = 0f; // Initialize total height
        float totalWidth = 0f; // Initialize total width
        if (totalVisibleCharacters == 0)
        {
            // If there's no text, set total height to padding
            totalHeight = padding * 2;
        }
        while (counter <= totalVisibleCharacters)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            textMeshPro.maxVisibleCharacters = visibleCount;

            // Calculate total height of wrapped text
            totalHeight = textMeshPro.textBounds.size.y;

            // Calculate total width of wrapped text
            totalWidth = textMeshPro.textBounds.size.x;

            // Adjust background size based on text size and padding
            Vector2 backgroundSize = new Vector2(
                Mathf.Max(totalWidth + padding * 2, 0),
                Mathf.Max(totalHeight + padding * 2, 0)
            );
            backgroundSR.size = backgroundSize;

            counter++;
            yield return new WaitForSeconds(letterDelay);
        }

        // Text fully typed, activate endDialogueCursorGO
        if (endDialogueCursorGO != null)
        {
            endDialogueCursorGO.SetActive(true);
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
