﻿using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField]
    [Range(1,4)]
    private int playerNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Axis Events
        //Button Events
		if(Input.GetButtonDown("A_" + playerNumber))
        {
            Debug.Log("A_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("A_" + playerNumber + "Pressed", null);
        }
        if (Input.GetButtonUp("A_" + playerNumber))
        {
            Debug.Log("A_" + playerNumber + "Released");
            EventManager.TriggerEvent("A_" + playerNumber + "Released", null);
        }

        if (Input.GetButtonDown("B_" + playerNumber))
        {
            Debug.Log("B_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("B_" + playerNumber + "Pressed", null);
        }
        if (Input.GetButtonUp("B_" + playerNumber))
        {
            Debug.Log("B_" + playerNumber + "Released");
            EventManager.TriggerEvent("B_" + playerNumber + "Released", null);
        }

        if (Input.GetButtonDown("X_" + playerNumber))
        {
            Debug.Log("X_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("X_" + playerNumber + "Pressed", null);
        }
        if (Input.GetButtonUp("X_" + playerNumber))
        {
            Debug.Log("X_" + playerNumber + "Released");
            EventManager.TriggerEvent("X_" + playerNumber + "Released", null);
        }

        if (Input.GetButtonDown("Y_" + playerNumber))
        {
            Debug.Log("Y_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("Y_" + playerNumber + "Pressed", null);
        }
        if (Input.GetButtonUp("Y_" + playerNumber))
        {
            Debug.Log("Y_" + playerNumber + "Released");
            EventManager.TriggerEvent("Y_" + playerNumber + "Released", null);
        }

        if (Input.GetButtonDown("RB_" + playerNumber))
        {
            Debug.Log("RB_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("RB_" + playerNumber + "Pressed", null);
        }
        if (Input.GetButtonUp("RB_" + playerNumber))
        {
            Debug.Log("RB_" + playerNumber + "Released");
            EventManager.TriggerEvent("RB_" + playerNumber + "Released", null);
        }

        if (Input.GetButtonDown("LB_" + playerNumber))
        {
            Debug.Log("LB_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("LB_" + playerNumber + "Pressed", null);
        }
        if (Input.GetButtonUp("LB_" + playerNumber))
        {
            Debug.Log("LB_" + playerNumber + "Released");
            EventManager.TriggerEvent("LB_" + playerNumber + "Released", null);
        }
        if (Input.GetButtonDown("Back_" + playerNumber))
        {
            Debug.Log("Back_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("Back_" + playerNumber + "Pressed", null);
        }
        if (Input.GetButtonUp("Back_" + playerNumber))
        {
            Debug.Log("Back_" + playerNumber + "Released");
            EventManager.TriggerEvent("Back_" + playerNumber + "Released", null);
        }
        if (Input.GetButtonDown("Start_" + playerNumber))
        {
            Debug.Log("Start_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("Start_" + playerNumber + "Pressed", null);
        }
        if (Input.GetButtonUp("Start_" + playerNumber))
        {
            Debug.Log("Start_" + playerNumber + "Released");
            EventManager.TriggerEvent("Start_" + playerNumber + "Released", null);
        }
        if (Input.GetButtonDown("LS_" + playerNumber))
        {
            Debug.Log("LS_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("LS_" + playerNumber + "Pressed", null);
        }
        if (Input.GetButtonUp("LS_" + playerNumber))
        {
            Debug.Log("LS_" + playerNumber + "Released");
            EventManager.TriggerEvent("LS_" + playerNumber + "Released", null);
        }
        if (Input.GetButtonDown("RS_" + playerNumber))
        {
            Debug.Log("RS_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("RS_" + playerNumber + "Pressed", null);
        }
        if (Input.GetButtonUp("RS_" + playerNumber))
        {
            Debug.Log("RS_" + playerNumber + "Released");
            EventManager.TriggerEvent("RS_" + playerNumber + "Released", null);
        }

        //L stick
        float rawLXAxis = Input.GetAxisRaw("L_XAxis_" + playerNumber);
        float rawLYAxis = Input.GetAxisRaw("L_YAxis_" + playerNumber);

        EventManager.TriggerEvent("L_XAxis_" + playerNumber, new AxisEB { value = rawLXAxis });
        EventManager.TriggerEvent("L_YAxis_" + playerNumber, new AxisEB { value = rawLYAxis });

        //R Stick
        float rawRXAxis = Input.GetAxisRaw("R_XAxis_" + playerNumber);
        float rawRYAxis = Input.GetAxisRaw("R_YAxis_" + playerNumber);

        EventManager.TriggerEvent("R_XAxis_" + playerNumber, new AxisEB { value = rawRXAxis });
        EventManager.TriggerEvent("R_YAxis_" + playerNumber, new AxisEB { value = rawRYAxis });

        //D pad
        float rawDXAxis = Input.GetAxisRaw("DPad_XAxis_" + playerNumber);
        float rawDYAxis = Input.GetAxisRaw("DPad_YAxis_" + playerNumber);

        EventManager.TriggerEvent("DPad_XAxis_" + playerNumber, new AxisEB { value = rawDXAxis });
        EventManager.TriggerEvent("DPad_YAxis_" + playerNumber, new AxisEB { value = rawDYAxis });

        //Triggers
        float rawTRAxis = Input.GetAxisRaw("TriggersR_" + playerNumber);
        float rawTLAxis = Input.GetAxisRaw("TriggersL_" + playerNumber);

        EventManager.TriggerEvent("TriggersR_" + playerNumber, new AxisEB { value = rawTRAxis });
        EventManager.TriggerEvent("TriggersL_" + playerNumber, new AxisEB { value = rawTLAxis });

    }
    //L_XAxis_{playerNumber}
    //L_YAxis_{playerNumber}
    //A_{playerNumber} (Bottom Button)  √
    //B_{playerNumber} (Right Button)   √
    //X_{playerNumber} (Left Button     √
    //Y_{playerNumber} (Top Button      √
    //LB_{playerNumber}                 √
    //RB_{playerNumber}                 √
    //Back_{playerNumber}               √
    //Start_{playerNumber}              √
    //LS_{playerNumber}                 √
    //RS_{playerNumber}                 √
    //R_YAxis_{playerNumber}            √
    //L_YAxis_{playerNumber}            √
    //DPad_XAxis_{playerNumber}         √
    //DPad_YAxis_{playerNumber}         √
    //TriggersR_{playerNumber}          √
    //TriggersL_{playerNumber}          √
}
