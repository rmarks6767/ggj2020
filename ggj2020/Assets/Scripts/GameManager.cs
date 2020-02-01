using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public enum Staff
    {
        maintenance,
        research,
        security
    }

    public enum SCP
    {

    }


    class GameManager : Singleton<GameManager>
    {
        /// <summary>
        /// The money that the player will have
        /// </summary>
        public int Money { get; }
        private int money;

        private Dictionary<Staff, int> staff;
        
        public GameManager()
        {
            staff = new Dictionary<Staff, int>()
            {
                { Staff.maintenance, 0 },
                { Staff.research, 0 },
                { Staff.security, 0 }
            };
        }

        public void AddStaff( Staff staffType ) => staff[staffType]++;

        public void AddScp( SCP scpType ) => 

    }
}
