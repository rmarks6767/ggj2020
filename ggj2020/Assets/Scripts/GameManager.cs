using System.Collections.Generic;

namespace Assets.Scripts
{
    /// <summary>
    /// The types of staff that exist
    /// </summary>
    public enum StaffType
    {
        all,
        research,
        security
    }

    /// <summary>
    /// The given danger level of an SCP
    /// </summary>
    public enum DangerLevel
    {
        all,
        safe,
        euclid,
        keter
    }

    /// <summary>
    /// Type of building
    /// </summary>
    public enum BuildingType
    {
        research,
        security,
        containment
    }

    public delegate string RunCommand(List<string> parameters);

    class GameManager : Singleton<GameManager>
    {
        public string playerName, siteName, location;

        /// <summary>
        /// The money that the player will have
        /// </summary>
        public int Money { get; }
        private int money;

        private List<Buildings> buildings;
        public List<Buildings> Buildings(string name) 
            => buildings.Find(building => building.Name == name);

        /// <summary>
        /// The staff that exist in the given room
        /// </summary>
        private Dictionary<StaffType, List<Staff>> staff;

        /// <summary>
        /// The scps that are active in the given room
        /// </summary>
        private Dictionary<DangerLevel, List<SCP>> scps;

        /// <summary>
        /// List of all valid commands and the functions that correlate to the command
        /// </summary>
        private Dictionary<string, RunCommand> commands;

        public Dictionary<string, RunCommand> Commands
        {
            get { return commands; }
        }

        /// <summary>
        /// GameManager will be a singleton and hold all of the money 
        /// and people in a given room
        /// </summary>
        public GameManager()
        {
            // Create the defaults for the staff
            staff = new Dictionary<StaffType, List<Staff>>()
            {
                { StaffType.research, new List<Staff>() },
                { StaffType.security, new List<Staff>() }
            };

            // Create the defaults for the SCPs
            scps = new Dictionary<DangerLevel, List<SCP>>()
            {
                { DangerLevel.safe, new List<SCP>() },
                { DangerLevel.euclid, new List<SCP>() },
                { DangerLevel.keter, new List<SCP>() },
            };

            // Creates the commands to be used in the terminal
            commands = new Dictionary<string, RunCommand>()
            {
                {"capture", RunCommands.Capture},
                {"list", RunCommands.List},
                {"move", RunCommands.Move}
            };

            playerName = "#%^$%&$&@";
            siteName = "%$^";
            location = "~/building/floor";
        }

        /// <summary>
        /// Used to increment the number of a given type plus one
        /// </summary>
        /// <param name="staffType">The type to increment</param>
        public void AddStaff( StaffType staffType, Staff newStaff ) 
            => staff[staffType].Add(newStaff);

        /// <summary>
        /// Used to add a new SCP object to the room
        /// </summary>
        /// <param name="scpType">The type that the new SCP is</param>
        /// <param name="newSCP">The actual scp object</param>
        public void AddScp(DangerLevel scpType, SCP newSCP) 
            => scps[scpType].Add(newSCP);

        /// <summary>
        /// Used to add money to the given player
        /// </summary>
        /// <param name="amount">The amount to add to the money</param>
        public void AddMoney(int amount) 
            => money += amount;
        
        /// <summary>
        /// Used to get the SCP by the name and the DangerLevel
        /// </summary>
        /// <param name="dangerLevel">The type that the SCP is</param>
        /// <param name="name">The name of the given SCP</param>
        /// <returns>Returns a given SCP object</returns>
        public SCP GetSCP(DangerLevel dangerLevel, string name) 
            => scps[dangerLevel].Find(scp => scp.Name == name);

        public SCP GetSCP(string name)
        {
            SCP targetSCP = null;
            for(int i = 0; i < scps.Values.Count; i++)
            {
                if(targetSCP != null)
                {
                    break;
                }

                targetSCP = scps[(DangerLevel)i].Find(scp => scp.Name == name);
            }
            return targetSCP;
        }

