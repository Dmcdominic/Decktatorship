using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// The states of all qualities.
[System.Serializable]
public struct QualityStates {
	public int[] states; // Indexed by the Quality enum
	// length MUST be: System.Enum.GetValues(typeof(Quality)).Length
}
