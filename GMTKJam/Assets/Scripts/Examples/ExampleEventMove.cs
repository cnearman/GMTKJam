using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExampleEventMove : MonoBehaviour {

    void OnEnable()
    {
        EventManager.StartListening("DebugA", DebugA);
        EventManager.StartListening("DebugB", DebugB);
    }

    void OnDisable()
    {
        EventManager.StopListening("DebugA", DebugA);
        EventManager.StopListening("DebugB", DebugB);
    }


    void DebugA()
    {
        Debug.Log("you have debugged A");
    }

    void DebugB()
    {
        Debug.Log("you have debugged B");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
