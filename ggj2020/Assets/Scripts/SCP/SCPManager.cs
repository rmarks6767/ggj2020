using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCPManager : MonoBehaviour
{
    List<SCPWanted> scips;

    // Start is called before the first frame update
    void Start()
    {
        scips = new List<SCPWanted>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScip()
    {
        /**
         * Add the SCP to the list
         * generate a random terrain difficulty
         */
    }

    public void AddScip(SCP scip)
    {
        /**
         * Add the SCP to the list
         * generate a random terrain difficulty
         */
    }

    public void CaptureSCP(string name)
    {
        foreach (SCPWanted scip in scips)
        {
            if (scip.Scip.Name == name)
            {
                if(scip.AttemptCapture((int)Random.Range(0, 21)))
                {
                    //remove the SCP from the list and add it to an empty cell
                }
                else
                {
                    scip.CaptureDifficulty += 10;
                    //remove some security
                }
                return;
            }
        }
    }
}
