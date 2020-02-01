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

        // Start is called before the first frame update
        void Start()
        {
            PauseMenu.SetActive(false);
            GameplayUI.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
