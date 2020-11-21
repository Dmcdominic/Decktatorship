using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Info for a specific playable card
[CreateAssetMenu(menuName = "custom/PlayableCardInfo")]
public class PlayableCardInfo : CardInfo {
	// Fields
	public List<Impact> impacts;
}
