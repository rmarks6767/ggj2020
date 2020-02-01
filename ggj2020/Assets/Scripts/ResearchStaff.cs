using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ResearchStaff : StaffAbstract
{
    Staff type;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        type = Staff.research;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Fire()
    {
        Destroy(this);
    }

    public override void LevelUp()
    {
        this.level++;
    }
}
