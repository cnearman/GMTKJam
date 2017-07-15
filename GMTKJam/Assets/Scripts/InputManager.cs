using UnityEngine;

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
            EventManager.TriggerEvent("A_" + playerNumber + "Pressed");
        }
        if (Input.GetButtonUp("A_" + playerNumber))
        {
            Debug.Log("A_" + playerNumber + "Released");
            EventManager.TriggerEvent("A_" + playerNumber + "Released");
        }

        if (Input.GetButtonDown("B_" + playerNumber))
        {
            Debug.Log("B_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("B_" + playerNumber + "Pressed");
        }
        if (Input.GetButtonUp("B_" + playerNumber))
        {
            Debug.Log("B_" + playerNumber + "Released");
            EventManager.TriggerEvent("B_" + playerNumber + "Released");
        }

        if (Input.GetButtonDown("X_" + playerNumber))
        {
            Debug.Log("X_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("X_" + playerNumber + "Pressed");
        }
        if (Input.GetButtonUp("X_" + playerNumber))
        {
            Debug.Log("X_" + playerNumber + "Released");
            EventManager.TriggerEvent("X_" + playerNumber + "Released");
        }

        if (Input.GetButtonDown("Y_" + playerNumber))
        {
            Debug.Log("Y_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("Y_" + playerNumber + "Pressed");
        }
        if (Input.GetButtonUp("Y_" + playerNumber))
        {
            Debug.Log("Y_" + playerNumber + "Released");
            EventManager.TriggerEvent("Y_" + playerNumber + "Released");
        }

        if (Input.GetButtonDown("RB_" + playerNumber))
        {
            Debug.Log("RB_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("RB_" + playerNumber + "Pressed");
        }
        if (Input.GetButtonUp("RB_" + playerNumber))
        {
            Debug.Log("RB_" + playerNumber + "Released");
            EventManager.TriggerEvent("RB_" + playerNumber + "Released");
        }

        if (Input.GetButtonDown("LB_" + playerNumber))
        {
            Debug.Log("LB_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("LB_" + playerNumber + "Pressed");
        }
        if (Input.GetButtonUp("LB_" + playerNumber))
        {
            Debug.Log("LB_" + playerNumber + "Released");
            EventManager.TriggerEvent("LB_" + playerNumber + "Released");
        }
        if (Input.GetButtonDown("Back_" + playerNumber))
        {
            Debug.Log("Back_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("Back_" + playerNumber + "Pressed");
        }
        if (Input.GetButtonUp("Back_" + playerNumber))
        {
            Debug.Log("Back_" + playerNumber + "Released");
            EventManager.TriggerEvent("Back_" + playerNumber + "Released");
        }
        if (Input.GetButtonDown("Start_" + playerNumber))
        {
            Debug.Log("Start_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("Start_" + playerNumber + "Pressed");
        }
        if (Input.GetButtonUp("Start_" + playerNumber))
        {
            Debug.Log("Start_" + playerNumber + "Released");
            EventManager.TriggerEvent("Start_" + playerNumber + "Released");
        }
        if (Input.GetButtonDown("LS_" + playerNumber))
        {
            Debug.Log("LS_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("LS_" + playerNumber + "Pressed");
        }
        if (Input.GetButtonUp("LS_" + playerNumber))
        {
            Debug.Log("LS_" + playerNumber + "Released");
            EventManager.TriggerEvent("LS_" + playerNumber + "Released");
        }
        if (Input.GetButtonDown("RS_" + playerNumber))
        {
            Debug.Log("RS_" + playerNumber + "Pressed");
            EventManager.TriggerEvent("RS_" + playerNumber + "Pressed");
        }
        if (Input.GetButtonUp("RS_" + playerNumber))
        {
            Debug.Log("RS_" + playerNumber + "Released");
            EventManager.TriggerEvent("RS_" + playerNumber + "Released");
        }



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
    //R_YAxis_{playerNumber}
    //L_YAxis_{playerNumber}
    //DPad_XAxis_{playerNumber}
    //DPad_YAxis_{playerNumber}
    //TriggersR_{playerNumber}
    //TriggersL_{playerNumber}
}
