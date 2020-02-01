using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIManager : Singleton<UIManager>
    {
        public GameObject PauseMenu;
        public GameObject GameplayUI;
        public GameObject BuildingPreviewDisplay;
        public GameObject[] staffBuildings = new GameObject[3];
        public GameObject[] containmentBuildings = new GameObject[3];
        public GameObject[] researchBuildings = new GameObject[3];

        private GameObject m_currentStaffBuilding;
        private GameObject m_currentContainmentBuilding;
        private GameObject m_currentResearchBuilding;




        // Start is called before the first frame update
        void Start()
        {
            PauseMenu.SetActive(false);
            GameplayUI.SetActive(true);
            SetUpBuildingPreview();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SetUpBuildingPreview()
        {
            m_currentStaffBuilding = staffBuildings[0];
            m_currentContainmentBuilding = containmentBuildings[0];
            m_currentResearchBuilding = researchBuildings[0];

            m_currentStaffBuilding.SetActive(true);
            m_currentContainmentBuilding.SetActive(true);
            m_currentResearchBuilding.SetActive(true);
        }

        public bool UpdateBuilding()
        {
            return true;
        }
    }
}
