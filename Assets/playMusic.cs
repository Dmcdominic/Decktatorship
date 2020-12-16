using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    private NetObject thisNetObj;

    // late init
    private void Start()
    {
        thisNetObj = GetComponentInParent<NetObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisNetObj.netVariables.qualityStates.states.Min() <= QualityStates.SOFT_MAX * 0.3f)
        {

        }
    }
}
