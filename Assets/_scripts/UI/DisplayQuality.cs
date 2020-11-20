using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayQuality : MonoBehaviour {
	// Public fields
	//public string regionName;
	public regionView regionV;
	public Quality quality;


	// Private vars
	private TextMeshProUGUI TMP;


	// Init
	private void Awake() {
		TMP = GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update() {
		NetObject regionNO = regionV.currentRegion;
		if (regionNO == null || regionNO.netVariables == null) return;

		string qName = System.Enum.GetName(typeof(Quality), quality);
		int value = regionNO.netVariables.qualityStates.states[(int)quality];

		TMP.text = qName + " = " + value;
	}
}
