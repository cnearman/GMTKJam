using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGlowey : MonoBehaviour {
    public int DeployedCount;
    public int DeployedMax;

    public GameObject Glowey;

    public void OnEnable()
    {
        EventManager.StartListening("Ability1_1_Pressed", Activate);
    }

    public void OnDisable()
    {
        EventManager.StopListening("Ability1_1_Pressed", Activate);
    }

    public void Activate(EventBody Eb)
    {
        if ( DeployedCount < DeployedMax)
        {
            Instantiate(Glowey, gameObject.transform.position, Quaternion.identity);
            DeployedCount = DeployedCount + 1;
        }
    }
}
