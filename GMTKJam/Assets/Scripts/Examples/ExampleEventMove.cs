using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExampleEventMove : MonoBehaviour {

    void OnEnable()
    {
        EventManager.StartListening("A_1Pressed", DebugA);
        EventManager.StartListening("A_1Released", DebugB);
    }

    void OnDisable()
    {
        EventManager.StopListening("A_1Pressed", DebugA);
        EventManager.StopListening("A_1Released", DebugB);
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
