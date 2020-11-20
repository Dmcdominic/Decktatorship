using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToArea : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    [HideInInspector] public Transform currentView;
    public Transform defaultView;


    // Start is called before the first frame update
    void Start()
    {
        currentView = views[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentView = defaultView;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentView = views[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentView = views[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentView = views[3];
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentView = views[4];
        }
    }
    void LateUpdate()
    {
        //Lerp Position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
    }
}
