using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class PictureSwap : MonoBehaviour
    {
        private GameObject currentScene, currentBuilding;
        private int currentFloor;

        // Start is called before the first frame update
        void Start()
        {
            currentScene = GameManager.Instance.SiteMap;
            currentBuilding = null;
            currentFloor = -1;

            Display();
        }

        public bool MoveToFloor(int roomPosition)
        {
            if (currentBuilding != null &&
                roomPosition < currentBuilding.GetComponent<Buildings>().Floors.Count &&
                roomPosition >= 0)
            {
                currentFloor = roomPosition;
                Display();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveToBuilding(string buildingName)
        {
            if (GameManager.Instance.Buildings.ContainsKey(buildingName))
            {
                currentBuilding = GameManager.Instance.Buildings[buildingName];
                currentFloor = -1;
                Display();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoveToMap()
        {
            currentBuilding = null;
            currentFloor = -1;

            Display();
        }

        public bool MoveOut()
        {
            if(currentBuilding == null)
            {
                return false;
            }
            else
            {
                if(currentFloor == -1)
                {
                    MoveToMap();
                }
                else
                {
                    MoveToBuilding(currentBuilding.GetComponent<Buildings>().Name.ToLower());
                }
                return true;
            }
        }

        private void Display()
        {
            UpdateLocation();
            currentScene.transform.position = new Vector3(currentScene.transform.position.x, currentScene.transform.position.y, 0);
            if(currentBuilding == null)
            {
                currentScene = GameManager.Instance.SiteMap;
            }
            else
            {
                if(currentFloor == -1)
                {
                    currentScene = currentBuilding;
                }
                else
                {
                    currentScene = currentBuilding.GetComponent<Buildings>().Floors[currentFloor];
                }
            }
            currentScene.transform.position = new Vector3(currentScene.transform.position.x, currentScene.transform.position.y, -5);
        }

        private void UpdateLocation()
        {
            if(currentBuilding == null)
            {
                GameManager.Instance.location = "~";
            }
            else
            {
                GameManager.Instance.location = $"~/{currentBuilding.GetComponent<Buildings>().Name}";

                if (currentFloor != -1)
                {
                    GameManager.Instance.location += $"/{currentFloor}";
                }
            }
        }
    }
}
