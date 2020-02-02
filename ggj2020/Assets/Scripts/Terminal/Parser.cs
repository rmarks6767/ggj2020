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
            List<string> commands = RemoveEmpty(command.Split(' ').ToList());
                
            // Get the first element to see what the command is 

            if (commands != null && commands[0] != null)
            {
                // Get the first command
                string commandStr = commands[0].ToLower().Trim();

                // Get rid of the command we just processed
                commands.RemoveAt(0);

                Debug.Log($"Processing Command: {commandStr}");

                // First command analysis

                RunCommand runCommand = GameManager.Instance.GetCommand(commandStr);

                if (runCommand != null)
                    return runCommand.Invoke(commands);
                else if (commandStr == "help")
                    return "usage: \n" +
                        "list\n" +
                        "\tscp [wanted, captured, all]\n" +
                        "\tstaff [research, security, all]\n" +
                        "\tbuilding <building name>\n" +
                        "\tcell [filled, empty, all]\n"+
                        "capture\n" +
                        "\t<name> <cellnumber>\n" +
                        "move\n" +
                        "\tstaff <name> building <building name>\n" +
                        "\tstaff <name> floor <room num>\n" +
                        "\tfloor <room num>\n" +
                        "\tbuilding <building name>\n" +
                        "\tout\n";
                else
                    return $"bash: {commandStr}: command not found...";
            }
            else
            {
                // Maybe fix this later
                return "";
            }
        }

        public static List<string> RemoveEmpty(List<string> strings)
        {
            List<string> newStrings = new List<string>();
            foreach (string c in strings)
                if (c != "" && c != " ")
                    newStrings.Add(c.Trim().ToLower());
            Debug.Log(newStrings.Count);
            return newStrings;
        }
    }
}
