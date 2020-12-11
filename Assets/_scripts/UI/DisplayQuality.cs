using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayQuality : MonoBehaviour {
	// Public fields
	//public string regionName;
	public Quality quality;

	public TextMeshProUGUI TMP;
	public Image icon;

	public regionView regionV;
	public QualityIcons qualityIcons;


	// Init
	private void Awake() {
		icon.sprite = qualityIcons.icons[(int)quality];
	}


	// Update is called once per frame
	void Update() {
		NetObject regionNO = regionV.currentRegion;
		if (regionNO == null || regionNO.netVariables == null) return;

		//string qName = System.Enum.GetName(typeof(Quality), quality);
		int value = regionNO.netVariables.qualityStates.states[(int)quality];

		//TMP.text = qName + " = " + value;
		TMP.text = value.ToString();
	}
}
