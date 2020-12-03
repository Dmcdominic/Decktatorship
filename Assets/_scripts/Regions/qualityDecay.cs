using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class qualityDecay : MonoBehaviour {

	private const int MIN = -3; // inclusive
	private const int MAX = 3; // exclusive

	private const float INTERVAL_MIN = 2.5f;
	private const float INTERVAL_MAX = 6.0f;

	private NetObject thisNetObj;
	private float timer;

	public static Dictionary<string, NetObject> regionNetObs = new Dictionary<string, NetObject>(); // Key = uniqueID


	// init
	private void Start() {
		thisNetObj = GetComponentInParent<NetObject>();
		regionNetObs.Add(thisNetObj.netVariables.uniqueId, thisNetObj);
		timer = Random.Range(INTERVAL_MIN, INTERVAL_MAX);
	}


	// Update is called once per frame
	void Update() {
		if (!thisNetObj.ownedByThisClient()) return;
		if (timer > 0) {
			timer -= Time.deltaTime;
			return;
		}

		int quality = Random.Range(0, QualityStates.NUM_QUALITIES);
		int delta = Random.Range(MIN, MAX);
		NetVariables incrVars = NetVariables.makeIncrCopy(thisNetObj.netVariables);

		thisNetObj.netVariables.qualityStates.states[quality] += delta;
		incrVars.qualityStates.states[quality] += delta;
		Net.IncrVariables(incrVars.uniqueId, incrVars);

		timer = Random.Range(INTERVAL_MIN, INTERVAL_MAX);
	}
}
