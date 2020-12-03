using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// enums
public enum Quality { LIBERTY, HAPPINESS, MONEY, MILITARY }
public enum Amount { LOW, MEDIUM, HIGH }
public enum Locality { LOCAL, ADJACENT, GLOBAL }


// The states of all qualities.
[System.Serializable]
public struct QualityStates {
	public int[] states; // Indexed by the Quality enum
	// length MUST be: System.Enum.GetValues(typeof(Quality)).Length
}


// Info for how something will impact a particular quality
[System.Serializable]
public struct Impact {
	public bool decrease;
	public Amount amount;
	public Quality quality;
	public Locality locality;

	public int getScaledAmount() {
		int baseAmt = 1;
		int absAmt = baseAmt * (1 + (int)amount);
		int finalAmt = decrease ? -absAmt : absAmt;
		return finalAmt;
	}
}
