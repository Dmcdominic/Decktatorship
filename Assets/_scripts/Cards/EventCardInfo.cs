using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Info for a specific event
[System.Serializable]
[CreateAssetMenu(menuName = "custom/EventCardInfo")]
public class EventCardInfo : CardInfo {
	// Fields
	public EventOption eventOption1;
	public EventOption eventOption2;
}


// Info for an option to choose during an event
[System.Serializable]
public struct EventOption {
	public string title;
	public string description;

	public PlayableCardInfo cardGained;

	public List<Impact> impacts;
}
