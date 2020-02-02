using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI heading;
    public TextMeshProUGUI pollheading;
    public TextMeshProUGUI namesList;
    public TextMeshProUGUI namesList2;
    public TextMeshProUGUI polls;
    public List<string> names;
    public List<string> pollQ;
    public List<string> pollA;




    /// <summary>
    /// Aidan wrote these, ripping them from terminal.cs
    /// </summary>
    /// <param name="text"></param>
    public void WriteToDisplay(string text, TextMeshProUGUI display, float speed =.1f)
    {
        StartCoroutine(WriteCoroutine(text, display, speed));
    }

    IEnumerator WriteCoroutine(string words, TextMeshProUGUI display, float speed)
    {

        TextMeshProUGUI displayText = display;
      
        displayText.text += "\n";

        for (int i = 0; i < words.Length; i++)
        {
            displayText.text += words[i];
            yield return new WaitForSeconds(speed);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        title.text = "";
        heading.text = "";
        namesList.text = "";
        namesList2.text = "";
        pollheading.text = "";
        WriteToDisplay("Special Thanks", title);
        WriteToDisplay("Twitch Designers", heading);
        WriteToDisplay("Poll Results", pollheading);
        string nameString1 = "";
        string nameString2 = "";
        List<string> names1 = names.GetRange(0, names.Count / 2);
        List<string> names2 = names.GetRange(names.Count / 2, names.Count / 2);
        foreach (string name in names1)
        {
            nameString1 += name;
            nameString1 += "\n";
        }
        foreach (string name in names2)
        {
            nameString2 += name;
            nameString2 += "\n";
        }

        if (pollA.Count == pollQ.Count)
        {
            string results = "";
            for (int i = 0; i < pollA.Count; i++)
            {
                results += "Q: " + pollQ[i] + "\n     A: " + pollA[i] + "\n";
            }
            WriteToDisplay(results, polls, .02f);
        }
        WriteToDisplay(nameString2, namesList2, .04f);
        WriteToDisplay(nameString1, namesList, .04f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
