using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Exit : MonoBehaviour {

    [SerializeField]
    private bool counting;
    [SerializeField]
    private float countDuration;


    private void OnEnable()
    {
        EventManager.StartListening("Start_Pressed", BeginCount);
        EventManager.StartListening("Start_Released", EndCount);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Start_Pressed", BeginCount);
        EventManager.StopListening("Start_Released", EndCount);
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(counting)
        {
            countDuration += Time.deltaTime;
            if(countDuration > 3)
            {
                Application.Quit();
            }
        }
	}

    private void BeginCount(EventBody eb)
    {
        counting = true;
    }

    private void EndCount(EventBody eb)
    {
        counting = false;
    }
}
