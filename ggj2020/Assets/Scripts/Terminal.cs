using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void RunCommand(List<string> parameters);

public class Terminal : MonoBehaviour
{
    public GameObject display, input;

    private TextMesh displayText, inputText;
    private List<string> preivousCommands;
    private Event e;

    void Start()
    {
        displayText = display.GetComponent<TextMesh>();
        inputText = input.GetComponent<TextMesh>();
        preivousCommands = new List<string>();
        e = new Event();
    }

    void OnGUI()
    {
        if (Input.anyKeyDown)
        {
            e = Event.current;

            if(e.isKey && e.keyCode != KeyCode.None)
            {
                if(Input.inputString != "")
                {
                    inputText.text += Input.inputString;
                }

                if(e.keyCode == KeyCode.Return)
                {
                    EnterCommand();
                }

                if(e.keyCode == KeyCode.Backspace)
                {
                    Backspace();
                }
            }
        }
    }

    void EnterCommand()
    {
        string command = inputText.text.Substring(2);
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
}
