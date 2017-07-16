using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGuy : MonoBehaviour {

    public int PlayerNumber;
    public Teams CurrentTeam;

    void OnEnable()
    {
        EventManager.StartListening("Damage_" + PlayerNumber, Damage);
    }

    void OnDisabled()
    {
        EventManager.StopListening("Damage_" + PlayerNumber, Damage);
    }

    void Damage(EventBody eb)
    {
        float damage = ((DamageEB)eb).damage;
        Statistics.GetAttribute(AttributeTypes.Health).currentValue -= damage;

        if(Statistics.GetAttribute(AttributeTypes.Health).currentValue <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public AttributeList Statistics = new AttributeList
    {

    };
}
