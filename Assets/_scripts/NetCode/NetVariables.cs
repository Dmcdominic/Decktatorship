using System;

//This class is the data structure for networked variables contained in each NetObject
//all the variables that need to stay in sync should be defined here and changed with:
//Net.SetVariables(string objectId, NetVariables netVarsObject);
//Net.IncrVariables(string objectId, NetVariables netVarsObject);

[Serializable]
public class NetVariables {
	// General variables
	public string uniqueId;
	public bool maintainTransform;

	// Region variables
	public string regionName;
	public QualityStates qualityStates;

	// event variables
	public EventCardInfo eventInfo;

	// Card to shuffle title
	public string cardToShuffleTitle;


	// Constructor
	public NetVariables(string _uniqueId, string _regionName, EventCardInfo _eventInfo = null, bool incrCopy = false, bool _maintainTransform = true) {
		uniqueId = _uniqueId;
		regionName = _regionName.Replace("Wrapper", "").ToUpper();
		qualityStates.states = new int[System.Enum.GetValues(typeof(Quality)).Length];
		for (int i=0; i < qualityStates.states.Length; i++) {
			qualityStates.states[i] = incrCopy ? 0 : 50; // Initial value
		}
		eventInfo = _eventInfo;
		maintainTransform = _maintainTransform;
	}

	// Returns a new NetVariables object that has the same uniqueId and regionName as the source.
	public static NetVariables makeIncrCopy(NetVariables src) {
		NetVariables newNetVars = new NetVariables(src.uniqueId, src.regionName, null, true);
		return newNetVars;
	}
}
