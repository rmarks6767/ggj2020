using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// The types of staff that exist
    /// </summary>
    public enum StaffType
    {
        research,
        security
    }

    /// <summary>
    /// The given danger level of an SCP
    /// </summary>
    public enum DangerLevel
    {
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
        [Header("Player Info")]
        public string playerName;
        public string siteName;
        public string location;

        [Header("Room Prefabs")]
        public GameObject researchRoomPrefab;
        public GameObject securityRoomPrefab;
        public GameObject cellBlockPrefab;

        [Header("Building Prefabs")]
        public GameObject researchBuildingPrefab;
        public GameObject securityBuildingPrefab;
        public GameObject containmentBuildingPrefab;

        [Header("Staff Prefabs")]
        public GameObject researchStaffPrefab;
        public GameObject securityStaffPrefab;
        public GameObject dClassPrefab;

        [Header("Etc")]
        public Transform screenLocation;

        /// <summary>
        /// The money that the player will have
        /// </summary>
        public int Money { get; }
        private int money;

        /// <summary>
        /// The staff that exist in the given room
        /// </summary>
        private Dictionary<StaffType, int> staff;

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
        /// List of all buildings
        /// </summary>
        private Dictionary<string, GameObject> buildings;

        public Dictionary<string, GameObject> Buildings
        {
            get { return buildings; }
        }

        /// <summary>
        /// GameManager will be a singleton and hold all of the money 
        /// and people in a given room
        /// </summary>
        void Start()
        {
            // Create the defaults for the staff
            staff = new Dictionary<StaffType, int>()
            {
                { StaffType.research, 0 },
                { StaffType.security, 0 }
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

            buildings = new Dictionary<string, GameObject>()
            {
                { "research", Instantiate(researchBuildingPrefab, screenLocation) },
                { "security", Instantiate(securityBuildingPrefab, screenLocation) },
                { "containment", Instantiate(containmentBuildingPrefab, screenLocation) }
            };

            playerName = "#%^$%&$&@";
            siteName = "%$^";
            location = "~/building/floor";
        }

        /// <summary>
        /// Used to increment the number of a given type plus one
        /// </summary>
        /// <param name="staffType">The type to increment</param>
        public void AddStaff( StaffType staffType ) 
            => staff[staffType]++;

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
        /// 
        /// </summary>
        /// <returns>a list of every cell in the containment building</returns>
        public List<Cell> FindCells()
        {
            List<Cell> output = new List<Cell>();
            Containment containment = buildings["containment"].GetComponent<Containment>();
            CellBlock cellBlock = null;
            foreach (GameObject floor in containment.Floors)
            {
                cellBlock = floor.GetComponent<CellBlock>();
                foreach (Cell cell in cellBlock.Cells)
                {
                        output.Add(cell);
                }
            }
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>a list of every empty cell in the containment building</returns>
        public List<Cell> FindOpenCells(Containment building)
        {
            List<Cell> output = new List<Cell>();
            Containment containment = buildings["containment"].GetComponent<Containment>();
            CellBlock cellBlock = null;
            foreach (GameObject floor in containment.Floors)
            {
                cellBlock = floor.GetComponent<CellBlock>();
                foreach (Cell cell in cellBlock.Cells)
                {
                    if (!cell.IsFilled)
                    {
                        output.Add(cell);
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>a list of every full cell in the containment building</returns>
        public List<Cell> FindFilledCells(Containment building)
        {
            List<Cell> output = new List<Cell>();
            Containment containment = buildings["containment"].GetComponent<Containment>();
            CellBlock cellBlock = null;
            foreach (GameObject floor in containment.Floors)
            {
                cellBlock = floor.GetComponent<CellBlock>();
                foreach (Cell cell in cellBlock.Cells)
                {
                    if (cell.IsFilled)
                    {
                        output.Add(cell);
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Used to get a given staff member
        /// </summary>
        /// <param name="staffType">The type to return</param>
        /// <returns>The number of staff of that type in the room</returns>
        public int GetStaff(StaffType staffType)
            => staff[staffType];

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
