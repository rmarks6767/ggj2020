using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffBuilding : Buildings
{
    public int maxStaff;
    public int currentStaff;

    //Change this to List<Staff> once we have a Staff class
    public List<int> StaffMembers;
    // Start is called before the first frame update
    void Start()
    {
        maxStaff = 10;
        currentStaff = 0;
        StaffMembers = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Upgrade()
    {
        maxStaff += 10;
    }

    public override void Destroy()
    {
        StaffMembers.RemoveRange(0, StaffMembers.Count);
        this.Destroy();
    }
}
