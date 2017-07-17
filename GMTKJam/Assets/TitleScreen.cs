using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    private void OnEnable()
    {
        EventManager.StartListening("Start_Pressed", GoToSelect);
    } 

    private void OnDisable()
    {
        EventManager.StopListening("Start_Pressed", GoToSelect);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void GoToSelect(EventBody eb)
    {
        SceneManager.LoadScene("CharacterSelect");
    }
}
