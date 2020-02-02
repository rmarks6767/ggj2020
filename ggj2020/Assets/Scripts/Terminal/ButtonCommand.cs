using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ButtonCommand : MonoBehaviour
{
    public string command;
    public GameObject terminal;
    // Start is called before the first frame update
    void Start()
    {
        command = "help";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunAttachedCommand()
    {
        terminal.GetComponent<Terminal>().RunCommand(command);
    }
}
