using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SCPManager : MonoBehaviour
{
    List<SCP> scips;
    List<SCP> wantedScips;
    List<SCP> containedScips;
    int rCount; //researcher count in the entire facility
    int sCount; //security count in the entire facility
    float timeElapsed;
    private Containment building;

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
                if (scip.ResearchLevel > Random.Range(0, 10000))
                {
                    scip.BreachContainment();
                }
            }
        }
        
    }

    public void CaptureSCP(string name, Cell cell)
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
                            CaptureSCPHelper(cell, i);
                            return;
                        case DangerLevel.euclid:
                            if (scipDL == DangerLevel.safe || scipDL == DangerLevel.euclid)
                            {
                                CaptureSCPHelper(cell, i);
                                return;
                            }
                            break;
                        case DangerLevel.safe:
                            if (scipDL == DangerLevel.safe)
                            {
                                CaptureSCPHelper(cell, i);
                                return;
                            }
                            break;
                    }
                    GameObject.FindGameObjectWithTag("Terminal").GetComponent<Terminal>().WriteToDisplay("The cell was not equipped to house this entity/object and it escaped.");
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Terminal").GetComponent<Terminal>().WriteToDisplay("This cell was full, and the SCP escaped.");
                }
                
            }
        }
    }

    private void CaptureSCPHelper(Cell cell, int i)
    {
        if (wantedScips[i].AttemptCapture((int)Random.Range(0, 21)))
        {
            cell.ContainSCP(wantedScips[i]);
            wantedScips[i].Contained = true;
            containedScips.Add(wantedScips[i]);
            AddSCPToScene(i);
            wantedScips.RemoveAt(i);
            //remove the SCP from the list and add it to an empty cell
        }
        else
        {
            wantedScips[i].CaptureDifficulty += 10;
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
        scips.Add(new SCP(2, "Plague Doctor", "049", DangerLevel.euclid, false));
        scips.Add(new SCP(1, "[unknown]", "055", DangerLevel.safe, false));
        scips.Add(new SCP(2, "Cain", "073", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "Able", "076", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "Red Sea Object", "093", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "The Shy Guy", "096", DangerLevel.euclid, false));
        scips.Add(new SCP(3, "The Old Man", "106", DangerLevel.keter, false));
        scips.Add(new SCP(1, "The Eye Pods", "131", DangerLevel.safe, false));
        scips.Add(new SCP(2, "Teenage Succubus", "166", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "The Statue", "173", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "The Coffee Machine", "294", DangerLevel.euclid, false));
        scips.Add(new SCP(1, "God", "343", DangerLevel.safe, false));
        scips.Add(new SCP(1, "Aggressive Skin Condition", "420", DangerLevel.safe, false));
        scips.Add(new SCP(1, "panacea", "500", DangerLevel.safe, false));
        scips.Add(new SCP(1, "Josie the Half-Cat", "529", DangerLevel.safe, false));
        scips.Add(new SCP(1, "Butler's Hand Bell", "662", DangerLevel.safe, false));
        scips.Add(new SCP(4, "Hard-To-Destroy Reptile", "682", DangerLevel.keter, false));
        scips.Add(new SCP(2, "The Hanged King's Tragedy", "701", DangerLevel.euclid, false));
        scips.Add(new SCP(1, "The Jaded Ring", "714", DangerLevel.euclid, false));
        scips.Add(new SCP(3, "Maybe There Monsters", "870", DangerLevel.keter, false));
        scips.Add(new SCP(1, "Element-Switching Pills", "049", DangerLevel.safe, false));
        scips.Add(new SCP(1, "The Clockworks", "914", DangerLevel.safe, false));
        scips.Add(new SCP(3, "With Many Voices", "939", DangerLevel.keter, false));
        scips.Add(new SCP(1, "The Tickle Monster", "999", DangerLevel.safe, false));
        scips.Add(new SCP(3, "Bigfoot", "1000", DangerLevel.keter, false));
        scips.Add(new SCP(1, "Patches", "1424", DangerLevel.safe, false));
        scips.Add(new SCP(1, "The Gas Mask", "1499", DangerLevel.safe, false));
        scips.Add(new SCP(2, "Red Reality", "3001", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "Garfield", "3166", DangerLevel.euclid, false));
        scips.Add(new SCP(2, "Revenge of the Redd Menace", "4601", DangerLevel.euclid, false));
        scips.Add(new SCP(3, "The Yule Man", "4666", DangerLevel.keter, false));
        scips.Add(new SCP(5, "Someone to Watch Over Us", "4999", DangerLevel.keter, false));
    }

    
}