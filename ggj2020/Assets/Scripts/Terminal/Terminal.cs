using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public delegate void RunCommand(List<string> parameters);

public class Terminal : MonoBehaviour
{
    // Varibles that hold the display and input text
    public TextMeshPro displayText, inputText;

    // Variables that control the cycling of previous commands
    private List<string> previousCommands;
    private int prevCmdIndex;

    // Varibles that control the input
    private Event e;

    private bool isInputLocked;

    void Start()
    {
        previousCommands = new List<string>();
        e = new Event();
        isInputLocked = false;
        WriteToDisplay("Hello &#^$%@%! Welcome to Site %#!");
    }

    void OnGUI()
    {
        if (!isInputLocked)
        {
            if (Input.anyKeyDown)
            {
                e = Event.current;

                if (e.isKey && e.keyCode != KeyCode.None && e.keyCode != KeyCode.Backspace)
                {
                    if (Input.inputString != "")
                    {
                        inputText.text += Input.inputString;
                    }

                    if (e.keyCode == KeyCode.Return)
                    {
                        EnterCommand();
                    }

                    if (e.keyCode == KeyCode.UpArrow)
                    {
                        prevCmdIndex++;
                        if (prevCmdIndex > previousCommands.Count)
                        {
                            prevCmdIndex = previousCommands.Count;
                        }

                        CycleCommands(prevCmdIndex);
                    }
                    else if (e.keyCode == KeyCode.DownArrow)
                    {
                        prevCmdIndex--;
                        if (prevCmdIndex < 0)
                        {
                            prevCmdIndex = 0;
                        }

                        CycleCommands(prevCmdIndex);
                    }
                }
            }

            if (Input.anyKey)
            {
                e = Event.current;

                if (e.isKey && e.keyCode != KeyCode.None)
                {
                    if (e.keyCode == KeyCode.Backspace)
                    {
                        Backspace();
                    }
                }
            }
        }
    }

    void EnterCommand()
    {
        prevCmdIndex = 0;
        string command = inputText.text.Substring(2);
        previousCommands.Add(command);
        if(previousCommands.Count > 20)
        {
            previousCommands.RemoveAt(0);
        }
        string output = Parser.ProcessCommand(command);
        displayText.text += '\n' + command + "\n\t" + output;
        inputText.text = "> ";
    }

    void Backspace()
    {
        if(inputText.text.Length > 3)
        {
            inputText.text = inputText.text.Substring(0, inputText.text.Length - 2);
        }
    }

    void CycleCommands(int cmdIndex)
    {
        if(cmdIndex == 0)
        {
            inputText.text = "> ";
        }
        else
        {
            inputText.text = "> " + previousCommands[previousCommands.Count - cmdIndex];
        }
    }

    public void RunCommand(string command)
    {
        inputText.text = "> " + command;
        EnterCommand();
    }

    public void WriteToDisplay(string text)
    {
        StartCoroutine(WriteCoroutine(text));
    }

    private IEnumerator WriteCoroutine(string text)
    {
        isInputLocked = true;

        displayText.text += "\n";

        for (int i = 0; i < text.Length; i++)
        {
            displayText.text += text[i];
            yield return new WaitForSeconds(.1f);
        }

        isInputLocked = false;
    }
}
