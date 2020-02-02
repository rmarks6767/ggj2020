﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ResearchStaff : StaffAbstract
{
    StaffType type;
    int level;
    int cost;
    // Start is called before the first frame update
    void Start()
    {
        type = StaffType.research;
        level = 1;
        cost = 600;
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
