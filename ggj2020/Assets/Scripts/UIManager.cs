using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class UIManager : Singleton<UIManager>
    {
        public GameObject PauseMenu;
        public GameObject GameplayUI;
        public GameObject BuildingPreviewDisplay;

		// Resource Display Fields
		public TextMeshProUGUI moneyStatic;
		public TextMeshProUGUI scpStatic;
		public TextMeshProUGUI researcherStatic;
		public TextMeshProUGUI securityStatic;
		public TextMeshProUGUI moneyDynamic;
		public TextMeshProUGUI scpDynamic;
		public TextMeshProUGUI researcherDynamic;
		public TextMeshProUGUI securityDynamic;

        // Start is called before the first frame update
        void Start()
        {
            PauseMenu.SetActive(false);
            GameplayUI.SetActive(true);

			// Gets the starting values for each text object
			moneyDynamic.text = GameManager.Instance.Money.ToString();
			scpDynamic.text = GameManager.Instance.scpManager.ContainedScips.Count.ToString();
			researcherDynamic.text = GameManager.Instance.staffManager.researchStaff.Count.ToString();
			securityDynamic.text = GameManager.Instance.staffManager.securityStaff.Count.ToString();
		}

        // Update is called once per frame
        void Update()
        {
			// Updates values of all resources and personel
			moneyDynamic.text = GameManager.Instance.Money.ToString();
			scpDynamic.text = GameManager.Instance.scpManager.ContainedScips.Count.ToString();
			Debug.Log(GameManager.Instance.staffManager);
			researcherDynamic.text = GameManager.Instance.staffManager.researchStaff.Count.ToString();
			securityDynamic.text = GameManager.Instance.staffManager.securityStaff.Count.ToString();
		}
	}
}
