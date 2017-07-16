using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSeed : MonoBehaviour {
    public float heal;
    public Teams currentTeam;


    //List<Collider2D> alreadyAttacked = new List<Collider2D>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<LittleGuy>() != null)//!alreadyAttacked.Contains(other) && other.gameObject.GetComponent<LittleGuy>() != null)
        {
            //alreadyAttacked.Add(other);
            if (other.gameObject.GetComponent<LittleGuy>().CurrentTeam == currentTeam)
            {
                EventManager.TriggerEvent("Damage_" + other.gameObject.GetComponent<LittleGuy>().PlayerNumber, new DamageEB { damage = -heal * Time.deltaTime });
            }
        }
    }
}
