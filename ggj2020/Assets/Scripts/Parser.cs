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
                // Get the first command
                string commandStr = commands[0].ToLower().Trim();

                // Get rid of the command
                commands[0].Remove(0);
                Debug.Log(commandStr);

                // First command analysis
                switch (commandStr)
                {
                    // list <This one is going to be a lot>
                    case "list":
                        RunCommands.List(commands);
                        return "Done!";
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
            => $"bash: {command}: command not found";
    }
}
