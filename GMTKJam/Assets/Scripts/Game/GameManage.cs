using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour {
    public float captureVictory;
    float pointsT1;
    float pointsT2;
    bool gameOver;

    //Dictionary<string, bool> rosterT1;
    //Dictionary<string, bool> rosterT2;

    //ui
    public GameObject endScreen;
    public Text endText;
    public Image pointsUIT1;
    public Image pointsUIT2;

    public int rosterSize;
    int team1Alive;
    int team2Alive;

    public Image[] team1Guys = new Image[3];
    public Image[] team2Guys = new Image[3];


    void OnEnable()
    {
        EventManager.StartListening("IncrementPoints", IncrementPoints);
        EventManager.StartListening("FaintLittleGuy", FaintLittleGuy);
    }

    void OnDisable()
    {
        EventManager.StopListening("IncrementPoints", IncrementPoints);
        EventManager.StopListening("FaintLittleGuy", FaintLittleGuy);
    }

    // Use this for initialization
    void Start () {
        team1Alive = 3;
        team2Alive = 3;
	}
	
	// Update is called once per frame
	void Update () {
        //pointsT1 += Time.deltaTime;
        //pointsT2 += Time.deltaTime / 2f;
        
        for(int i = 0; i < team1Guys.Length; i++)
        {
            if((i + 1) > team1Alive)
            {
                team1Guys[i].color = Color.gray;
            }
        }

        for (int i = 0; i < team2Guys.Length; i++)
        {
            if ((i + 1) > team2Alive)
            {
                team2Guys[i].color = Color.gray;
            }
        }


        if (!gameOver)
        {
            pointsUIT1.fillAmount = (pointsT1 / captureVictory);
            pointsUIT2.fillAmount = (pointsT2 / captureVictory);

            if (pointsT1 >= captureVictory)
            {
                gameOver = true;
                endScreen.SetActive(true);
                endText.text = "Captured! Team 1 Wins!\nPS: Team 2 sucks";
            }
            else if (pointsT2 >= captureVictory)
            {
                gameOver = true;
                endScreen.SetActive(true);
                endText.text = "Captured! Team 2 Wins!\nPS: Team 1 sucks";
            }
            else if(team2Alive < 1)
            {
                gameOver = true;
                endScreen.SetActive(true);
                endText.text = "Knockout! Team 1 Wins!\nPS: Team 2 sucks";
            }
            else if(team1Alive < 1)
            {
                gameOver = true;
                endScreen.SetActive(true);
                endText.text = "Knockout! Team 2 Wins!\nPS: Team 1 sucks";
            }
        }
	}

    void IncrementPoints(EventBody eb)
    {
        int team = ((PointsEB)eb).team;
        float points = ((PointsEB)eb).points;
        if(team == 1)
        {
            pointsT1 += points;
        } else if(team == 2)
        {
            pointsT2 += points;
        }
    }

    void FaintLittleGuy(EventBody eb)
    {
        int team = ((TeamFaintEB)eb).team;
        if(team == 1)
        {
            team1Alive -= 1;
        } else if(team == 2)
        {
            team2Alive -= 1;
        }
    }
    
    /*void AddToRoster(EventBody eb)
    {
        string name = ((LittleNameEB)eb).name;
        int team = ((LittleNameEB)eb).team;

        if (team == 1)
        {
            if (!rosterT1.ContainsKey(name))
            {
                rosterT1.Add(name, true);
            }
        }
    }

    void FaintLittleGuy(EventBody eb)
    {
        string name = ((LittleNameEB)eb).name;
        int team = ((LittleNameEB)eb).team;

        if (team == 1)
        {
            if (rosterT1.ContainsKey(name))
            {
                rosterT1[name] = false;
            }
        }
    }

    void InitializeRoster()
    {
        foreach(string name in rosterT1.Keys)
        {
            
        }
    }*/
}
