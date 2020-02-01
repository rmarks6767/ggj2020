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



        private GameObject m_currentBuilding;

        private int m_currentStaffLevel = 0;
        private int m_currentResearchLevel = 0;
        private int m_currentContainmentLevel = 0;



        // Start is called before the first frame update
        void Start()
        {
            SetUpBuildingPreview();
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
    }
}
