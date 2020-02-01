using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class RunCommands
    {
        public static string Capture(List<string> parameters)
        {
            if (parameters != null && parameters[0] != null)
            {
                string command = parameters[0].Trim().ToLower();
                SCP scp = null;//GameManager.Instance.GetSCP(command);

                if (scp != null)
                {
                    // TODO: Add function for capturing the SCP
                    return $"Captured {scp.Name}";
                }
                else
                {
                    return $"{command} not found!";
                }
            }
            return "usage: capture <name>";
        }

        public static string List(List<string> parameters)
        {
            string command = parameters[0];
            /*if ()
            {

            }*/
            return "";
        }

        public static string Move(List<string> parameters)
        {
            string command, name;

            if (parameters != null && parameters.Count >= 1)
            {
                command = parameters[0];

                Debug.Log(parameters.Count);

                switch (command)
                {
                    // move building <name>
                    case "building":
                        if (parameters.Count == 2)
                            name = parameters[1];
                        else
                            break;

                        return $"Moving to building {name}";
                    // move floor <number>
                    case "floor":
                        if (parameters.Count == 2)
                            name = parameters[1];
                        else
                            break;

                        // Must be able to see if person is in the building
                        return $"Moving to floor {name}";
                    // move out
                    case "out":
                        return "Moving out"; 
                    // TODO: add command 'in'
                }
            }
            return "usage: move [floor, building] <identifier>\n" +
                "\t move [out]\n";
        }
    }
}
