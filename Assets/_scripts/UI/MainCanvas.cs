using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour {
	public static Canvas canvas;

	// Start is called before the first frame update
	void Awake() {
		canvas = GetComponent<Canvas>();
	}
}
