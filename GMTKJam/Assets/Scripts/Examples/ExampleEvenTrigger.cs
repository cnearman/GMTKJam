using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEvenTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            EventManager.TriggerEvent("DebugA");
        }
        if (Input.GetButtonDown("Jump"))
        {
            EventManager.TriggerEvent("DebugB");
        }
    }
}
