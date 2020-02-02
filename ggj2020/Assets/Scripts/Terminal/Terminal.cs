using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public delegate void RunCommand(List<string> parameters);
public delegate void PromptOutput(string[] output);

public class Terminal : MonoBehaviour
{
    // Varibles that hold the display and input text
    public TextMeshPro displayText, inputText;
    private float startTime;
    private char cursor;
    private bool cursorLock;

    // Variables that control the cycling of previous commands
    private List<string> previousCommands;
    private int prevCmdIndex;

    // Varibles that control the input
    private Event e;
    private bool isInputLocked;
    private bool isPrompted;
    private PromptOutput promptOutput;

    void Start()
    {
        previousCommands = new List<string>();
        e = new Event();
        isInputLocked = false;
        isPrompted = false;
        cursorLock = false;

        PromptPlayer("Please enter your name: ", ChangeName);
        //WriteToDisplay(string.Format("Hello Dr. {0}! Welcome to Site {1}!", GameManager.Instance.playerName, GameManager.Instance.siteName));
        inputText.text = string.Format("[{0}]\n> ", GameManager.Instance.location);
    }

    void Update()
    {
        if (displayText.isTextOverflowing)
        {
            displayText.text = RemoveFirstLine(displayText.text);
        }
    }

    void OnGUI()
    {

        if (!isInputLocked)
        {
            cursorLock = true;

            if (Input.anyKeyDown)
            {
                e = Event.current;

                if (e.isKey && e.keyCode != KeyCode.None && e.keyCode != KeyCode.Backspace)
                {
                    if (Input.inputString != "")
                    {
                        Debug.Log(Input.inputString);
                        Debug.Log(inputText.text);

                        MoveCursorAlong(Input.inputString);
                    }

                    if (e.keyCode == KeyCode.Return)
                    {
                            EnterCommand();
                    }

                    if(e.keyCode == KeyCode.Tab)
                    {
                        AutocompleteCommand(inputText.text.Substring(5 + GameManager.Instance.location.Length));
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
                cursorLock = true;
                e = Event.current;

                if (e.isKey && e.keyCode != KeyCode.None)
                {
                    if (e.keyCode == KeyCode.Backspace)
                    {
                        Backspace();
                    }
                }
            }
            cursorLock = false;


            if (Time.time - startTime >= 0.5 && !cursorLock)
            {
                startTime = Time.time;
                ChangeCursor();
            }

        }
    }

    void EnterCommand()
    {
        prevCmdIndex = 0;
        string command = inputText.text.Substring(5 + GameManager.Instance.location.Length);
        command = command.Substring(0, command.Length - 1);
        previousCommands.Add(command);
        if (previousCommands.Count > 20)
        {
            previousCommands.RemoveAt(0);
        }

        if (!isPrompted)
        {
            string output = Parser.ProcessCommand(RemoveCursor(command));
            displayText.text += string.Format("\n[{0}]\n{1}\n\t{2}", GameManager.Instance.location, command, output);
        }
        else
        {
            displayText.text += string.Format("\n[{0}]\n{1}", GameManager.Instance.location, command);
            promptOutput.Invoke(command.Split(' '));
            isPrompted = false;
        }

        inputText.text = string.Format("[{0}]\n> ", GameManager.Instance.location);
    }

    void Backspace()
    {
        if(inputText.text.Length > 5 + GameManager.Instance.location.Length)
        {
            inputText.text = inputText.text.Substring(0, inputText.text.Length - 1);
        }
    }

    void CycleCommands(int cmdIndex)
    {
        if(cmdIndex == 0)
        {
            inputText.text = string.Format("[{0}]\n> ", GameManager.Instance.location);
        }
        else
        {
            inputText.text = string.Format("[{0}]\n> {1}", GameManager.Instance.location, previousCommands[previousCommands.Count - cmdIndex]);
        }
    }

    void AutocompleteCommand(string partialCmd)
    {
        if(partialCmd.Length < 1)
        {
            return;
        }

        List<string> suggestions = GameManager.Instance.Commands.Keys.ToList().FindAll(key => key.Length >= partialCmd.Length && key.Substring(0, partialCmd.Length) == partialCmd);

        if(suggestions.Count == 1)
        {
            inputText.text = string.Format("[{0}]\n> {1}", GameManager.Instance.location, suggestions[0]);
        }
        else if(suggestions.Count > 1)
        {
            displayText.text += string.Format("\n[{0}]\n> {1}\n\t", GameManager.Instance.location, partialCmd);
            for(int i = 0; i < suggestions.Count; i++)
            {
                displayText.text += string.Format("{0}\t", suggestions[i]);
            }
        }
    }

    public void RunCommand(string command)
    {
        inputText.text = string.Format("[{0}]\n> {1}", GameManager.Instance.location, command);
        EnterCommand();
    }

    public void WriteToDisplay(string text)
    {
        StartCoroutine(WriteCoroutine(text));
    }

    public void PromptPlayer(string prompt, PromptOutput outputF)
    {
        WriteToDisplay(prompt);
        isPrompted = true;
        promptOutput = outputF;
    }

    IEnumerator WriteCoroutine(string text)
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

    string RemoveFirstLine(string input)
    {
        return string.Join("\n", input.Split('\n').Skip(1).ToArray());
    }

    void ChangeName(string[] output)
    {
        GameManager.Instance.playerName = output[0];

        WriteToDisplay(string.Format("\tHello Dr. {0}! Welcome to Site {1}!", GameManager.Instance.playerName, GameManager.Instance.siteName));
    }

    void ChangeCursor()
    {
        if (cursor == '|')
        {
            Backspace();
            cursor = ' ';
        }
        else
        {
            inputText.text += '|';
            cursor = '|';
        }
    }

    string RemoveCursor(string trim)
        => trim.Trim(new char[] { '|' });

    void MoveCursorAlong(string toAdd)
    {
        if (inputText.text[inputText.text.Length - 1] == '|')
        {
            Backspace();
            inputText.text += toAdd + '|';
        }
        else
            inputText.text += toAdd;
    }
}