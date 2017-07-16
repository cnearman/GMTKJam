using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGlowey : MonoBehaviour {
    public int DeployedCount;
    public int DeployedMax;

    public LittleGuy parent;

    public GameObject Glowey;

    private int PlayerNumber;

    public void OnEnable()
    {
        parent = GetComponent<LittleGuy>();
        PlayerNumber = parent.PlayerNumber;
        EventManager.StartListening("Ability1_" + PlayerNumber + "Pressed", Activate);
        EventManager.StartListening("Ability2_" + PlayerNumber + "Pressed", Reset);
    }

    public void OnDisable()
    {
        EventManager.StopListening("Ability1_" + PlayerNumber + "Pressed", Activate);
        EventManager.StopListening("Ability2_" + PlayerNumber + "Pressed", Reset);
    }

    public void Activate(EventBody Eb)
    {
        if (parent.ability1CooldownCurrent == 0)
        {
            if (DeployedCount < DeployedMax)
            {
                var glowey = Instantiate(Glowey, gameObject.transform.position, Quaternion.identity);
                glowey.GetComponent<GloweyExplode>().team = GetComponent<LittleGuy>().CurrentTeam;
                DeployedCount = DeployedCount + 1;
            }
        }
    }

    public void Reset(EventBody eb)
    {
        if(parent.ability2CooldownCurrent == 0)
        {
            EventManager.TriggerEvent("GloweyExplode", null);
            DeployedCount = 0;
        }
    }
}
