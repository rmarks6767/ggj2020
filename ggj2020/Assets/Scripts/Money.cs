using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Money : MonoBehaviour
{
	#region Fields
	GameManager gm;
	StaffManager sm;
	#endregion

	// Start is called before the first frame update
	void Start()
    {
        // Initialize GameManager
		// Initialize StaffManager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	#region Methods
	public void GainMoney(int moneyGained)
	{
		// Adds moneyGained to money field of GameManager
	}
	public void LoseMoney(int moneyLost)
	{
		// Removes moneyLost to money field of GameManager
	}
	public void Payroll()
	{
		// Find # of researchers from staff manager
		// Multiply # of researchers by "salary" (cost per time)

		// Find # of security from staff manager
		// Multiply # of security by "salary" (cost per time)

		// Call LoseMoney() for total salary amount
	}
	#endregion
}
