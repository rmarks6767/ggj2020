using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Parser
    {
        public static string ProcessCommand(string command)
        {
            // Split the commands to get all the info
            List<string> commands = command.Split(' ').ToList();
                
            // Get the first element to see what the command is 

            if (commands != null && commands[0] != null)
            {
                // Get the first command
                string commandStr = commands[0].ToLower().Trim();

                // Get rid of the command we just processed
                commands.RemoveAt(0);
                Debug.Log(commandStr);

                // First command analysis
                switch (commandStr)
                {
                    // list <This one is going to be a lot>
                    case "list":
                        return RunCommands.List(commands);
                    // capture <name>
                    case "capture":
                        return RunCommands.Capture(commands);
                    // change room
                    case "move":
                        return RunCommands.Move(commands);
                    case "help":
                        return
                            "usage: \n" +
                            "\tlist <room, scp, staff>\n" +
                            "\tcapture <name>\n" +
                            "\tchange room\n";
                    default:
                        return $"bash: {commandStr}: command not found...";
                }
            }
            else
            {
                // Maybe fix this later
                return "";
            }
           
        }
    }
}
