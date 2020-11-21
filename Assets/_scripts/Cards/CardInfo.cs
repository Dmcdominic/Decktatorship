using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Info for a specific card (extended by PlayableCardInfo and EventCardInfo)
public abstract class CardInfo : ScriptableObject {
	// Fields
	public string title;
	public string description;
}
