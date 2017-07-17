using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : MonoBehaviour {

    [SerializeField]
    [Range(1, 4)]
    private int playerNumber;

    float rawLXAxis = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("A_" + playerNumber))
        {
            EventManager.TriggerEvent("Select_" + playerNumber, null);
        }


        if (Input.GetButtonDown("Start_" + playerNumber))
        {
            EventManager.TriggerEvent("Start_" + "Pressed", null);
        }


        if (Input.GetButtonUp("Start_" + playerNumber))
        {
            EventManager.TriggerEvent("Start_" + "Released", null);
        }

        //L stick
        if (rawLXAxis == 0f)
        {
            if(Input.GetAxisRaw("L_XAxis_" + playerNumber) > 0f)
            {
                EventManager.TriggerEvent("CursorRight_" + playerNumber, null);
            } else if(Input.GetAxisRaw("L_XAxis_" + playerNumber) < 0f)
            {
                EventManager.TriggerEvent("CursorLeft_" + playerNumber, null);
            }
        }

        rawLXAxis = Input.GetAxisRaw("L_XAxis_" + playerNumber);

        
    }
}
