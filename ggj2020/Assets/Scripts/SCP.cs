using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SCP
{
    int researchLevel;
    string name;
    string number;
    string containmentProcedures;
    string description;
    DangerLevel dl;

    //defines how valuable the SCP is for researching
    public int ResearchLevel
    {
        get
        {
            return researchLevel;
        }
        set
        {
            researchLevel = value;
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

    //constructor for the SCP, defines all necessary parameters
    public SCP(int researchLevel, string name, string number, DangerLevel dl)
    {
        this.researchLevel = researchLevel;
        this.name = name;
        this.number = number;
        this.dl = dl;
    }

    //ToString formatted to the SCP
    public override string ToString()
    {
        return "SCP: " + number + " - '" + name + "'";
    }
}
