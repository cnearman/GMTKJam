using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameHandler : MonoBehaviour {

    public void OnEnable()
    {
        EventManager.StartListening("Start_Pressed", RestartGame);
    }

    public void OnDisable()
    {
        EventManager.StopListening("Start_Pressed", RestartGame);
    }

    private void RestartGame(EventBody eb)
    {
        var teaminfo = FindObjectOfType<TeamInformation>();
        if (teaminfo != null)
        {
            Destroy(teaminfo);
        }
        SceneManager.LoadScene("CharacterSelect");
    }
}
