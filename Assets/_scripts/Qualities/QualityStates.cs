using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// enums
public enum Quality { HEALTH, HAPPINESS, MONEY, MILITARY }
public enum Amount { LOW, MEDIUM, HIGH }
public enum Locality { LOCAL, ADJACENT, GLOBAL }


// The states of all qualities.
[System.Serializable]
public struct QualityStates {
	public int[] states; // Indexed by the Quality enum
	// length MUST be: QualityStates.NUM_QUALITIES
	public static int NUM_QUALITIES = System.Enum.GetValues(typeof(Quality)).Length;
	public const int SOFT_MAX = 50;
	public const int INIT_VALUE = 40;
	public const int MIN = 0;
}


// Info for how something will impact a particular quality
[System.Serializable]
public struct Impact {
	public bool decrease;
	public Amount amount;
	public Quality quality;
	public Locality locality;

	public int getScaledAmount() {
		int baseAmt = 5;
		int absAmt = baseAmt * (1 + (int)amount);
		int finalAmt = decrease ? -absAmt : absAmt;
		return finalAmt;
	}
}
