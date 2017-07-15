using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExampleEventMove : MonoBehaviour {

    void OnEnable()
    {
        EventManager.StartListening("DebugA", DebugA);
    }

    void OnDisable()
    {
        EventManager.StopListening("DebugA", DebugA);
    }


    void DebugA(EventBody eb)
    {
        float speed = ((MovementBody)eb).speed;
        Debug.Log("you have debugged A " + speed);
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
