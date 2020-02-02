using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Money : MonoBehaviour
{
	#region Fields

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
  //      if(Time.time - startTime <= payrollRate)
		//{
		//	Payroll();
		//}
    }

	#region Methods
	/// <summary>
	/// A simple way to increase money of the GameManager
	/// </summary>
	/// <param name="moneyGained">The amount gained</param>
	public void GainMoney(int moneyGained)
	{
		// Adds moneyGained to money field of GameManager
		GameManager.Instance.AddMoney(moneyGained);
	}

	/// <summary>
	/// A simple way to deduct money from the GameManager
	/// </summary>
	/// <param name="moneyLost">The amount lost</param>
	public void LoseMoney(int moneyLost)
	{
		// Removes moneyLost to money field of GameManager
		GameManager.Instance.AddMoney(-moneyLost);
	}

	/// <summary>
	/// Charges the player an amount after so much time, 
	/// based on the type of staff member and its tier
	/// </summary>
	public void Payroll()
	{
		int totalPayroll = 0;

		// Loops the both Dictionaries and 
		foreach(GameObject researchStaff in GameManager.Instance.staffManager.researchStaff.Values)
		{
			totalPayroll += FindPayRate(researchStaff.GetComponent<Staff>());
		}

		foreach(KeyValuePair<int, GameObject> securityStaffPair in GameManager.Instance.staffManager.securityStaff)
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
			return staffMember.tier * GameManager.Instance.staffManager.researchPayRate;
		}
		else if(staffMember.type == StaffType.security)
		{
			return staffMember.tier * GameManager.Instance.staffManager.securityPayRate;
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
		Debug.Log(GameManager.Instance.Money);
		if(staffType == StaffType.research)
		{
			if(GameManager.Instance.Money >= GameManager.Instance.staffManager.researchCost)
			{
				LoseMoney(GameManager.Instance.staffManager.researchCost);
				GameManager.Instance.staffManager.AddStaff(roomToMoveTo, StaffType.research);
				Debug.Log("Hire Research!");
			}
		}
		else if(staffType == StaffType.security)
		{
			if(GameManager.Instance.Money >= GameManager.Instance.staffManager.securityCost)
			{
				LoseMoney(GameManager.Instance.staffManager.securityCost);
				GameManager.Instance.staffManager.AddStaff(roomToMoveTo, StaffType.security);
				Debug.Log("Hire Security!");
			}
		}
	}
	#endregion
}
