using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureSwap : MonoBehaviour
{
    public List<GameObject> screens;

    private int currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentScreen = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoom(int roomPosition)
    {
        for(int x = 0; x<screens.Count; x++)
        {
            if(x == roomPosition)
            {
                screens[x].transform.position = new Vector3(screens[x].transform.position.x, screens[x].transform.position.y, -9);
            }
            else
            {
                screens[x].transform.position = new Vector3(screens[x].transform.position.x, screens[x].transform.position.y, 9);
            }
        }
    }

    
}
