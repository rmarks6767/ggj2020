using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureSwap : MonoBehaviour
{

    private GameObject inPicture;
    private GameObject offScreen;
    public List<GameObject> rooms;


    // Start is called before the first frame update
    void Start()
    {
        inPicture = GameObject.Find("InPicture");
        offScreen = GameObject.Find("OffScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeRoom(0);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeRoom(1);
        }
    }

    public void ChangeRoom(int roomPosition)
    {
        for(int x = 0; x<rooms.Count; x++)
        {
            if(x == roomPosition)
            {
                rooms[x].transform.position = inPicture.transform.position;
            }
            else
            {
                rooms[x].transform.position = offScreen.transform.position;
            }
        }
    }

    
}
