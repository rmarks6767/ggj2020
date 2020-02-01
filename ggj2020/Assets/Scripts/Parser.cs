using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Parser
    {
        public string ProcessCommand(string command)
        {
            // Split the commands to get all the info
            List<string> commands = command.Split(' ').ToList();
                
            // Get the first element to see what the command is 

            if (commands != null && commands[0] != null)
            {
                string commandStr = commands[0].ToLower().Trim();

                Debug.Log(commandStr);

                switch (commandStr)
                {
                    // list <This one is going to be a lot>
                    case "list":
                        return "list called";
                    // capture <name>
                    case "capture":
                        return "capture called";
                    case "change":
                        return "change called";
                    default:
                        return SyntaxError(commands[0]);
                }
            }
            else
            {
                // Maybe fix this later
                return "";
            }
           
        }

        private string SyntaxError(string command)
            => $"Could not find the command '{command}'";
    }
}
