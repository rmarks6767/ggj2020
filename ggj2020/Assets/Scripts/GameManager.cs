using System.Collections.Generic;

namespace Assets.Scripts
{
    /// <summary>
    /// The types of staff that exist
    /// </summary>
    public enum Staff
    {
        maintenance,
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

    public delegate string RunCommand(List<string> parameters);

    class GameManager : Singleton<GameManager>
    {
        /// <summary>
        /// The money that the player will have
        /// </summary>
        public int Money { get; }
        private int money;

        /// <summary>
        /// The staff that exist in the given room
        /// </summary>
        private Dictionary<Staff, int> staff;

        /// <summary>
        /// The scps that are active in the given room
        /// </summary>
        private Dictionary<DangerLevel, List<SCP>> scps;

        /// <summary>
        /// List of all valid commands and the functions that correlate to the command
        /// </summary>
        private Dictionary<string, RunCommand> commands;

        /// <summary>
        /// GameManager will be a singleton and hold all of the money 
        /// and people in a given room
        /// </summary>
        public GameManager()
        {
            // Create the defaults for the staff
            staff = new Dictionary<Staff, int>()
            {
                { Staff.maintenance, 0 },
                { Staff.research, 0 },
                { Staff.security, 0 }
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
                {"capture", RunCommands.CaptureSCP},
                {"list", RunCommands.List},
                {"change room", RunCommands.ChangeRoom}
            };
        }

        /// <summary>
        /// Used to increment the number of a given type plus one
        /// </summary>
        /// <param name="staffType">The type to increment</param>
        public void AddStaff( Staff staffType ) 
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
        /// Used to get a given staff member
        /// </summary>
        /// <param name="staffType">The type to return</param>
        /// <returns>The number of staff of that type in the room</returns>
        public int GetStaff(Staff staffType)
            => staff[staffType];

        /// <summary>
        /// Used to get a command by name
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public RunCommand GetCommand(string command)
            => commands[command];
    }
}
