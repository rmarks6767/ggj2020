using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP
{
    int researchLevel;
    string name;
    string number;
    string containmentProcedures;
    string description;
    DangerLevel DL;

    public SCP(int researchLevel, string name, string number, DangerLevel DL)
    {
        this.researchLevel = researchLevel;
        this.name = name;
        this.number = number;
        this.DL = DL;
    }

    public int getResearchLevel()
    {
        return researchLevel;
    }

    public string getName()
    {
        return name;
    }

    public string getNumber()
    {
        return number;
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
