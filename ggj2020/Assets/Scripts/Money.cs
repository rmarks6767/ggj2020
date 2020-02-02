using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
	#region Fields
	// The GameManager Object
	#endregion

	// Start is called before the first frame update
	void Start()
    {
        
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
		// Find # of researchers
		// Multiply # of researchers by "salary" (cost per time)

		// Find # of security
		// Multiply # of security by "salary" (cost per time)

		// Call LoseMoney() for total salary amount
	}
	#endregion
}
