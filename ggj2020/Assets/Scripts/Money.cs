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
        if(Time.time - startTime <= payrollRate)
		{
			Payroll();
		}
    }

	#region Methods
	public void GainMoney(int moneyGained)
	{
		// Adds moneyGained to money field of GameManager
		gm.AddMoney(moneyGained);
	}
	public void LoseMoney(int moneyLost)
	{
		// Removes moneyLost to money field of GameManager
		gm.AddMoney(-moneyLost);
	}
	public void Payroll()
	{
		int totalPayroll = 0;

		// Loops thr both Dictionaries and 
		foreach(KeyValuePair<int, GameObject> researchStaffPair in sm.researchStaff)
		{
			totalPayroll += FindPayRate(researchStaffPair.Value.GetComponent<Staff>());
		}

		foreach(KeyValuePair<int, GameObject> securityStaffPair in sm.securityStaff)
		{
			totalPayroll += FindPayRate(securityStaffPair.Value.GetComponent<Staff>());
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
			return staffMember.tier * 15;
		}
		else if(staffMember.type == StaffType.security)
		{
			return staffMember.tier * 10;
		}

		return 0;
	}

	public void BuyStaff(StaffType staffType)
	{
		if(staffType == StaffType.research)
		{
			
		}
		else if(staffType == StaffType.security)
		{

		}
	}
	#endregion
}
