using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {
    public GameObject[] Team1;
    public GameObject[] Team2;

    public void OnAwake()
    {
        foreach(var teamMember in Team1)
        {
            teamMember.GetComponent<LittleGuy>().CurrentTeam = Teams.TeamOne;
        }

        foreach (var teamMember in Team2)
        {
            teamMember.GetComponent<LittleGuy>().CurrentTeam = Teams.TeamTwo;
        }
    }    

}
