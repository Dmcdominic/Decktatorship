using System;

//This class is the data structure for networked variables contained in each NetObject
//all the variables that need to stay in sync should be defined here and changed with:
//Net.SetVariables(string objectId, NetVariables netVarsObject);
//Net.IncrVariables(string objectId, NetVariables netVarsObject);

[Serializable]
public class NetVariables
{
    public string uniqueId;
	public string regionName;
	public QualityStates qualityStates;

	public NetVariables(string _uniqueId, string _regionName) {
		uniqueId = _uniqueId;
		regionName = _regionName.Replace("Wrapper", "").ToUpper();
		// TODO - Set the initial qualityStates values here
		qualityStates.states = new int[System.Enum.GetValues(typeof(Quality)).Length];
	}

	// Returns a new NetVariables object that has the same uniqueId and regionName as the source.
	public static NetVariables makeIncrCopy(NetVariables src) {
		return new NetVariables(src.uniqueId, src.regionName);
	}
}
