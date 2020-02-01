using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SCP
{
    private int researchLevel;
    private string name;
    private string number;
    private string containmentProcedures;
    private string description;
    DangerLevel DL;

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

    public SCP(int researchLevel, string name, string number, DangerLevel DL)
    {
        this.researchLevel = researchLevel;
        this.name = name;
        this.number = number;
        this.DL = DL;
    }

    public DangerLevel getDangerLevel()
    {
        return DL;
    }

    public override string ToString()
    {
        return "SCP: " + number + " - '" + name + "'";
    }
}
