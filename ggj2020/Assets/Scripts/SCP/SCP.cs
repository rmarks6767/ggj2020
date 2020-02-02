using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SCP
{
    int escapeChance; // the amount of research the player can gain from this SCP
    int captureDifficulty; //the percentage chance that the capture attempt succeeds
    string name;
    string number;
    string containmentProcedures;
    string description;
    bool contained;
    DangerLevel dl;
    Cell containmentCell;

    //defines how valuable the SCP is for researching
    public int EscapeChance
    {
        get
        {
            return escapeChance;
        }
        set
        {
            escapeChance = value;
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

    //the nickname of the SCP, usually 'The ____'
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    //the unique number assigned to the SCP, it's official name
    public string Number
    {
        get
        {
            return number;
        }
        set
        {
            number = value;
        }
    }

    //the danger level of the SCP, either SAFE, EUCLID, or KETER
    public DangerLevel DL
    {
        get
        {
            return dl;
        }
        set
        {
            dl = value;
        }
    }

    public Cell ContainmentCell
    {
        get
        {
            return containmentCell;
        }
        set
        {
            containmentCell = value;
        }
    }

    public bool Contained
    {
        get
        {
            return contained;
        }
        set
        {
            contained = value;
        }
    }

    //constructor for the SCP, defines all necessary parameters
    public SCP(int escapeChance, string name, string number, DangerLevel dl, bool contained)
    {
        this.escapeChance = escapeChance;
        this.name = name;
        this.number = number;
        this.dl = dl;
        this.contained = contained;

        if (!contained)
        {
            //capture difficulty
            captureDifficulty = 0;
            switch (DL)
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
            if (captureDifficulty > GameManager.Instance.GetStaff(StaffType.security).Count * 2)
            {
                captureDifficulty -= GameManager.Instance.GetStaff(StaffType.security).Count * 2;
            }
            else
            {
                captureDifficulty = 1;
            }
        }
    }

    //ToString formatted to the SCP
    public override string ToString()
    {
        return "SCP: " + number + " - '" + name + "'";
    }

    /// <summary>
    /// Attempts to capture an SCP
    /// </summary>
    /// <param name="environmentDanger">added difficulty to capturing the SCP</param>
    /// <returns></returns>
    public bool AttemptCapture(int environmentDanger)
    {
        int tempRand = (int)Random.Range(0, 101);
        if (tempRand > captureDifficulty + environmentDanger)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
