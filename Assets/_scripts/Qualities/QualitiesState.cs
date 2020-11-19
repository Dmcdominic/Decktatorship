using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// To keep track of the state of all qualities in a given region.
[CreateAssetMenu(menuName = "custom/QualitiesState")]
public class QualitiesState : ScriptableObject {
	public QualityStates states;
}


// The states of all qualities.
[System.Serializable]
public struct QualityStates {
	public int[] states; // Indexed by the Quality enum
	// length MUST be: System.Enum.GetValues(typeof(Quality)).Length
}