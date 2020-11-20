using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayQuality : MonoBehaviour {
	// Public fields
	public string regionName;
	public Quality quality;


	// Private vars
	private Text text;
	private NetObject regionNO;


	// Init
	private void Awake() {
		text = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update() {
		if (regionNO == null) {
			GameObject regionGO = GameObject.Find(regionName);
			if (regionGO) {
				regionNO = regionGO.GetComponentInParent<NetObject>();
			}
		}
		
		if (regionNO == null || regionNO.netVariables == null) return;

		string qName = System.Enum.GetName(typeof(Quality), quality);
		int value = regionNO.netVariables.qualityStates.states[(int)quality];

		text.text = qName + " = " + value;
	}
}
