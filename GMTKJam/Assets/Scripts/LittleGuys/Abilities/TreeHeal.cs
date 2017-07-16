using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHeal : MonoBehaviour {

    public int PlayerNumber;
    public GameObject seed;
    public float durration;

    void OnEnable()
    {
        PlayerNumber = gameObject.GetComponent<LittleGuy>().PlayerNumber;
        EventManager.StartListening("Ability1_" + PlayerNumber + "Pressed", ActivateAB);
    }

    void OnDisable()
    {
        EventManager.StopListening("Ability1_" + PlayerNumber + "Pressed", ActivateAB);
    }

    void ActivateAB(EventBody eb)
    {
        if (gameObject.GetComponent<LittleGuy>().ability1CooldownCurrent <= 0f)
        {
            float vpoints = 0f;
            if (PlayerNumber == 1)
            {
                vpoints = GameObject.Find("Game Manage").GetComponent<GameManage>().pointsT1;
            } else
            {
                vpoints = GameObject.Find("Game Manage").GetComponent<GameManage>().pointsT2;
            }

            if(vpoints > 3)
            {
                if (PlayerNumber == 1)
                {
                    EventManager.TriggerEvent("IncrementPoints", new PointsEB { team = Teams.TeamOne, points = -3f });
                }
                else
                {
                    EventManager.TriggerEvent("IncrementPoints", new PointsEB { team = Teams.TeamTwo, points = -3f });
                }

                EventManager.TriggerEvent("Ability1_" + PlayerNumber + "_Triggered", null);
                GameObject tempAV = (GameObject)Instantiate(seed, gameObject.transform.position, Quaternion.identity);
                if (PlayerNumber == 1)
                {
                    tempAV.GetComponentInChildren<HealSeed>().currentTeam = Teams.TeamOne;
                }
                else
                {
                    tempAV.GetComponentInChildren<HealSeed>().currentTeam = Teams.TeamTwo;
                }
                Destroy(tempAV, durration);
            }

            
        }
    }
}
