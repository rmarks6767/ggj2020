using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SCPManager : MonoBehaviour
{
    List<SCP> scips;
    List<SCP> wantedScips;
    List<SCP> containedScips;
    float timeElapsed;
    private Containment building;
    private Money money;
    private StaffManager sManager;
    
    public List<SCP> Scips
    {
        get { return scips; }
    }

    public List<SCP> WantedScips
    {
        get { return wantedScips; }
    }

    public List<SCP> ContainedScips
    {
        get {return containedScips; }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        building = GameManager.Instance.Buildings["containment"].GetComponent<Containment>();
        scips = new List<SCP>();
        wantedScips = new List<SCP>();
        containedScips = new List<SCP>();
        
        loadAllScips();

        foreach (SCP scip in scips)
        {
            GameManager.Instance.AddScp(scip.DL, scip);
            wantedScips.Add(scip);
        }
       

        AddSCPToScene(5);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 20)
        {
            timeElapsed = 0;
            foreach (SCP scip in containedScips)
            {
                if (building.GetComponent<Containment>().Floors[scip.ContainmentCell.Index / 10].GetComponent<CellBlock>().StaffCount
                    > Random.Range(0, 5000))
                {
                    BreachContainment(scip);
                }
            }
        }
        
    }

    public bool CaptureSCP(string name, Cell cell)
    {
        DangerLevel scipDL;
        for (int i = 0; i < wantedScips.Count; i++)
        {
            if (wantedScips[i].Name == name)
            {
                scipDL = wantedScips[i].DL;

                if (!cell.IsFilled)
                {
                    switch (cell.CellLevel)
                    {
                        case DangerLevel.keter:
                            return CaptureSCPHelper(cell, i);
                        case DangerLevel.euclid:
                            if (scipDL == DangerLevel.safe || scipDL == DangerLevel.euclid)
                            {
                                return CaptureSCPHelper(cell, i);
                            }
                            break;
                        case DangerLevel.safe:
                            if (scipDL == DangerLevel.safe)
                            {
                                return CaptureSCPHelper(cell, i);
                            }
                            break;
                    }
                    GameObject.FindGameObjectWithTag("Terminal").GetComponent<Terminal>().WriteToDisplay("The cell was not equipped to house this entity/object and it escaped.");
                    return false;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Terminal").GetComponent<Terminal>().WriteToDisplay("This cell was full, and the SCP escaped.");
                    return false;
                }
                
            }
        }
        GameObject.FindGameObjectWithTag("Terminal").GetComponent<Terminal>().WriteToDisplay("Internal Error; Target not located");
        return false;
    }

    private bool CaptureSCPHelper(Cell cell, int i)
    {
        if (wantedScips[i].AttemptCapture((int)Random.Range(0, 21)))
        {
            cell.ContainSCP(wantedScips[i]);
            wantedScips[i].Contained = true;
            containedScips.Add(wantedScips[i]);
            AddSCPToScene(i);
            wantedScips.RemoveAt(i);
            return true;
            //remove the SCP from the list and add it to an empty cell
        }
        else
        {
            wantedScips[i].CaptureDifficulty += 10;
            return false;
            //remove some security
        }
    }

    public void AddSCPToScene(int index)
    {
        GameObject newScip = new GameObject();
        newScip.AddComponent<ScipObject>();
        newScip.GetComponent<ScipObject>().number = wantedScips[index].Number;
        Instantiate(newScip, Vector3.zero, Quaternion.identity);
    }
    void loadAllScips()
    {
        scips.Add(new SCP(2, "plague-doctor", "049", DangerLevel.euclid, false));
        scips.Add(new SCP(1, "[unknown]", "055", DangerLevel.safe, false));
        scips.Add(new SCP(2, "cain", "073", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "able", "076", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "red-sea-object", "093", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "shy-guy", "096", DangerLevel.euclid, false));
        scips.Add(new SCP(3, "old-man", "106", DangerLevel.keter, false));
        scips.Add(new SCP(1, "eye-pods", "131", DangerLevel.safe, false));
        scips.Add(new SCP(2, "teenage-succubus", "166", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "statue", "173", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "coffee-machine", "294", DangerLevel.euclid, false));
        scips.Add(new SCP(1, "god", "343", DangerLevel.safe, false));
        scips.Add(new SCP(1, "aggressive-skin-condition", "420", DangerLevel.safe, false));
        scips.Add(new SCP(1, "panacea", "500", DangerLevel.safe, false));
        scips.Add(new SCP(1, "josie-the-half-cat", "529", DangerLevel.safe, false));
        scips.Add(new SCP(1, "butlers-hand-bell", "662", DangerLevel.safe, false));
        scips.Add(new SCP(4, "hard-to-destroy-reptile", "682", DangerLevel.keter, false));
        scips.Add(new SCP(2, "hanged-kings-tragedy", "701", DangerLevel.euclid, false));
        scips.Add(new SCP(1, "jaded-ring", "714", DangerLevel.euclid, false));
        scips.Add(new SCP(3, "maybe-there-monsters", "870", DangerLevel.keter, false));
        scips.Add(new SCP(1, "element-switching-pills", "049", DangerLevel.safe, false));
        scips.Add(new SCP(1, "clockworks", "914", DangerLevel.safe, false));
        scips.Add(new SCP(3, "with-many-voices", "939", DangerLevel.keter, false));
        scips.Add(new SCP(1, "tickle-monster", "999", DangerLevel.safe, false));
        scips.Add(new SCP(3, "bigfoot", "1000", DangerLevel.keter, false));
        scips.Add(new SCP(1, "patches", "1424", DangerLevel.safe, false));
        scips.Add(new SCP(1, "gas-mask", "1499", DangerLevel.safe, false));
        scips.Add(new SCP(2, "red-reality", "3001", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "garfield", "3166", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "redd-menace", "4601", DangerLevel.euclid, false));
        scips.Add(new SCP(3, "the-yule-man", "4666", DangerLevel.keter, false));
        scips.Add(new SCP(5, "watch-over-us", "4999", DangerLevel.keter, false));
    }

    void BreachContainment(SCP scip)
    {
        int penaltyMod = ((int)scip.DL * 20) + Random.Range(0, 40);

        scip.ContainmentCell.CellInhabitant = null;
        scip.ContainmentCell = null;
        scip.Contained = false;

        wantedScips.Add(scip);
        containedScips.Remove(scip);

        money.GainMoney(-penaltyMod);

        for (int i = 0; i < penaltyMod/40; i++)
        {
            sManager.StaffDied(
                building.GetComponent<Containment>().Floors[scip.ContainmentCell.Index / 10].GetComponent<CellBlock>().residentStaff[Random.Range(0,
                building.GetComponent<Containment>().Floors[scip.ContainmentCell.Index / 10].GetComponent<CellBlock>().residentStaff.Count)].GetInstanceID()
                );
        }

        GameObject.FindGameObjectWithTag("Terminal").GetComponent<Terminal>().WriteToDisplay("WARNING: "+" has escaped from confinenment! This has cost the site "+penaltyMod+" dollars in damages and we lost " + " staff members.") ;
    }
}