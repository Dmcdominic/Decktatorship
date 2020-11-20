using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayRegionName : MonoBehaviour {
	// Public fields
	public regionView regionV;


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
		
		TMP.text = regionNO.netVariables.regionName;
	}
}
