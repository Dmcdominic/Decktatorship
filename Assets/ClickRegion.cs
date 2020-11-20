using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRegion : MonoBehaviour {

	public regionView regionV;

	private NetObject thisNetObj;
	private MoveCameraToArea cameraMan; 
	public Transform cameraPos;
	private bool goToRegion = true;
	// Start is called before the first frame update
	void Start() {
		thisNetObj = GetComponentInParent<NetObject>();
		cameraMan = Camera.main.GetComponent<MoveCameraToArea>();
	}

	private void OnMouseDown() {
		Debug.Log("Region " + gameObject.name + " clicked");
		if (goToRegion)
        {
			cameraMan.currentView = cameraPos;
			goToRegion = false;
		}
        else
        {
			cameraMan.currentView = cameraMan.defaultView;
			goToRegion = true;
		}
		regionV.currentRegion = thisNetObj;

		//NetVariables netVariables = thisNetObj.netVariables;
		//if (netVariables == null) {
		//	Debug.LogError("netVariables is null on a region...");
		//}
		//netVariables.qualityStates.states[(int)Quality.HAPPINESS] += 2;
		//Debug.Log(thisNetObj);
		////thisNetObj.
		//Net.SetVariables(netVariables.uniqueId, netVariables);
	}

	// Update is called once per frame
	void Update() {

	}
}
