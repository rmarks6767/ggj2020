using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class Reseach : MonoBehaviour
{
	public int level;
	public List<ResearchStaff> researchers;

	// Start is called before the first frame update
	void Start()
    {
		researchers = new List<ResearchStaff>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Research(ResearchStaff researcher, SCP scp)
	{

	}

	public void Research(ResearchStaff researcher, SCP scp, SecurityStaff security)
	{

	}
}
