using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SCPWanted
{
    int rCount; //researcher count in the entire facility
    int sCount; //security count in the entire facility
    SCP scip; //the SCP that is wanted
    DangerLevel cellNeeded; //the level of cell needed for this scip
    int captureDifficulty; //the percentage chance that the capture attempt succeeds
    Random rand;

    public int ResearcherCount
    {
        get
        {
            return rCount;
        }
        set
        {
            rCount = value;
        }
    }

    public int SecurityCount
    {
        get
        {
            return sCount;
        }
        set
        {
            sCount = value;
        }
    }

    public SCP Scip
    {
        get
        {
            return scip;
        }
    }

    public DangerLevel CellNeeded
    {
        get
        {
            return cellNeeded;
        }
    }

    public int CaptureDifficulty
    {
        get
        {
            return captureDifficulty;
        }
        set
        {
            captureDifficulty = value;
        }
    }

    public SCPWanted(SCP scip)
    {
        this.scip = scip;
        ResearcherCount = GameManager.Instance.GetStaff(Staff.research);
        SecurityCount = GameManager.Instance.GetStaff(Staff.security);
        cellNeeded = scip.DL;

        rand = new Random();

        //capture difficulty
        captureDifficulty = 0;
        switch (scip.DL)
        {
            case DangerLevel.keter:
                captureDifficulty += 100;
                break;
            case DangerLevel.euclid:
                captureDifficulty += 60;
                break;
            case DangerLevel.safe:
                captureDifficulty += 30;
                break;
        }
        if (captureDifficulty > SecurityCount*2)
        {
            captureDifficulty -= SecurityCount*2;
        }
        else
        {
            captureDifficulty = 1;
        }
    }

    public bool AttemptCapture(int environmentDanger)
    {
        int tempRand = (int)Random.Range(0, 101);
        if (tempRand>captureDifficulty)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
