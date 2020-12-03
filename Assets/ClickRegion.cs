using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickRegion : MonoBehaviour {

	public regionView regionV;

	private NetObject thisNetObj;
	private MoveCameraToArea cameraMan; 
	public Transform cameraPos;
	private bool goToRegion = true;

	public static Dictionary<string, NetObject> regionNetObs = new Dictionary<string, NetObject>(); // Key = uniqueID


	// Start is called before the first frame update
	void Start() {
		thisNetObj = GetComponentInParent<NetObject>();
		regionNetObs.Add(thisNetObj.netVariables.uniqueId, thisNetObj);
		cameraMan = Camera.main.GetComponent<MoveCameraToArea>();
	}

	private void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		//Debug.Log("Region " + gameObject.name + " clicked");
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
	}
}
