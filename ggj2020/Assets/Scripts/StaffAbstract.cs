using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StaffAbstract : MonoBehaviour
{
    public int level;
    public Staff type;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Fire();
}
