using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public static class RunCommands
    {
        public static string Capture(List<string> parameters)
        {
            if (parameters != null && parameters.Count == 2)
            {
                string name = parameters[0].Trim().ToLower();
                SCP scp = GameManager.Instance.GetSCP(name);

                if (scp != null)
                {
                    int index;
                    if (!int.TryParse(parameters[1], out index))
                        return "usage: capture <name> <cellnumber>";

                    SCPManager manager = GameManager.Instance.GetComponent<SCPManager>();

                    manager.CaptureSCP(scp.Name, GameManager.Instance.FindCell(index));
                    return $"Captured {scp.Name}, moved into cell {index}";
                }
                else
                    return $"{name} not found!";
            }
            return "usage: capture <name> <cellnumber>";
        }

        public static string List(List<string> parameters)
        {
            string output, command = parameters[0];

            if (parameters.Count != 3)
                command = "NULL";

            switch (command)
            {
                // list scp [wanted, captured, all]
                case "scp":
                    output = "SCPs:\n";
                    List<SCP> scps = GameManager.Instance.GetSCPs(parameters[1]);

                    if (scps == null)
                        break;

                    foreach (SCP scp in scps)
                        output += $"\t{scp.ToString()}\n";

                    return output;
                // list staff [research, security, all]
                case "staff":
                    output = "Staff:\n";
                    StaffType staffType;

                    if (!Enum.TryParse(parameters[1], out staffType))
                        break;

                    List<Staff> staff = GameManager.Instance.GetStaff(staffType);

                    if (staff.Count == 0)
                        break;

                    foreach (Staff member in staff)
                        output += $"\t{member.ToString()}\n";

                    return output;
                // list building <name>
                case "building":
                    output = "Buildings:\n";
                    List<GameObject> buildings = GameManager.Instance.Buildings.Values.ToList();

                    if (buildings.Count == 0)
                        break;

                    foreach (GameObject building in buildings)
                        output += $"\t{building.GetComponent<Buildings>().ToString()}\n";

                    return output;
                case "cell":
                    output = "Cells:\n";

                    string type = parameters[1];

                    List<Cell> cells;

                    if (type == "filled")
                        cells = GameManager.Instance.FindFilledCells();
                    else if (type == "empty")
                        cells = GameManager.Instance.FindOpenCells();
                    else if (type == "all")
                        cells = GameManager.Instance.FindCells();
                    else
                        break;

                    if (cells.Count == 0)
                        break;

                    foreach (Cell cell in cells)
                        output += $"\t{cell.ToString()}\n";

                    return output;
            }

            return "usage: \n" +
                "\tlist scp [wanted, captured, all]\n" +
                "\tlist staff [research, security, all]\n" +
                "\tlist building <building name>\n" +
                "\tlist cell [filled, empty, all]\n";
        }

        public static string Move(List<string> parameters)
        {
            string command, name;
            int floorNum;

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
                        if (parameters.Count != 2 || !int.TryParse(parameters[1], out floorNum))
                            break;

                        // Must be able to see if person is in the building
                        return $"Moving to floor {floorNum}";
                    case "staff":
                        if (parameters.Count == 4)
                            name = parameters[1];
                        else
                            break;
                        string identifier = parameters[2].ToLower().Trim();
                        string blgName = parameters[3];

                        Debug.Log($"[{identifier}]");

                        if (identifier == "building")
                        {
                            return $"Moving {name} to building {blgName}";
                        }
                        else if (identifier == "floor")
                        {
                            if (!int.TryParse(blgName, out floorNum))
                                break;
                            return $"Moving {name} to floor {floorNum}";
                        }
                        else
                        {
                            break;
                        }
                    // move out
                    case "out":
                        return "Moving out"; 
                    // TODO: add command 'in'
                }
            }
            return "usage: \n" +
                "\tmove staff <name> building <building name>" +
                "\tmove staff <name> floor <room num>" +
                "\tmove floor <room num>\n" +
                "\tmove building <building name>\n" +
                "\tmove out\n";
        }
    }
}
