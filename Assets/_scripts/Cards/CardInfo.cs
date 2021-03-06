﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Info for a specific card (extended by PlayableCardInfo and EventCardInfo)
[System.Serializable]
public abstract class CardInfo : ScriptableObject {
	// Fields
	public string title;
	public string description;
	public enum Effects { Effect1, Effect2, Effect3,Effect4 };
	public Sprite background;

}
