using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSeed : MonoBehaviour {
    public Teams currentTeam;
    public float triggerTime;
    public float durration;

    float timeTotrigger = 0f;
    bool hasTriggered = false;

    public GameObject bigOldTree;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timeTotrigger >= triggerTime && !hasTriggered)
        {
            hasTriggered = true;
            GrowBig();
        } else
        {
            timeTotrigger += Time.deltaTime;
        }
	}

    void GrowBig()
    {
        GameObject tempBT = (GameObject)Instantiate(bigOldTree, transform.position + new Vector3(0f,1.4f,0f), transform.rotation);
        tempBT.GetComponentInChildren<AttackVolume>().currentTeam = currentTeam;
        Destroy(tempBT, durration);
        Destroy(gameObject);

    }
}
