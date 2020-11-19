using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Info for a deck of cards
[CreateAssetMenu(menuName = "custom/Decklist")]
public class Decklist : ScriptableObject {
	// Fields
	public string Title;
	public List<CardInfo> cardInfos;
}
