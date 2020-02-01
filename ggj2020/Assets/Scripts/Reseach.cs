using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class Reseach : Buildings
{
	#region Fields
	private int level;
	private List<ResearchStaff> researchers;
	private int maxResearchers;
	private int currentResearchers;
	#endregion

	#region Properties
	public int Level { get { return level; } }
	public List<ResearchStaff> Researchers{	get { return researchers; }	}
	public int MaxResearchers { get { return maxResearchers; } }
	public int CurrentResearchers { get { return currentResearchers; } }
	#endregion

	// Start is called before the first frame update
	void Start()
    {
		level = 1;
		researchers = new List<ResearchStaff>();
		maxResearchers = 10;
		currentResearchers = 0;
    }

	// Update is called once per frame
	void Update()
    {
        
    }

	#region Methods
	/// <summary>
	/// When Upgraded, the level of the research building will 
	/// increase by 1, and the number of max researchers will 
	/// increase by 10
	/// </summary>
	public override void Upgrade()
	{
		level++;
		maxResearchers += 10;
	}

	public override void Destroy()
	{
		throw new System.NotImplementedException();
	}

	public void Research(ResearchStaff researcher, SCP scp)
	{
		if(researcher.level >= scp.ResearchLevel)
		{

		}
	}

	public void Research(ResearchStaff researcher, SCP scp, SecurityStaff security)
	{
		if(researcher.level >= scp.ResearchLevel)
		{

		}
	}
	#endregion
}
