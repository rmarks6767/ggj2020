using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StaffAbstract : MonoBehaviour
{
    public int level;
    public Staff type;
    public int health;

    public enum Behavior
    {
        Wandering,
        Standing,
        Traveling
    }

    public Behavior currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = Behavior.Standing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Fire();
    public abstract void LevelUp();
}
