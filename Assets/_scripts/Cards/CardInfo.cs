using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// enums
public enum Quality { LIBERTY, HAPPINESS, MONEY, MILITARY }
public enum Amount { LOW, MEDIUM, HIGH }
public enum Locality { LOCAL, ADJACENT, GLOBAL }


// Info for a specific card
[CreateAssetMenu(menuName = "custom/CardInfo")]
public class CardInfo : ScriptableObject {
	// Fields
	public string title;
	public string description;

	public Sprite sprite;

	public List<Impact> impacts;
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
		return decrease ? -absAmt : absAmt;
	}
}
