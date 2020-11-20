using System;

//This class is the data structure for networked variables contained in each NetObject
//all the variables that need to stay in sync should be defined here and changed with:
//Net.SetVariables(string objectId, NetVariables netVarsObject);

[Serializable]
public class NetVariables
{
    public string uniqueId;
	public QualityStates qualityStates;

	public NetVariables(string _uniqueId) {
		uniqueId = _uniqueId;
		qualityStates.states = new int[System.Enum.GetValues(typeof(Quality)).Length];
	}
}
