using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class StaffBuilding : Buildings
{
    public int maxStaff;
    public int currentStaff;

    //Change this to List<Staff> once we have a Staff class
    Dictionary<int, List<Staff>> StaffMembers;
    // Start is called before the first frame update
    void Start()
    {
        maxStaff = 10;
        currentStaff = 0;
        StaffMembers = new Dictionary<int, List<Staff>>();
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
        StaffMembers = null;
        this.Destroy();
    }

    public void addStaffToBuilding(int floor, Staff staff)
    {
        StaffMembers[floor].Add(staff);
    }

    public void removeStaffFromBuilding(int floor, Staff staff)
    {
        StaffMembers[floor].Remove(staff);
    }

    public void addFloor()
    {
        StaffMembers.Add(StaffMembers.Count, new List<Staff>());
    }
}
