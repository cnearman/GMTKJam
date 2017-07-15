using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEvenTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float rawSpeed = Input.GetAxisRaw("L_XAxis_1");
        EventManager.TriggerEvent("DebugA", new MovementBody
        {
            speed = rawSpeed
        });
        
    }
}
