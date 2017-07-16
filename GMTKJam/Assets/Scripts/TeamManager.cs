using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeamManager : MonoBehaviour {
    public List<GameObject> Team1;
    public List<GameObject> Team2;

    public GameObject[] littleGuys;

    [SerializeField]
    private Transform Team1Spawn;

    [SerializeField]
    private Transform Team2Spawn;

    private int Team1Current;
    private int Team2Current;

    private const int ROTATE_LEFT = -1;
    private const int ROTATE_RIGHT = 1;

    private const int BELLSPROUT_GUY = 0;
    private const int BLUB_GUY = 1;
    private const int HARVEY_BIRD_GUY = 2;
    private const int LIGHTING_LAMB_GUY = 3;
    private const int TURTLE_GUY = 4;

    private const float RESERVE_HEAL_CYCLE_DURATION = 4;
    private const float POINT_DECREMENT = 5;
    private float currentCycleDuration;

    public void OnEnable()
    {
        EventManager.StartListening("SwapLeft_1", SwapLeftTeam1);
        EventManager.StartListening("SwapRight_1", SwapRightTeam1);
        EventManager.StartListening("SwapLeft_2", SwapLeftTeam2);
        EventManager.StartListening("SwapRight_2", SwapRightTeam2);
        EventManager.StartListening("Death", HandleDeath);
        EventManager.StartListening("GameStart", GameStart);
    }

    public void OnDisable()
    {
        EventManager.StopListening("SwapLeft_1", SwapLeftTeam1);
        EventManager.StopListening("SwapRight_1", SwapRightTeam1);
        EventManager.StopListening("SwapLeft_2", SwapLeftTeam2);
        EventManager.StopListening("SwapRight_2", SwapRightTeam2);
        EventManager.StopListening("Death", HandleDeath);
        EventManager.StopListening("GameStart", GameStart);
    }

    public void Awake()
    {
        foreach (var teamMember in Team1)
        {
            teamMember.GetComponent<LittleGuy>().CurrentTeam = Teams.TeamOne;
        }

        foreach (var teamMember in Team2)
        {
            teamMember.GetComponent<LittleGuy>().CurrentTeam = Teams.TeamTwo;
        }
    }

    public void Start()
    {
        var teamInfo = FindObjectOfType<TeamInformation>();
        teamInfo.p1Selections.ForEach(x =>
        {
            Team1.Add(CreateCharacter(x, Teams.TeamOne));
        });
        teamInfo.p2Selections.ForEach(x =>
        {
            Team2.Add(CreateCharacter(x, Teams.TeamTwo));
        });
        EventManager.TriggerEvent("GameStart", null);
    }

    public void Update()
    {
        var timePassed = Time.deltaTime;

        if (currentCycleDuration < RESERVE_HEAL_CYCLE_DURATION)
        {
            currentCycleDuration += timePassed;
        }
        else
        {
            currentCycleDuration = 0;
        }

        foreach (var teamMember in Team1.Union(Team2))
        {
            var currentLittleGuy = teamMember.GetComponent<LittleGuy>();
            var gameManager = FindObjectOfType<GameManage>();

            //Reserve Healing
            if (currentCycleDuration < RESERVE_HEAL_CYCLE_DURATION && !teamMember.activeInHierarchy)
            {
                var health = currentLittleGuy.Statistics.GetAttribute(AttributeTypes.Health);
                var points = currentLittleGuy.CurrentTeam == Teams.TeamOne ? gameManager.pointsT1 : gameManager.pointsT2;
                if (health.CurrentValue < health.maxValue && points > POINT_DECREMENT)
                {
                    health.CurrentValue += 1;
                    EventManager.TriggerEvent("IncrementPoints", new PointsEB
                    {
                        points = -POINT_DECREMENT,
                        team = currentLittleGuy.CurrentTeam
                    });
                }
            }

            //Decrease Cooldowns
            currentLittleGuy.UpdateCooldowns(timePassed);
        }
    }

    private GameObject CreateCharacter(int characterNumber, Teams team)
    {
        var position = team == Teams.TeamOne ? Team1Spawn.position : Team2Spawn.position;
        var pNumber = team == Teams.TeamOne ? 1 : 2;
        GameObject newGuy = Instantiate(littleGuys[characterNumber], position, Quaternion.identity);
        newGuy.SetActive(false);
        var newLittleGuy = newGuy.GetComponent<LittleGuy>();
        newLittleGuy.CurrentTeam = team;
        newLittleGuy.PlayerNumber = pNumber;
        return newGuy;
    }

    public void SwapLeftTeam1(EventBody eb)
    {
        var team = Teams.TeamOne;
        Rotate(team, ROTATE_LEFT);
    }

    public void SwapRightTeam1(EventBody eb)
    {
        var team = Teams.TeamOne;
        Rotate(team, ROTATE_RIGHT);
    }

    public void SwapLeftTeam2(EventBody eb)
    {
        var team = Teams.TeamTwo;
        Rotate(team, ROTATE_LEFT);
    }

    public void SwapRightTeam2(EventBody eb)
    {
        var team = Teams.TeamTwo;
        Rotate(team, ROTATE_RIGHT);
    }

    private void Rotate(Teams team, int direction)
    {
        int currentTeamIndex = 0;
        List<GameObject> currentTeamList = null;
        if (team == Teams.TeamOne)
        {
            if (Team1.Count > 1)
            {
                currentTeamIndex = Team1Current;
                currentTeamList = Team1;
                Team1Current = (Team1Current + direction) < 0 ? Team1.Count - 1 : (Team1Current + direction) >= Team1.Count ? 0 : Team1Current + direction;
                Team1[Team1Current].transform.position = Team1[currentTeamIndex].transform.position;
                Team1[currentTeamIndex].SetActive(false);
                Team1[Team1Current].SetActive(true);
                EventManager.TriggerEvent("BeginSwapOut", null);
            }
        }
        else if (team == Teams.TeamTwo)
        {
            if (Team2.Count > 1)
            {
                currentTeamIndex = Team2Current;
                currentTeamList = Team2;
                Team2Current = (Team2Current + direction) < 0 ? Team2.Count - 1 : (Team2Current + direction) >= Team2.Count ? 0 : Team2Current + direction;
                Team2[Team2Current].transform.position = Team2[currentTeamIndex].transform.position;
                Team2[currentTeamIndex].SetActive(false);
                Team2[Team2Current].SetActive(true);
                EventManager.TriggerEvent("BeginSwapOut", null);
                //EventManager.StartListening("CompleteSwapOut", StartSwapIn);
            }
        }
    }

    private void HandleDeath(EventBody eb)
    {
        var deadGuy = ((DeathEB)eb).entity;
        var littleDeadGuy = deadGuy.GetComponent<LittleGuy>();
        if (littleDeadGuy.CurrentTeam == Teams.TeamOne)
        {
            Team1.Remove(deadGuy);
            Destroy(deadGuy);
            Team1Current = 0;
            if (Team1.Count > 0)
            {
                Team1.First<GameObject>().SetActive(true);
            }
            /*if (Team1[Team1Current])
            {
                Team1[Team1Current].SetActive(true);
            }*/
        }
        else if (littleDeadGuy.CurrentTeam == Teams.TeamTwo)
        {
            Team2.Remove(deadGuy);
            Destroy(deadGuy);
            Team2Current = 0;
            if (Team2.Count > 0)
            {
                Team2.First<GameObject>().SetActive(true);
            }
            /*if (Team2[Team2Current])
            {
                Team2[Team2Current].SetActive(true);
            }*/
        }

        EventManager.TriggerEvent("FaintLittleGuy", new TeamFaintEB { team = littleDeadGuy.CurrentTeam });
    }

    private void GameStart(EventBody eb)
    {
        Team1[0].SetActive(true);
        Team2[0].SetActive(true);
    }

    private void StartSwapIn(EventBody eb)
    {

    }
}
