using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToArea : MonoBehaviour
{
    public float transitionSpeed;
    [HideInInspector] public Transform currentView;
    public Transform defaultView;


    // Start is called before the first frame update
    void Start()
    {
        currentView = defaultView;
    }

   void LateUpdate()
    {
        //Lerp Position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
    }
}
