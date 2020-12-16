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
        transform.position = Vector3.Lerp(transform.position, currentView.localPosition, Time.deltaTime * transitionSpeed);
    //    transform.Rotate(90.0f, 0.0f, 0.0f);
    }


}
