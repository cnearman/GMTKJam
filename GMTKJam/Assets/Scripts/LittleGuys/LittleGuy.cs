using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGuy : MonoBehaviour {

    public int PlayerNumber;
    public Teams CurrentTeam;

    public float Ability1CooldownMax;
    public float Ability2CooldownMax;
    public float ability1CooldownCurrent;
    public float ability2CooldownCurrent;

    void OnEnable()
    {
        EventManager.StartListening("Damage_" + PlayerNumber, Damage);
        EventManager.StartListening("Ability1_" + PlayerNumber + "_Triggered", Ability1Activated);
        EventManager.StartListening("Ability2_" + PlayerNumber + "_Triggered", Ability2Activated);
    }

    void OnDisable()
    {
        EventManager.StopListening("Damage_" + PlayerNumber, Damage);
        EventManager.StopListening("Ability1_" + PlayerNumber + "_Triggered", Ability1Activated);
        EventManager.StopListening("Ability2_" + PlayerNumber + "_Triggered", Ability2Activated);
    }

    void Damage(EventBody eb)
    {
        float damage = ((DamageEB)eb).damage;
        Statistics.GetAttribute(AttributeTypes.Health).currentValue -= damage;

        if(Statistics.GetAttribute(AttributeTypes.Health).currentValue <= 0f)
        {
            GetComponent<Animator>().SetTrigger("Death");
            EventManager.TriggerEvent("Death", new DeathEB { entity = gameObject });
        }
    }

    public AttributeList Statistics = new AttributeList
    {

    };

    public void UpdateCooldowns(float delta)
    {
        if(ability1CooldownCurrent > 0)
        {
            ability1CooldownCurrent -= delta;
            if(ability1CooldownCurrent < 0)
            {
                ability1CooldownCurrent = 0;
            }
        }

        if (ability2CooldownCurrent > 0)
        {
            ability2CooldownCurrent -= delta;
            if (ability2CooldownCurrent < 0)
            {
                ability2CooldownCurrent = 0;
            }
        }
    }

    public void Ability1Activated(EventBody eb)
    {
        ability1CooldownCurrent = Ability1CooldownMax;
    }

    public void Ability2Activated(EventBody eb)
    {
        ability2CooldownCurrent = Ability2CooldownMax;
    }
}
