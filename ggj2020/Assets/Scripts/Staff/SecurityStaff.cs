using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SecurityStaff : StaffAbstract
{
    Staff type;
    int level;
    int cost;
    // Start is called before the first frame update
    void Start()
    {
        //type = Staff.security;
        level = 1;
        cost = 400;
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
