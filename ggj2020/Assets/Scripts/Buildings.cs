using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buildings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Current level Of building upgrade
    /// </summary>
    public int BuildingLevel;


    public abstract void Upgrade();

    public abstract void Destroy();

    

}
