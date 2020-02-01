using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class Reseach : Buildings
{
	#region Fields
	private int level;
	private List<ResearchStaff> researchers;
	#endregion

	#region Properties
	public int Level { get { return level; } }
	public List<ResearchStaff> Researchers{	get { return researchers; }	}
	#endregion

	// Start is called before the first frame update
	void Start()
    {
		level = 1;
		researchers = new List<ResearchStaff>();
    }

	// Update is called once per frame
	void Update()
    {
        
    }

<<<<<<< HEAD
=======
	#region Methods
	public override void Upgrade()
	{
		level++;
	}

	public override void Destroy()
	{

	}

>>>>>>> 2f07ecc8158a3cbc49d121f0a30ccec29778ad44
	public void Research(ResearchStaff researcher, SCP scp)
	{

	}

	public void Research(ResearchStaff researcher, SCP scp, SecurityStaff security)
	{

	}
	#endregion
}