        /// <summary>
        /// Will return all of the scps of a given type...or all
        /// </summary>
        /// <param name="command">The danger level of the given scps</param>
        /// <returns>Returns the scps of that type</returns>
        public List<SCP> GetSCPs(string command)
        {
            List<SCP> allSCPs = new List<SCP>();

            if (command == "all")
            {
                allSCPs.AddRange(scps[DangerLevel.euclid]);
                allSCPs.AddRange(scps[DangerLevel.keter]);
                allSCPs.AddRange(scps[DangerLevel.safe]);
            }
            else if( command == "captured" )
            {
                allSCPs.AddRange(scps[DangerLevel.euclid].FindAll(scp => scp.Captured));
                allSCPs.AddRange(scps[DangerLevel.keter].FindAll(scp => scp.Captured));
                allSCPs.AddRange(scps[DangerLevel.safe].FindAll(scp => scp.Captured));
            }
            else if (command == "wanted")
            {
                allSCPs.AddRange(scps[DangerLevel.euclid].FindAll(scp => !scp.Captured));
                allSCPs.AddRange(scps[DangerLevel.keter].FindAll(scp => !scp.Captured));
                allSCPs.AddRange(scps[DangerLevel.safe].FindAll(scp => !scp.Captured));
            }
            else
            {
                return null;
            }
            return allSCPs;
        }

        /// <summary>
        /// Used to get the staff by the name and the staffType
        /// </summary>
        /// <param name="staffType">The type that the staff is</param>
        /// <param name="name">The name of the given staff</param>
        /// <returns>Returns a given staff object</returns>
        public Staff GetStaff(StaffType staffType, string name)
            => staff[staffType].Find(staff => staff.StaffName == name);

        public Staff GetStaff(string name)
        {
            Staff targetStaff = null;
            for (int i = 0; i < staff.Values.Count; i++)
            {
                if (targetStaff != null)
                {
                    break;
                }

                targetStaff = staff[(StaffType)i].Find(staff => staff.StaffName == name);
            }
            return targetStaff;
        }

        /// <summary>
        /// Will return all of the staff of a given type...or all
        /// </summary>
        /// <param name="staffType">The staff type of the given staff</param>
        /// <returns>Returns the staff of that type</returns>
        public List<Staff> GetStaff(StaffType staffType = StaffType.all)
        {
            if (staffType == StaffType.all)
            {
                List<Staff> allStaff = new List<Staff>();

                allStaff.AddRange(staff[StaffType.research]);
                allStaff.AddRange(staff[StaffType.security]);

                return allStaff;
            }
            return staff[staffType]; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a cell by name</returns>
        public Cell FindCell(int index)
            => FindCells()[index];

        /// <summary>
        /// 
        /// </summary>
        /// <returns>a list of every cell in the containment building</returns>
        public List<Cell> FindCells()
        {
            List<Cell> tempList = new List<Cell>();
            foreach (Floor block in building.Floors)
                if (block.FloorRoom is CellBlock tempCellBlock)
                    foreach (Cell cell in tempCellBlock.Cells)
                            tempList.Add(cell);

            return tempList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>a list of every empty cell in the containment building</returns>
        public List<Cell> FindOpenCells(Containment building)
        {
            List<Cell> tempList = new List<Cell>();
            foreach(Cell cell in FindCells(building))
            {
                if (cell.CellInhabitant == null)
                    tempList.Add(cell);
            }
            return tempList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>a list of every full cell in the containment building</returns>
        public List<Cell> FindFilledCells(Containment building)
        {
            List<Cell> tempList = new List<Cell>();
            foreach (Cell cell in FindCells(building))
            {
                if (cell.CellInhabitant != null)
                    tempList.Add(cell);
            }
            return tempList;
        }

        /// <summary>
        /// Used to get a command by name
        /// </summary>
        /// <param name="command">The command to get</param>
        /// <returns>Returns the command if it is found</returns>
        public RunCommand GetCommand(string command)
        {
            if (commands.ContainsKey(command))
                return commands[command];
            return null;
        }
    }
}
