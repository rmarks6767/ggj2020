using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Money : MonoBehaviour
{
	#region Fields
	// Managers
	GameManager gm;
	StaffManager sm;

	// Timer/Payroll Variables
	float startTime;
	public float payrollRate;
	#endregion

	// Start is called before the first frame update
	void Start()
    {
		// Initialize GameManager
		// Initialize StaffManager
		startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >= payrollRate)
		{
			Payroll();
			startTime = Time.time;
		}
    }

	#region Methods
	/// <summary>
	/// A simple way to increase money of the GameManager
	/// </summary>
	/// <param name="moneyGained">The amount gained</param>
	public void GainMoney(int moneyGained)
	{
		// Adds moneyGained to money field of GameManager
		gm.AddMoney(moneyGained);
	}

	/// <summary>
	/// A simple way to deduct money from the GameManager
	/// </summary>
	/// <param name="moneyLost">The amount lost</param>
	public void LoseMoney(int moneyLost)
	{
		// Removes moneyLost to money field of GameManager
		gm.AddMoney(-moneyLost);
	}

	/// <summary>
	/// Charges the player an amount after so much time, 
	/// based on the type of staff member and its tier
	/// </summary>
	public void Payroll()
	{
		int totalPayroll = 0;

		// Loops thr both Dictionaries and 
		foreach(GameObject researcher in sm.researchStaff.Values)
		{
			totalPayroll += FindPayRate(researcher.GetComponent<Staff>());
		}

		foreach(GameObject security in sm.securityStaff.Values)
		{
			totalPayroll += FindPayRate(security.GetComponent<Staff>());
		}

		// Call LoseMoney() for total salary amount
		LoseMoney(totalPayroll);
	}

	/// <summary>
	/// A helper method that finds the rate that the staff member needs to be paid
	/// </summary>
	/// <param name="staffMember">The staff member getting paid</param>
	/// <returns></returns>
	public int FindPayRate(Staff staffMember)
	{
		if(staffMember.type == StaffType.research)
		{
			return staffMember.tier * sm.researchPayRate;
		}
		else if(staffMember.type == StaffType.security)
		{
			return staffMember.tier * sm.securityPayRate;
		}

		return 0;
	}

	/// <summary>
	/// Checks if the user can buy a staff member and, if so, 
	/// buys the staff member to a specific room
	/// </summary>
	/// <param name="roomToMoveTo">The room the staff member will go to</param>
	/// <param name="staffType">The type of staff they are</param>
	public void BuyStaff(GameObject roomToMoveTo, StaffType staffType)
	{
		if(staffType == StaffType.research)
		{
			if(gm.Money >= sm.researchCost)
			{
				LoseMoney(sm.researchCost);
				sm.AddStaff(roomToMoveTo, StaffType.research);
			}
		}
		else if(staffType == StaffType.security)
		{
			if(gm.Money >= sm.securityCost)
			{
				LoseMoney(sm.securityCost);
				sm.AddStaff(roomToMoveTo, StaffType.security);
			}
		}
	}
	#endregion
}
