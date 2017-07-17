using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBlast : MonoBehaviour {

    public int PlayerNumber;
    public float range;

    public GameObject petal;

    void OnEnable()
    {
        PlayerNumber = gameObject.GetComponent<LittleGuy>().PlayerNumber;
        EventManager.StartListening("Ability2_" + PlayerNumber + "Pressed", ActivateAB);
    }

    void OnDisable()
    {
        EventManager.StopListening("Ability2_" + PlayerNumber + "Pressed", ActivateAB);
    }

    void ActivateAB(EventBody eb)
    {
        if (gameObject.GetComponent<LittleGuy>().ability2CooldownCurrent <= 0f)
        {
            EventManager.TriggerEvent("Ability2_" + PlayerNumber + "_Triggered", null);
            

            GameObject petalys = (GameObject)Instantiate(petal, gameObject.transform.position, Quaternion.identity);
            //Debug.Log(Mathf.Atan2(aim.y, aim.x));
            petalys.GetComponent<HomingRocket>().currentTeam = gameObject.GetComponent<LittleGuy>().CurrentTeam;
            Destroy(petalys, range);
        }
    }

    
}
