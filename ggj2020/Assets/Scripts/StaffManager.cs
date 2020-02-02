using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class StaffManager : MonoBehaviour
    {
        public int researchPayRate = 15;
        public int securityPayRate = 10;

        public int researchCost = 150;
        public int securityCost = 100;

        public float researchValue = .5f;

        public GameObject staffPrefab;
        public GameObject cellBlockPrefab;
        public GameObject containmentBuilding;
        public GameObject gameManagerObject;

        public Dictionary<int, GameObject> securityStaff = new Dictionary<int, GameObject>();
        public Dictionary<int, GameObject> researchStaff = new Dictionary<int, GameObject>();
        

        private List<string> firstNameList = new List<string>();
        private List<string> lastNameList = new List<string>();


        private int StaffIdCounter = 0;


        // Start is called before the first frame update
        void Start()
        {
			
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void GenerateResearch()
        {
            int moneyTotal = 0;
            List<GameObject> currentFloorStaff;
            GameObject currentCellBlockHolder;

            List<DangerLevel> dangerLevelOfScp = new List<DangerLevel>();
            List<int> tiersOfResearchers = new List<int>();

            for (int i = 0; i < containmentBuilding.GetComponent<Containment>().Floors.Count; i++)
            {
                dangerLevelOfScp.Clear();
                tiersOfResearchers.Clear();

                currentFloorStaff = containmentBuilding.GetComponent<Containment>().Floors[i].GetComponent<CellBlock>().residentStaff;

                currentCellBlockHolder = containmentBuilding.GetComponent<Containment>().Floors[i];
                for (int y = 0; y < currentCellBlockHolder.GetComponent<CellBlock>().Cells.Count; y++)
                {
                    if (currentCellBlockHolder.GetComponent<CellBlock>().Cells[y].IsFilled)
                    {
                        dangerLevelOfScp.Add(currentCellBlockHolder.GetComponent<CellBlock>().Cells[y].CellInhabitant.DL);
                    }
                }

                for (int x = 0; x < currentFloorStaff.Count; x++)
                {
                    if (currentFloorStaff[i].GetComponent<Staff>().type == StaffType.research)
                    {
                        tiersOfResearchers.Add(currentFloorStaff[i].GetComponent<Staff>().tier);
                    }
                }

                int scpValue = 0;
                //Add SCP Values
                for (int z = 0; z < dangerLevelOfScp.Count; z++)
                {
                    scpValue += (int)dangerLevelOfScp[z];
                }

                int researcherTierValue = 0;
                // Add researcher tiers
                for (int z = 0; z < tiersOfResearchers.Count; z++)
                {
                    researcherTierValue += tiersOfResearchers[z];
                }


                // Add to money total
                moneyTotal += (int)(scpValue + researcherTierValue * researchValue);

            }
            gameManagerObject.GetComponent<Money>().GainMoney(moneyTotal);
        }

        public void moveStaff(GameObject staff, GameObject endDestination)
        {
            GameObject currentLocation = staff.GetComponent<Staff>().currentLocation;

            currentLocation.GetComponent<Floor>().residentStaff.Remove(staff);


            endDestination.GetComponent<Floor>().residentStaff.Add(staff);

            staff.GetComponent<Staff>().AssignLocation(endDestination);

            staff.GetComponent<Staff>().currentLocation = endDestination;
            


        }
        
        public void AddStaff(GameObject roomToMoveTo, StaffType type)
        {
            GameObject newStaff = Instantiate(staffPrefab);

            newStaff.GetComponent<Staff>().AssignRole(type);

            newStaff.GetComponent<Staff>().AssignData(RandomlySelectName(), StaffIdCounter);

            StaffIdCounter++;

            // IF YOU WANT TO PUT TIER DATA IN FUTURE ENTER IT HERE

            if (type == StaffType.research)
            {
                researchStaff.Add(newStaff.GetComponent<Staff>().iD, newStaff);

            }
            else if (type == StaffType.security)
            {
                securityStaff.Add(newStaff.GetComponent<Staff>().iD, newStaff);
            }

            newStaff.GetComponent<Staff>().AssignLocation(roomToMoveTo);
            newStaff.GetComponent<Staff>().currentLocation = roomToMoveTo;
            roomToMoveTo.GetComponent<Floor>().residentStaff.Add(newStaff);
            
        }



        /// <summary>
        /// Returns a full name as a string 
        /// </summary>
        /// <returns></returns>
        public string RandomlySelectName()
        {
            string firstName;
            string lastName;

            firstName = firstNameList[Random.Range(0, firstNameList.Count)];
            lastName = lastNameList[Random.Range(0, lastNameList.Count)];

            return firstName + " " + lastName;
        }

		/// <summary>
		/// Finds the dead staff member and removes them from the scene
		/// </summary>
		/// <param name="id">The id of the dead staff member</param>
		public void StaffDied(int id)
		{
			// Finds dead member
			GameObject deadStaffMember = null;

			foreach(KeyValuePair<int, GameObject> pair in researchStaff)
			{
				if(pair.Key == id)
				{
					deadStaffMember = pair.Value;
					break;
				}
			}

			foreach(KeyValuePair<int, GameObject> pair in securityStaff)
			{
				// if the dead staff member was found, it breaks out of this loop
				if(deadStaffMember != null)
					break;

				if(pair.Key == id)
				{
					deadStaffMember = pair.Value;
					break;
				}
			}

			// Checks if the dead staff member was found
			if(deadStaffMember == null)
				return;

			// Removes Member from Room
		}

        /// <summary>
        /// Fils the list with random Names
        /// </summary>
        private void FillNameListS()
        {
            firstNameList.Add("Darragh");
            firstNameList.Add("Fay");
            firstNameList.Add("Teodor");
            firstNameList.Add("Izabella");
            firstNameList.Add("Mercy");
            firstNameList.Add("Ayse");
            firstNameList.Add("Dolores");
            firstNameList.Add("Anjali");
            firstNameList.Add("Daniella");
            firstNameList.Add("Katie");
            firstNameList.Add("Huzaifah");
            firstNameList.Add("Connah");
            firstNameList.Add("Shabaz");
            firstNameList.Add("Murtaza");
            firstNameList.Add("August");
            firstNameList.Add("Lewis");
            firstNameList.Add("Sammy");
            firstNameList.Add("Humera");
            firstNameList.Add("Bree");
            firstNameList.Add("Yuvaan");
            firstNameList.Add("Sarah");
            firstNameList.Add("Leilani");
            firstNameList.Add("Marcus");
            firstNameList.Add("Elsa");
            firstNameList.Add("Emeli");
            firstNameList.Add("Aminah");
            firstNameList.Add("Sumaiyah");
            firstNameList.Add("Vladimir");
            firstNameList.Add("Nevaeh");
            firstNameList.Add("Marguerite");
            firstNameList.Add("Nikodem");
            firstNameList.Add("Maxwell");
            firstNameList.Add("Dev");
            firstNameList.Add("Avneet");
            firstNameList.Add("Lorena");
            firstNameList.Add("Pia");
            firstNameList.Add("Emilija");
            firstNameList.Add("Tiah");
            firstNameList.Add("Willow");
            firstNameList.Add("Neriah");
            firstNameList.Add("Freja");
            firstNameList.Add("Andrea");
            firstNameList.Add("Elinor");
            firstNameList.Add("Ernest");
            firstNameList.Add("Kylan");
            firstNameList.Add("Jevan");
            firstNameList.Add("Sid");
            firstNameList.Add("Keegan");
            firstNameList.Add("Grayson");
            firstNameList.Add("Santino");
            firstNameList.Add("Nansi");
            firstNameList.Add("Velma");
            firstNameList.Add("Krish");
            firstNameList.Add("Shiv");
            firstNameList.Add("Nicola");
            firstNameList.Add("Chandler");
            firstNameList.Add("Tracey");
            firstNameList.Add("Kylo");
            firstNameList.Add("Hamzah");
            firstNameList.Add("Benn");
            firstNameList.Add("Mia");
            firstNameList.Add("Stanislaw");
            firstNameList.Add("Asim");
            firstNameList.Add("Lilli");
            firstNameList.Add("Kayden");
            firstNameList.Add("Rosalie");
            firstNameList.Add("Ajwa");
            firstNameList.Add("Lara");
            firstNameList.Add("Aiesha");
            firstNameList.Add("Carson");
            firstNameList.Add("Kyra");
            firstNameList.Add("Rubi");
            firstNameList.Add("Theodora");
            firstNameList.Add("Efan");
            firstNameList.Add("Ed");
            firstNameList.Add("Alaya");
            firstNameList.Add("Talia");
            firstNameList.Add("Darnell");
            firstNameList.Add("Caitlyn");
            firstNameList.Add("Alysha");
            firstNameList.Add("Azaan");
            firstNameList.Add("Rueben");
            firstNameList.Add("Layla");
            firstNameList.Add("Violet");
            firstNameList.Add("Karson");
            firstNameList.Add("Leigh");
            firstNameList.Add("Jareth");
            firstNameList.Add("Kelly");
            firstNameList.Add("Eoghan");
            firstNameList.Add("Aneesah");
            firstNameList.Add("Kaine");
            firstNameList.Add("Howard");
            firstNameList.Add("Andrei");
            firstNameList.Add("Jackson");
            firstNameList.Add("Nabiha");
            firstNameList.Add("Rhiannan");

            lastNameList.Add("Lister");
            lastNameList.Add("Moody");
            lastNameList.Add("Croft");
            lastNameList.Add("Roth");
            lastNameList.Add("Adam");
            lastNameList.Add("Espinoza");
            lastNameList.Add("Moses");
            lastNameList.Add("Howe");
            lastNameList.Add("Simon");
            lastNameList.Add("Snyder");
            lastNameList.Add("Bush");
            lastNameList.Add("Pitts");
            lastNameList.Add("Person");
            lastNameList.Add("Huang");
            lastNameList.Add("Logan");
            lastNameList.Add("Williams");
            lastNameList.Add("Norton");
            lastNameList.Add("Mendoza");
            lastNameList.Add("Winter");
            lastNameList.Add("Nelson");
            lastNameList.Add("Camacho");
            lastNameList.Add("Reynolds");
            lastNameList.Add("Hawkins");
            lastNameList.Add("Hardy");
            lastNameList.Add("Wainwright");
            lastNameList.Add("Arias");
            lastNameList.Add("Wilks");
            lastNameList.Add("Yang");
            lastNameList.Add("Forbes");
            lastNameList.Add("Leech");
            lastNameList.Add("Andrade");
            lastNameList.Add("Barr");
            lastNameList.Add("Alexander");
            lastNameList.Add("Carroll");
            lastNameList.Add("Jefferson");
            lastNameList.Add("Hancock");
            lastNameList.Add("Velazquez");
            lastNameList.Add("Henry");
            lastNameList.Add("Gamble");
            lastNameList.Add("Wiley");
            lastNameList.Add("Garrett");
            lastNameList.Add("Barnes");
            lastNameList.Add("Lester");
            lastNameList.Add("Penn");
            lastNameList.Add("Medina");
            lastNameList.Add("Gibson");
            lastNameList.Add("Guzman");
            lastNameList.Add("Fernandez");
            lastNameList.Add("Maguire");
            lastNameList.Add("Bishop");
            lastNameList.Add("Cunningham");
            lastNameList.Add("Whitley");
            lastNameList.Add("Chapman");
            lastNameList.Add("Rodriquez");
            lastNameList.Add("Snow");
            lastNameList.Add("Stokes");
            lastNameList.Add("Hills");
            lastNameList.Add("Farley");
            lastNameList.Add("Cooke");
            lastNameList.Add("Sutherland");
            lastNameList.Add("Reader");
            lastNameList.Add("Hensley");
            lastNameList.Add("Truong");
            lastNameList.Add("Phillips");
            lastNameList.Add("Shepard");
            lastNameList.Add("Ellison");
            lastNameList.Add("Rivas");
            lastNameList.Add("Bentley");
            lastNameList.Add("Davie");
            lastNameList.Add("Castaneda");
            lastNameList.Add("Ramirez");
            lastNameList.Add("Greig");
            lastNameList.Add("Key");
            lastNameList.Add("Nielsen");
            lastNameList.Add("Bob");
            lastNameList.Add("Medrano");
            lastNameList.Add("Steele");
            lastNameList.Add("Moreno");
            lastNameList.Add("Nairn");
            lastNameList.Add("Chavez");
            lastNameList.Add("Alfaro");
            lastNameList.Add("Allen");
            lastNameList.Add("Jeffery");
            lastNameList.Add("Stark");
            lastNameList.Add("Connolly");
            lastNameList.Add("Nicholson");
            lastNameList.Add("Casey");
            lastNameList.Add("Garner");
            lastNameList.Add("Robbins");
            lastNameList.Add("Whitney");
            lastNameList.Add("Beech");
            lastNameList.Add("Fletcher");
            lastNameList.Add("Riddle");
            lastNameList.Add("Bernal");
            lastNameList.Add("Gates");
            lastNameList.Add("North");
        }



    }
}
