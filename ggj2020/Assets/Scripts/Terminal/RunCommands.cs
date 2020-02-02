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
                        return "usage:\n" +
                            "capture <name> <cellnumber>";

                    SCPManager manager = GameManager.Instance.GetComponent<SCPManager>();

                    if(manager.CaptureSCP(scp.Name, GameManager.Instance.FindCell(index)))
                        return $"Captured {scp.Name}, moved into cell {index}";
                    else 
                        return $"Capture of {scp.Name} unsuccessful!";
                }
                else
                    return $"{name} not found!";
            }
            return "usage:\n" +
                "capture <name> <cellnumber>";
        }

        public static string List(List<string> parameters)
        {
            string output, command;

            if (parameters.Count == 0)
                command = "none";
            else
                command = parameters[0];

            if (parameters.Count != 2)
                command = "none";

            switch (command)
            {
                // list scp [wanted, captured, all]
                case "scp":
                    output = $"{parameters[1]} SCPs:\n";
                    List<SCP> scps = GameManager.Instance.GetSCPs(parameters[1]);

                    if (scps == null)
                        return "usage: \n" +
                          "\tlist scp [wanted, captured, all]\n";

                    foreach (SCP scp in scps)
                        output += $"\t{scp.ToString()}\n";

                    return output;
                // list staff [research, security, all]
                case "staff":
                    output = "Staff:\n";
                    StaffType staffType;

                    if (!Enum.TryParse(parameters[1], out staffType))
                        return "usage: \n" +
                            "\tlist staff [research, security, all]\n";

                   List <Staff> staff = GameManager.Instance.GetStaff(staffType);

                    foreach (Staff member in staff)
                        output += $"\t{member.ToString()}\n";

                    return output;
                // list building <name>
                case "building":
                    GameObject building;

                    if (GameManager.Instance.Buildings.ContainsKey(parameters[1]))
                        building = GameManager.Instance.Buildings[parameters[1]];
                    else
                        return "Building not found!";

                    return $"\n{building.GetComponent<Buildings>().ToString()}\n";
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
                        return "usage: \n" +
                            "\tlist cell [filled, empty, all]\n";

                    if (cells.Count == 0)
                        return "No Cells Found!";

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
                command = parameters[0].ToLower();

                Debug.Log(parameters.Count);

                switch (command)
                {
                    // move building <name>
                    case "building":
                        if (parameters.Count == 2)
                        {
                            name = parameters[1];
                            if (GameManager.Instance.sceneSelect.MoveToBuilding(name))
                            {
                                return $"Moving to building {name}";
                            }
                            else
                            {
                                return $"Building \"{name}\" doesn't exist";
                            }
                        }
                        else
                            break;

                    // move floor <number>
                    case "floor":
                        if (parameters.Count != 2 || !int.TryParse(parameters[1], out floorNum))
                            break;

                        if(GameManager.Instance.sceneSelect.MoveToFloor(floorNum))
                        {
                            return $"Moving to floor {floorNum}";
                        }
                        else
                        {
                            return "Not inside building or invalid floor number";
                        }
                        
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
                        if (GameManager.Instance.sceneSelect.MoveOut())
                            return "Moving out";
                        else
                            return "Cannot move out any further";
                }
            }
            return "usage:\n" +
                "move staff <name> building <building name>" +
                "move staff <name> floor <room num>" +
                "move floor <room num>\n" +
                "move building <building name>\n" +
                "move out";
        }

        public static string Hire(List<string> parameters)
        {
            if(parameters.Count == 2)
            {
                string building = parameters[0].ToLower();
                string floor = parameters[1];
                int floorNum;

                switch (building)
                {
                    case "research":
                        if(int.TryParse(floor, out floorNum) &&
                            GameManager.Instance.Buildings["research"].GetComponent<Buildings>().Floors.Count > floorNum &&
                            floorNum >= 0 &&
                            !GameManager.Instance.Buildings["research"].GetComponent<Buildings>().Floors[floorNum].GetComponent<Floor>().IsFilled)
                        {
                            GameManager.Instance.moneyManager.BuyStaff(GameManager.Instance.Buildings["research"].GetComponent<Buildings>().Floors[floorNum], StaffType.research);
                            return $"Hired research staff to floor {floorNum}";
                        }
                        else
                        {
                            return "Unable to hire research staff to that floor";
                        }

                    case "security":
                        if (int.TryParse(floor, out floorNum) &&
                            GameManager.Instance.Buildings["security"].GetComponent<Buildings>().Floors.Count > floorNum &&
                            floorNum >= 0 &&
                            !GameManager.Instance.Buildings["security"].GetComponent<Buildings>().Floors[floorNum].GetComponent<Floor>().IsFilled)
                        {
                            GameManager.Instance.moneyManager.BuyStaff(GameManager.Instance.Buildings["security"].GetComponent<Buildings>().Floors[floorNum], StaffType.security);
                            return $"Hired security staff to floor {floorNum}";
                        }
                        else
                        {
                            return "Unable to hire security staff to that floor";
                        }

                    default:
                        return $"Unknown building \"${building}\"";
                }
            }

            return "usage:\n" +
                "hire [research/security] <room number>";
        }

        public static string Buy(List<string> parameters)
        {
            if (parameters.Count == 3)
            {
                string command = parameters[0];
                switch (command)
                {
                    case "staff":

                        break;
                }
                //List of floors at a given building
               // GameManager.Instance.Buildings["research"].GetComponent<Research>().Floors;
            }
            return "usage:\n" +
                "buy staff [research/security] <room number>";
        }
    }
}
