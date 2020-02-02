using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class BuildingDisplayManager : MonoBehaviour
    {
        public GameObject[] staffBuildings = new GameObject[3];
        public GameObject[] containmentBuildings = new GameObject[3];
        public GameObject[] researchBuildings = new GameObject[3];
        public Button[] UpgradeButtons = new Button[3];

        public GameObject bottomFloor;
        public GameObject middleFloor;
        public GameObject topFloor;

        private List<GameObject> m_currentBuilding;
        public GameObject buildingDisplay;

        public int m_currentStaffLevel = 0;
        public int m_currentResearchLevel = 0;
        public int m_currentContainmentLevel = 0;



        // Start is called before the first frame update
        void Start()
        {
            SetUpBuildingPreview();
            for (int i = 0; i < 6; i++)
            {
                buildingDisplay.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SetUpBuildingPreview()
        {
            
            foreach (GameObject building in researchBuildings)
            {
                building.SetActive(false);
            }
            foreach (GameObject building in containmentBuildings)
            {
                building.SetActive(false);
            }
            foreach (GameObject building in staffBuildings)
            {
                building.SetActive(false);
            }
            staffBuildings[0].SetActive(true);
            containmentBuildings[0].SetActive(true);
            researchBuildings[0].SetActive(true);
        }

        public void UpgradeBuilding(int building)
        {
            if (building == (int)BuildingType.security)
            {
                if (m_currentStaffLevel < staffBuildings.Length - 1)
                {
                    m_currentStaffLevel += 1;
                    staffBuildings[m_currentStaffLevel].SetActive(true);
                    if (m_currentStaffLevel == staffBuildings.Length-1)
                    {
                        UpgradeButtons[0].gameObject.SetActive(false);
                    }
                }
                

            }
            else if (building == (int)BuildingType.research)
            {
                if (m_currentResearchLevel < researchBuildings.Length - 1)
                {
                    m_currentResearchLevel += 1;
                    researchBuildings[m_currentResearchLevel].SetActive(true);
                    if (m_currentResearchLevel == researchBuildings.Length-1)
                    {
                        UpgradeButtons[2].gameObject.SetActive(false);
                    }
                }

            }
            else if (building == (int)BuildingType.containment)
            {
                if (m_currentContainmentLevel < containmentBuildings.Length - 1)
                {
                    m_currentContainmentLevel += 1;
                    containmentBuildings[m_currentContainmentLevel].SetActive(true);
                    if (m_currentContainmentLevel == containmentBuildings.Length-1)
                    {
                        UpgradeButtons[1].gameObject.SetActive(false);
                    }
                }

            }
            
        }

        public void changeCurrentBuilding(int building)
        {
            for(int i = 0; i < 6; i++)
            {
                buildingDisplay.transform.GetChild(i).gameObject.SetActive(false);
            }
            buildingDisplay.transform.GetChild(0).gameObject.SetActive(true);
            switch (building)
            {
                case (int)BuildingType.containment:
                    if(m_currentContainmentLevel >= 1)
                    {
                        buildingDisplay.transform.GetChild(1).gameObject.SetActive(true);
                    }

                    if (m_currentContainmentLevel >= 2)
                    {
                        buildingDisplay.transform.GetChild(2).gameObject.SetActive(true);
                    }

                    if (m_currentContainmentLevel >= 3)
                    {
                        buildingDisplay.transform.GetChild(3).gameObject.SetActive(true);
                    }

                    if (m_currentContainmentLevel >= 4)
                    {
                        buildingDisplay.transform.GetChild(4).gameObject.SetActive(true);
                    }

                    if (m_currentContainmentLevel >= 5)
                    {
                        buildingDisplay.transform.GetChild(5).gameObject.SetActive(true);
                    }
                    break;
                case (int)BuildingType.research:
                    if (m_currentResearchLevel >= 1)
                    {
                        buildingDisplay.transform.GetChild(1).gameObject.SetActive(true);
                    }

                    if (m_currentResearchLevel >= 2)
                    {
                        buildingDisplay.transform.GetChild(2).gameObject.SetActive(true);
                    }

                    if (m_currentResearchLevel >= 3)
                    {
                        buildingDisplay.transform.GetChild(3).gameObject.SetActive(true);
                    }

                    if (m_currentResearchLevel >= 4)
                    {
                        buildingDisplay.transform.GetChild(4).gameObject.SetActive(true);
                    }

                    if (m_currentResearchLevel >= 5)
                    {
                        buildingDisplay.transform.GetChild(5).gameObject.SetActive(true);
                    }
                    break;
                case (int)BuildingType.security:
                    if (m_currentStaffLevel >= 1)
                    {
                        buildingDisplay.transform.GetChild(1).gameObject.SetActive(true);
                    }

                    if (m_currentStaffLevel >= 2)
                    {
                        buildingDisplay.transform.GetChild(2).gameObject.SetActive(true);
                    }

                    if (m_currentStaffLevel >= 3)
                    {
                        buildingDisplay.transform.GetChild(3).gameObject.SetActive(true);
                    }

                    if (m_currentStaffLevel >= 4)
                    {
                        buildingDisplay.transform.GetChild(4).gameObject.SetActive(true);
                    }

                    if (m_currentStaffLevel >= 5)
                    {
                        buildingDisplay.transform.GetChild(5).gameObject.SetActive(true);
                    }
                    break;
                default:
                    buildingDisplay.SetActive(false);
                    break;
            }
        }

        public void setBuildingColor(int building)
        {
            switch (building)
            {
                case (int)BuildingType.containment:
                    for (int i = 0; i < 2; i++)
                    {
                        
                    }
                    break;
            }
            
        }
    }
}
